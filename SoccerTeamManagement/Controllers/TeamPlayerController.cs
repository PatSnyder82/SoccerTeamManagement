using AutoMapper;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using SoccerTeamManagement.Data.Models.Joins;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamPlayerController : ControllerBase
    {
        #region Constructor

        private readonly IMapper _mapper;

        private readonly ISoccerManagementService _service;

        public TeamPlayerController(IMapper mapper, ISoccerManagementService service)
        {
            _mapper = mapper;
            _service = service;
        }

        #endregion Constructor

        #region Endpoints

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamPlayer>>> Get()
        {
            var entities = await _service.TeamPlayers.GetAll();

            if (entities != null && await _service.SaveChangesAsync())
                return Ok(_mapper.Map<IEnumerable<TeamPlayer>, IEnumerable<TeamPlayerDTO>>(entities));

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<TeamPlayer>> Get(int teamId, int playerId)
        {
            var entities = await _service.TeamPlayers.GetById(teamId, playerId);

            if (entities != null && await _service.SaveChangesAsync())
                return Ok(_mapper.Map<TeamPlayer, TeamPlayerDTO>(entities));

            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<TeamPlayerDTO>> Post(TeamPlayerDTO dto)
        {
            var entity = _mapper.Map<TeamPlayerDTO, TeamPlayer>(dto);
            var result = await _service.TeamPlayers.Create(entity);

            if (result)
                result = await _service.SaveChangesAsync();

            if (result)
                return CreatedAtAction("Get", new { teamId = entity.TeamId, playerId = entity.PlayerId }, entity);

            return BadRequest(null);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Put(TeamPlayerDTO dto)
        {
            if (dto.PlayerId < 1 || dto.TeamId < 1)
                return BadRequest(false);

            var entity = _mapper.Map<TeamPlayerDTO, TeamPlayer>(dto);

            if (await _service.TeamPlayers.Upsert(entity))
                if (await _service.SaveChangesAsync())
                    return Ok(true);

            return BadRequest(false);
        }

        #endregion Endpoints
    }
}
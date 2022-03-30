using AutoMapper;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using SoccerTeamManagement.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : EntityControllerBase<Team, TeamListDTO, TeamDetailsDTO>
    {
        #region Constructor

        public TeamController(IMapper mapper, ISoccerManagementService service)
            : base(mapper, service, service.Teams)
        {
        }

        #endregion Constructor

        #region Endpoints

        [HttpGet]
        [Route("getteamsbyclub/{clubId:int}")]
        public async Task<ActionResult<TeamDetailsDTO>> GetTeamsByClub(int clubId)
        {
            var entities = await _service.Teams.GetByClubId(clubId);

            if (entities != null)
                return Ok(_mapper.Map<IEnumerable<Team>, IEnumerable<TeamDetailsDTO>>(entities));

            return NoContent();
        }

        [HttpGet]
        [Route("getteamsbyleague/{leagueId:int}")]
        public async Task<ActionResult<TeamDetailsDTO>> GetTeamsByLeague(int leagueId)
        {
            var entities = await _service.Teams.GetByLeagueId(leagueId);

            if (entities != null)
                return Ok(_mapper.Map<IEnumerable<Team>, IEnumerable<TeamDetailsDTO>>(entities));

            return NoContent();
        }

        #endregion Endpoints
    }
}
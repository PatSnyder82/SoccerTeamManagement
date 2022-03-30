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
    public class ClubController : EntityControllerBase<Club, ClubListDTO, ClubDetailsDTO>
    {
        #region Constructor

        public ClubController(IMapper mapper, ISoccerManagementService service)
            : base(mapper, service, service.Clubs)
        {
        }

        #endregion Constructor

        #region Endpoints

        [HttpGet]
        [Route("getclubsbyleague/{leagueId:int}")]
        public async Task<ActionResult<IEnumerable<ClubDetailsDTO>>> GetClubsByLeague(int leagueId)
        {
            var entities = await _service.Clubs.GetByLeagueId(leagueId);

            if (entities != null)
                return Ok(_mapper.Map<IEnumerable<Club>, IEnumerable<ClubDTO>>(entities));

            return NoContent();
        }

        #endregion Endpoints
    }
}
using AutoMapper;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using SoccerTeamManagement.Controllers;
using SoccerTeamManagement.Data.DTOs;

namespace SoccerLeagueManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : EntityControllerBase<League, LeagueListDTO, LeagueDetailsDTO>
    {
        #region Constructor

        public LeagueController(IMapper mapper, ISoccerManagementService service)
            : base(mapper, service, service.Leagues)
        {
        }

        #endregion Constructor
    }
}
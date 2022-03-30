using AutoMapper;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using SoccerTeamManagement.Data.DTOs.People;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : EntityControllerBase<Player, PlayerListDTO, PlayerDetailsDTO>
    {
        #region Constructor

        public PlayerController(IMapper mapper, ISoccerManagementService service)
            : base(mapper, service, service.Players)
        {
        }

        #endregion Constructor
    }
}
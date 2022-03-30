using AutoMapper;
using Core.Models.Lookups;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using SoccerTeamManagement.Data.DTOs.Lookups;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : EntityControllerBase<Position, PositionListDTO, PositionDetailsDTO>
    {
        #region Constructor

        public PositionController(IMapper mapper, ISoccerManagementService service)
            : base(mapper, service, service.Positions)
        {
        }

        #endregion Constructor
    }
}
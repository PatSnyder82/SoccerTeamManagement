using AutoMapper;
using Core.Models.Lookups;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using SoccerTeamManagement.Data.DTOs.Lookups;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : EntityControllerBase<State, StateListDTO, StateDetailsDTO>
    {
        #region Constructor

        public StateController(IMapper mapper, ISoccerManagementService service)
            : base(mapper, service, service.States)
        {
        }

        #endregion Constructor

        #region Endpoints

        [HttpGet]
        [Route("getstatesbycountry/{countryId:int}")]
        public async Task<ActionResult<IEnumerable<StateDTO>>> GetStatesByCountry(int countryId)
        {
            var entities = await _service.States.GetByCountryId(countryId);

            if (entities != null)
                return Ok(_mapper.Map<IEnumerable<State>, IEnumerable<StateDTO>>(entities));

            return NoContent();
        }

        #endregion Endpoints
    }
}
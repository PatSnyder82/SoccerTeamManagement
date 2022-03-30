using AutoMapper;
using Core.Models.Lookups;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using SoccerTeamManagement.Data.DTOs.Lookups;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : EntityControllerBase<Country, CountryListDTO, CountryDetailsDTO>
    {
        #region Constructor

        public CountryController(IMapper mapper, ISoccerManagementService service)
            : base(mapper, service, service.Countries)
        {
        }

        #endregion Constructor
    }
}
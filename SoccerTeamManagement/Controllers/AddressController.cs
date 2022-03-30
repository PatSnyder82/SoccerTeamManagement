using AutoMapper;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using SoccerTeamManagement.Data.DTOs;

namespace SoccerTeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : EntityControllerBase<Address, AddressListDTO, AddressDetailsDTO>
    {
        #region Constructor

        public AddressController(IMapper mapper, ISoccerManagementService service)
            : base(mapper, service, service.Addresses)
        {
        }

        #endregion Constructor
    }
}
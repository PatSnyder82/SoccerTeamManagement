using AutoMapper;
using SoccerTeamManagement.Data.DTOs;
using SoccerTeamManagement.Data.DTOs.People;
using SoccerTeamManagement.Data.Models;
using SoccerTeamManagement.Data.Models.People;

namespace SoccerTeamManagement.Data.MappingProfiles.People
{
    public class PersonBaseProfile : Profile
    {
        public PersonBaseProfile()
        {
            CreateMap<PersonBase, PersonBaseDTO>()
                .IncludeBase<EntityBase, EntityBaseDTO>().ReverseMap();
            CreateMap<PersonBase, PersonFlatBaseDTO>()
                .IncludeBase<EntityBase, EntityBaseDTO>().ReverseMap();
        }
    }
}
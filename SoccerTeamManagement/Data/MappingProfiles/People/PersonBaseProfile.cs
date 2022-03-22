using AutoMapper;
using Core.Abstractions;
using Core.Models;
using SoccerTeamManagement.Data.DTOs;
using SoccerTeamManagement.Data.DTOs.People;

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
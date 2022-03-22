using AutoMapper;
using Core.Abstractions;
using Core.Models.Lookups;
using SoccerTeamManagement.Data.DTOs.Lookups;

namespace SoccerTeamManagement.Data.MappingProfiles
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<State, StateDTO>()
                .IncludeBase<LookupBase, LookupBaseDTO>().ReverseMap();
        }
    }
}
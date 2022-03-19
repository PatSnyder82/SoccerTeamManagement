using AutoMapper;
using SoccerTeamManagement.Data.DTOs.Lookups;
using SoccerTeamManagement.Data.Models;
using SoccerTeamManagement.Data.Models.Lookups;

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
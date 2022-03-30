using AutoMapper;
using Core.Models.Lookups;
using SoccerTeamManagement.Data.DTOs.Lookups;

namespace SoccerTeamManagement.Data.MappingProfiles
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<State, StateDTO>().ReverseMap();
            CreateMap<State, StateDetailsDTO>().ReverseMap();
            CreateMap<State, StateListDTO>().ReverseMap();
        }
    }
}
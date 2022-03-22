using AutoMapper;
using Core.Abstractions;
using Core.Models;
using SoccerTeamManagement.Data.DTOs;

namespace SoccerTeamManagement.Data.MappingProfiles
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            CreateMap<Club, ClubDTO>()
                .IncludeBase<EntityBase, EntityBaseDTO>().ReverseMap();
            CreateMap<Club, ClubDetailsDTO>()
                .IncludeBase<EntityBase, EntityBaseDTO>().ReverseMap();
        }
    }
}
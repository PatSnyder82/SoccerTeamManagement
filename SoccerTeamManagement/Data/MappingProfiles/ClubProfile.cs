using AutoMapper;
using SoccerTeamManagement.Data.DTOs;
using SoccerTeamManagement.Data.Models;

namespace SoccerTeamManagement.Data.MappingProfiles
{
    public class ClubProfile : Profile
    {
        public ClubProfile()
        {
            CreateMap<Club, ClubDTO>()
                .IncludeBase<EntityBase, EntityBaseDTO>().ReverseMap();
            CreateMap<Club, ClubFlatDTO>()
                .IncludeBase<EntityBase, EntityBaseDTO>().ReverseMap();
        }
    }
}
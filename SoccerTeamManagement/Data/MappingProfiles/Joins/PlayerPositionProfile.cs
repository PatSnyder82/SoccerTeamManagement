using AutoMapper;
using SoccerTeamManagement.Data.DTOs.Lookups;
using SoccerTeamManagement.Data.Models.Joins;

namespace SoccerTeamManagement.Data.MappingProfiles.Joins
{
    public class PlayerPositionProfile : Profile
    {
        public PlayerPositionProfile()
        {
            CreateMap<PlayerPositionFlatDTO, PlayerPosition>().ReverseMap();
        }
    }
}
using AutoMapper;
using Core.Models;
using SoccerTeamManagement.Data.Models.Joins;

namespace SoccerTeamManagement.Data.MappingProfiles.Joins
{
    public class TeamPlayerProfile : Profile
    {
        public TeamPlayerProfile()
        {
            CreateMap<TeamPlayerDTO, TeamPlayer>().ReverseMap();
        }
    }
}
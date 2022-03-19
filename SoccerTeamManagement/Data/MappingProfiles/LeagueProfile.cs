using AutoMapper;
using SoccerTeamManagement.Data.DTOs;
using SoccerTeamManagement.Data.Models;
using System.Linq;

namespace SoccerTeamManagement.Data.MappingProfiles
{
    public class LeagueProfile : Profile
    {
        public LeagueProfile()
        {
            CreateMap<League, LeagueDTO>()
                .IncludeBase<EntityBase, EntityBaseDTO>()
                .ForMember(dto => dto.Teams, dto => dto.MapFrom(model => model.LeagueTeams.Select(x => x.Team).ToList()));
            CreateMap<League, LeagueFlatDTO>()
                .IncludeBase<EntityBase, EntityBaseDTO>().ReverseMap();
        }
    }
}
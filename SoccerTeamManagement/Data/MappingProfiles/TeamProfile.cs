using AutoMapper;
using SoccerTeamManagement.Data.DTOs;
using SoccerTeamManagement.Data.Models;
using System.Linq;

namespace SoccerTeamManagement.Data.MappingProfiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamDTO>()
                .IncludeBase<EntityBase, EntityBaseDTO>()
                .ForMember(dto => dto.Leagues, dto => dto.MapFrom(model => model.LeagueTeams.Select(x => x.League).ToList()))
                .ForMember(dto => dto.Players, dto => dto.MapFrom(model => model.TeamPlayers.Select(x => x.Player).ToList()));
            CreateMap<Team, TeamFlatDTO>()
                .IncludeBase<EntityBase, EntityBaseDTO>()
                .ForMember(dto => dto.Leagues, dto => dto.MapFrom(model => model.LeagueTeams.Select(x => x.League).ToList()));
        }
    }
}
using AutoMapper;
using Core.Abstractions;
using Core.Models;
using SoccerTeamManagement.Data.DTOs;
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
            CreateMap<League, LeagueDetailsDTO>()
                .IncludeBase<EntityBase, EntityBaseDTO>().ReverseMap();
        }
    }
}
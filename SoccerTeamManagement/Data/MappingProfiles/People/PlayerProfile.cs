using AutoMapper;
using Core.Models;
using SoccerTeamManagement.Data.DTOs.People;
using System.Linq;

namespace SoccerTeamManagement.Data.MappingProfiles.People
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerDTO>()
                //.IncludeBase<PersonBase, PersonBaseDTO>()
                .ForMember(dto => dto.Teams, dto => dto.MapFrom(model => model.TeamPlayers.Select(x => x.Team).ToList()))
                .ForMember(dto => dto.Parents, dto => dto.MapFrom(model => model.PlayerParents.Select(x => x.Parent).ToList())).ReverseMap();

            CreateMap<Player, PlayerDetailsDTO>()
                //.IncludeBase<PersonBase, PersonDetailsBaseDTO>()
                .ForMember(dto => dto.Parents, dto => dto.MapFrom(model => model.PlayerParents.Select(x => x.Parent).ToList())).ReverseMap();
            //.ForMember(dto => dto.TeamPlayers, dto => dto.MapFrom(model => model.TeamPlayers.Select(x => x.Team).ToList()))
            CreateMap<Player, PlayerListDTO>()
                //.IncludeBase<PersonBase, PersonListBaseDTO>()
                .ReverseMap();
        }
    }
}
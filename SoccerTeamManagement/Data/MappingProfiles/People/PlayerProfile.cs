using AutoMapper;
using SoccerTeamManagement.Data.DTOs.People;
using SoccerTeamManagement.Data.Models.People;
using System.Linq;

namespace SoccerTeamManagement.Data.MappingProfiles.People
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerDTO>()
                .IncludeBase<PersonBase, PersonBaseDTO>()
                .ForMember(dto => dto.Teams, dto => dto.MapFrom(model => model.TeamPlayers.Select(x => x.Team).ToList()))
                .ForMember(dto => dto.Parents, dto => dto.MapFrom(model => model.PlayerParents.Select(x => x.Parent).ToList())).ReverseMap();
            CreateMap<Player, PlayerFlatDTO>()
                .IncludeBase<PersonBase, PersonFlatBaseDTO>()
                .ForMember(dto => dto.Teams, dto => dto.MapFrom(model => model.TeamPlayers.Select(x => x.Team).ToList()))
                .ForMember(dto => dto.Parents, dto => dto.MapFrom(model => model.PlayerParents.Select(x => x.Parent).ToList())).ReverseMap();
        }
    }
}
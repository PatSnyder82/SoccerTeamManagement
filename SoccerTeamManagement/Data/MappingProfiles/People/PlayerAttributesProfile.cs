using AutoMapper;
using Core.Abstractions;
using Core.Models;
using SoccerTeamManagement.Data.DTOs;
using SoccerTeamManagement.Data.DTOs.People;
using System.Linq;

namespace SoccerTeamManagement.Data.MappingProfiles.People
{
    public class PlayerAttributesProfile : Profile
    {
        public PlayerAttributesProfile()
        {
            CreateMap<PlayerAttributes, PlayerAttributesDTO>()
                .IncludeBase<EntityBase, EntityBaseDTO>().ReverseMap().ReverseMap();
        }
    }
}
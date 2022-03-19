using AutoMapper;
using SoccerTeamManagement.Data.DTOs;
using SoccerTeamManagement.Data.DTOs.People;
using SoccerTeamManagement.Data.Models;
using SoccerTeamManagement.Data.Models.People;
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
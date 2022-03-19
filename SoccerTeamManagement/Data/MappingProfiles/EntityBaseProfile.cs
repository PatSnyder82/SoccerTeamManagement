using AutoMapper;
using SoccerTeamManagement.Data.DTOs;
using SoccerTeamManagement.Data.Models;

namespace SoccerTeamManagement.Data.MappingProfiles
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<EntityBase, EntityBaseDTO>().ReverseMap();
        }
    }
}
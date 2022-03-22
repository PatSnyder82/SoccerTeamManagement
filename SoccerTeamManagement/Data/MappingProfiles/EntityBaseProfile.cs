using AutoMapper;
using Core.Abstractions;
using SoccerTeamManagement.Data.DTOs;

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
using AutoMapper;
using Core.Abstractions;
using Core.Models;
using SoccerTeamManagement.Data.DTOs;

namespace SoccerTeamManagement.Data.MappingProfiles
{
    public class LinkProfile : Profile
    {
        public LinkProfile()
        {
            CreateMap<Link, LinkDTO>()
                .IncludeBase<EntityBase, EntityBaseDTO>().ReverseMap();
        }
    }
}
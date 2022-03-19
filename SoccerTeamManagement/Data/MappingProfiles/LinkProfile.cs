using AutoMapper;
using SoccerTeamManagement.Data.DTOs;
using SoccerTeamManagement.Data.Models;

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
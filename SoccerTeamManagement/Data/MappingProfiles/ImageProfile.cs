using AutoMapper;
using SoccerTeamManagement.Data.DTOs;
using SoccerTeamManagement.Data.Models;

namespace SoccerTeamManagement.Data.MappingProfiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDTO>()
                .IncludeBase<EntityBase, EntityBaseDTO>().ReverseMap();
        }
    }
}
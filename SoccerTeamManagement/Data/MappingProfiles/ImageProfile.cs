using AutoMapper;
using Core.Abstractions;
using Core.Models;
using SoccerTeamManagement.Data.DTOs;

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
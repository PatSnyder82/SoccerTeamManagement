using AutoMapper;
using Core.Models.Lookups;
using SoccerTeamManagement.Data.DTOs.Lookups;

namespace SoccerTeamManagement.Data.MappingProfiles.Lookups
{
    public class PositionCategoryProfile : Profile
    {
        public PositionCategoryProfile()
        {
            CreateMap<PositionCategory, PositionCategoryDTO>().ReverseMap();
            CreateMap<PositionCategory, PositionCategoryDetailsDTO>().ReverseMap();
            CreateMap<PositionCategory, PositionCategoryListDTO>().ReverseMap();
        }
    }
}
using AutoMapper;
using Core.Abstractions;
using Core.Models.Lookups;
using SoccerTeamManagement.Data.DTOs.Lookups;

namespace SoccerTeamManagement.Data.MappingProfiles.Lookups
{
    public class PositionCategoryProfile : Profile
    {
        public PositionCategoryProfile()
        {
            CreateMap<PositionCategory, PositionCategoryDTO>()
                .IncludeBase<LookupBase, LookupBaseDTO>().ReverseMap();
            CreateMap<PositionCategory, PositionCategoryFlatDTO>()
                .IncludeBase<LookupBase, LookupBaseDTO>().ReverseMap();
        }
    }
}
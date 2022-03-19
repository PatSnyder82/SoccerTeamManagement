using AutoMapper;
using SoccerTeamManagement.Data.DTOs.Lookups;
using SoccerTeamManagement.Data.Models;
using SoccerTeamManagement.Data.Models.Lookups;

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
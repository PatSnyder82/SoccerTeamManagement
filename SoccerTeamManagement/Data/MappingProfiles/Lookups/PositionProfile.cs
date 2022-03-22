using AutoMapper;
using Core.Abstractions;
using Core.Models.Lookups;
using SoccerTeamManagement.Data.DTOs.Lookups;
using System.Linq;

namespace SoccerTeamManagement.Data.MappingProfiles
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
            CreateMap<Position, PositionDTO>()
                .IncludeBase<LookupBase, LookupBaseDTO>().ReverseMap();
            CreateMap<Position, PositionFlatDTO>()
                .IncludeBase<LookupBase, LookupBaseDTO>()
                .ForMember(dto => dto.Category, dto => dto.MapFrom(x => x.PositionCategory.Text))
                .ForMember(dto => dto.IsPrimary, x => x.MapFrom(y => y.PlayerPositions != null ? y.PlayerPositions.Select(x => x.IsPrimary).FirstOrDefault() : false));
        }
    }
}
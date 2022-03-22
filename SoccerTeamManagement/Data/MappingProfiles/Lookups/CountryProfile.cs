using AutoMapper;
using Core.Abstractions;
using Core.Models.Lookups;
using SoccerTeamManagement.Data.DTOs.Lookups;

namespace SoccerTeamManagement.Data.MappingProfiles.Lookups
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDTO>()
                .IncludeBase<LookupBase, LookupBaseDTO>().ReverseMap();
            CreateMap<Country, CountryFlatDTO>()
                .IncludeBase<LookupBase, LookupBaseDTO>().ReverseMap();
        }
    }
}
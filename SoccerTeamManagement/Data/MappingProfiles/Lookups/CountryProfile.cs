using AutoMapper;
using Core.Models.Lookups;
using SoccerTeamManagement.Data.DTOs.Lookups;

namespace SoccerTeamManagement.Data.MappingProfiles.Lookups
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CountryDetailsDTO>().ReverseMap();
            CreateMap<Country, CountryListDTO>().ReverseMap();
        }
    }
}
using AutoMapper;
using Core.Abstractions;
using SoccerTeamManagement.Data.DTOs.Lookups;

namespace SoccerTeamManagement.Data.MappingProfiles.Lookups
{
    public class LookupBaseProfile : Profile
    {
        public LookupBaseProfile()
        {
            CreateMap<LookupBase, LookupBaseDTO>().ReverseMap();
            CreateMap<LookupBase, DetailsLookupBaseDTO>().ReverseMap();
        }
    }
}
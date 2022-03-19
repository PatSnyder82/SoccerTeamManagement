using AutoMapper;
using SoccerTeamManagement.Data.DTOs.Lookups;
using SoccerTeamManagement.Data.Models.Lookups;

namespace SoccerTeamManagement.Data.MappingProfiles.Lookups
{
    public class LookupBaseProfile : Profile
    {
        public LookupBaseProfile()
        {
            CreateMap<LookupBase, LookupBaseDTO>().ReverseMap();
        }
    }
}
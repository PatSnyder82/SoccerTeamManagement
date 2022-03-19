using AutoMapper;
using SoccerTeamManagement.Data.DTOs.People;
using SoccerTeamManagement.Data.Models.People;
using System.Linq;

namespace SoccerTeamManagement.Data.MappingProfiles.People
{
    public class ParentProfile : Profile
    {
        public ParentProfile()
        {
            CreateMap<Parent, ParentDTO>()
                .IncludeBase<PersonBase, PersonBaseDTO>()
                .ForMember(dto => dto.Players, dto => dto.MapFrom(model => model.PlayerParents.Select(x => x.Player).ToList())).ReverseMap();
            CreateMap<Parent, ParentFlatDTO>()
                .IncludeBase<PersonBase, PersonFlatBaseDTO>().ReverseMap();
        }
    }
}
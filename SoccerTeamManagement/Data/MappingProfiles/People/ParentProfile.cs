using AutoMapper;
using Core.Models;
using SoccerTeamManagement.Data.DTOs.People;
using System.Linq;

namespace SoccerTeamManagement.Data.MappingProfiles.People
{
    public class ParentProfile : Profile
    {
        public ParentProfile()
        {
            CreateMap<Parent, ParentDTO>()
                //.IncludeBase<PersonBase, PersonBaseDTO>()
                .ForMember(dto => dto.Players, dto => dto.MapFrom(model => model.PlayerParents.Select(x => x.Player).ToList())).ReverseMap();
            CreateMap<Parent, ParentDetailsDTO>()
                /*./*IncludeBase<PersonBase, PersonDetailsBaseDTO>()*/
                .ReverseMap();
        }
    }
}
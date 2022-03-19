using AutoMapper;
using SoccerTeamManagement.Data.DTOs;
using SoccerTeamManagement.Data.Models;

namespace SoccerTeamManagement.Data.MappingProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDTO>()
                .IncludeBase<EntityBase, EntityBaseDTO>().ReverseMap();
            CreateMap<Address, AddressFlatDTO>()
                .IncludeBase<EntityBase, EntityBaseDTO>()
                .ForMember(dto => dto.CountryText, dto => dto.MapFrom(model => model.Country.Text))
                .ForMember(dto => dto.CountryAlpha2Code, dto => dto.MapFrom(model => model.Country.Alpha2Code))
                .ForMember(dto => dto.StateText, dto => dto.MapFrom(model => model.State.Text))
                .ForMember(dto => dto.StateAlpha2Code, dto => dto.MapFrom(model => model.State.Alpha2Code)).ReverseMap();
        }
    }
}
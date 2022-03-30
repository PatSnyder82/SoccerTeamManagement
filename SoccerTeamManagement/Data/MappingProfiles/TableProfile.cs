using AutoMapper;
using Core.Models;
using SoccerTeamManagement.Data.DTOs;

namespace SoccerTableManagement.Data.MappingProfiles
{
    public class TableProfile : Profile
    {
        public TableProfile()
        {
            CreateMap(typeof(Table<>), typeof(TableDTO<>)).ReverseMap();
        }
    }
}
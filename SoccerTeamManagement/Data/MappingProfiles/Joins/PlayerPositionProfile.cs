using AutoMapper;
using Core.Models;
using SoccerTeamManagement.Data.DTOs.Joins;

namespace SoccerTeamManagement.Data.MappingProfiles.Joins
{
    public class PlayerPositionProfile : Profile
    {
        public PlayerPositionProfile()
        {
            CreateMap<PlayerPosition, PlayerPositionDTO>()
                .ForMember(dto => dto.Abbreviation, dto => dto.MapFrom(model => model.Position.Abbreviation))
                .ForMember(dto => dto.Category, dto => dto.MapFrom(model => model.Position.PositionCategory.Text))
                .ForMember(dto => dto.PositionCategoryId, dto => dto.MapFrom(model => model.Position.PositionCategoryId));

            CreateMap<PlayerPositionDTO, PlayerPosition>();
        }
    }
}
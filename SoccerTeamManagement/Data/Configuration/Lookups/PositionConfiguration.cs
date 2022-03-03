using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Interfaces;
using SoccerTeamManagement.Data.Models;

namespace SoccerTeamManagement.Data.Configuration.Lookups
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>, ISeed<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Position");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            #region Relationships

            builder.HasOne(x => x.PositionCategory)
                   .WithMany(x => x.Positions)
                   .HasForeignKey(x => x.PositionCategoryId);

            #endregion Relationships

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<Position> builder)
        {
            builder.HasData(new Position { Id = 1, Text = "Goalie", Abbreviation = "G", Value = "G", SortOrder = 1, IsDisabled = false, PositionCategoryId = 1 });
            builder.HasData(new Position { Id = 2, Text = "Right FullBack", Abbreviation = "RB", Value = "RB", SortOrder = 2, IsDisabled = false, PositionCategoryId = 1 });
            builder.HasData(new Position { Id = 3, Text = "Right Wing Back", Abbreviation = "RWB", Value = "RWB", SortOrder = 2, IsDisabled = false, PositionCategoryId = 1 });
            builder.HasData(new Position { Id = 4, Text = "Left FullBack", Abbreviation = "LB", Value = "LB", SortOrder = 3, IsDisabled = false, PositionCategoryId = 1 });
            builder.HasData(new Position { Id = 5, Text = "Left Wing Back", Abbreviation = "LWB", Value = "LWB", SortOrder = 3, IsDisabled = false, PositionCategoryId = 1 });
            builder.HasData(new Position { Id = 6, Text = "Center Back", Abbreviation = "CB", Value = "CB", SortOrder = 4, IsDisabled = false, PositionCategoryId = 1 });
            builder.HasData(new Position { Id = 7, Text = "Center Midfielder", Abbreviation = "CM", Value = "CM", SortOrder = 5, IsDisabled = false, PositionCategoryId = 2 });
            builder.HasData(new Position { Id = 8, Text = "Center Defensive Midfielder", Abbreviation = "CDM", Value = "CDM", SortOrder = 5, IsDisabled = false, PositionCategoryId = 2 });
            builder.HasData(new Position { Id = 9, Text = "Center Attacking Midfielder", Abbreviation = "CAM", Value = "CAM", SortOrder = 5, IsDisabled = false, PositionCategoryId = 2 });
            builder.HasData(new Position { Id = 10, Text = "Left Midfielder", Abbreviation = "LM", Value = "LM", SortOrder = 6, IsDisabled = false, PositionCategoryId = 2 });
            builder.HasData(new Position { Id = 11, Text = "Left Wing", Abbreviation = "LW", Value = "LW", SortOrder = 6, IsDisabled = false, PositionCategoryId = 3 });
            builder.HasData(new Position { Id = 12, Text = "Left Forward", Abbreviation = "LF", Value = "LF", SortOrder = 6, IsDisabled = false, PositionCategoryId = 3 });
            builder.HasData(new Position { Id = 13, Text = "Right Midfielder", Abbreviation = "RM", Value = "RM", SortOrder = 7, IsDisabled = false, PositionCategoryId = 2 });
            builder.HasData(new Position { Id = 14, Text = "Right Wing", Abbreviation = "RW", Value = "RW", SortOrder = 7, IsDisabled = false, PositionCategoryId = 3 });
            builder.HasData(new Position { Id = 15, Text = "Right Forward", Abbreviation = "RF", Value = "RF", SortOrder = 7, IsDisabled = false, PositionCategoryId = 3 });
            builder.HasData(new Position { Id = 16, Text = "Right Wing", Abbreviation = "RW", Value = "RW", SortOrder = 7, IsDisabled = false, PositionCategoryId = 3 });
            builder.HasData(new Position { Id = 17, Text = "Right Forward", Abbreviation = "RF", Value = "RF", SortOrder = 7, IsDisabled = false, PositionCategoryId = 3 });
            builder.HasData(new Position { Id = 18, Text = "Striker", Abbreviation = "ST", Value = "ST", SortOrder = 8, IsDisabled = false, PositionCategoryId = 3 });
            builder.HasData(new Position { Id = 19, Text = "Center Forward", Abbreviation = "CF", Value = "CF", SortOrder = 8, IsDisabled = false, PositionCategoryId = 3 });
        }

        public void SeedDebug(EntityTypeBuilder<Position> builder)
        {
#if DEBUG

#endif
        }
    }
}
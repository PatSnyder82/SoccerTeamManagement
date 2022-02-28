using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Interfaces;
using SoccerTeamManagement.Data.Models;

namespace SoccerTeamManagement.Data.Configuration.Lookups
{
    public class PositionCategoryLookupConfiguration : IEntityTypeConfiguration<PositionCategoryLookup>, ISeed<PositionCategoryLookup>
    {
        public void Configure(EntityTypeBuilder<PositionCategoryLookup> builder)
        {
            builder.ToTable("PositionCategoryLookup");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<PositionCategoryLookup> builder)
        {
            builder.HasData(new PositionCategoryLookup { Id = 1, Text = "Offense", Value = "1", SortOrder = 1, IsDisabled = false });
            builder.HasData(new PositionCategoryLookup { Id = 2, Text = "Midfield", Value = "2", SortOrder = 2, IsDisabled = false });
            builder.HasData(new PositionCategoryLookup { Id = 3, Text = "Defense", Value = "3", SortOrder = 3, IsDisabled = false });
        }

        public void SeedDebug(EntityTypeBuilder<PositionCategoryLookup> builder)
        {
#if DEBUG

#endif
        }
    }
}
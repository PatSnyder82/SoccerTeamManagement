using Core.Models.Lookups;
using Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Lookups
{
    public class PositionCategoryConfiguration : IEntityTypeConfiguration<PositionCategory>, ISeed<PositionCategory>
    {
        public void Configure(EntityTypeBuilder<PositionCategory> builder)
        {
            builder.ToTable("PositionCategory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            #region Relationships

            builder.HasMany(x => x.Positions)
                   .WithOne(x => x.PositionCategory);

            #endregion Relationships

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<PositionCategory> builder)
        {
            builder.HasData(new PositionCategory { Id = 1, Text = "Offense", Value = "1", SortOrder = 1, IsDisabled = false });
            builder.HasData(new PositionCategory { Id = 2, Text = "Midfield", Value = "2", SortOrder = 2, IsDisabled = false });
            builder.HasData(new PositionCategory { Id = 3, Text = "Defense", Value = "3", SortOrder = 3, IsDisabled = false });
        }

        public void SeedDebug(EntityTypeBuilder<PositionCategory> builder)
        {
#if DEBUG

#endif
        }
    }
}
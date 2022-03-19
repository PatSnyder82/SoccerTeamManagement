using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Interfaces;
using SoccerTeamManagement.Data.Models.Joins;

namespace SoccerTeamManagement.Data.Configuration.Joins

{
    public class PlayerPositionConfiguration : IEntityTypeConfiguration<PlayerPosition>, ISeed<PlayerPosition>
    {
        public void Configure(EntityTypeBuilder<PlayerPosition> builder)
        {
            ///Configure join table to create Many to Many relationship between
            ///Player and Position
            builder.ToTable("PlayerPosition");
            builder.HasKey(x => new { x.PlayerId, x.PositionId });

            #region Relationships

            builder.HasOne(x => x.Position)
                   .WithMany(x => x.PlayerPositions)
                   .HasForeignKey(x => x.PositionId);

            builder.HasOne(x => x.Player)
                   .WithMany(x => x.PlayerPositions)
                   .HasForeignKey(x => x.PlayerId);

            #endregion Relationships

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<PlayerPosition> builder)
        {
        }

        public void SeedDebug(EntityTypeBuilder<PlayerPosition> builder)
        {
#if DEBUG
            builder.HasData(new PlayerPosition { IsPrimary = true, PlayerId = 901, PositionId = 1 });
            builder.HasData(new PlayerPosition { IsPrimary = false, PlayerId = 901, PositionId = 2 });
            builder.HasData(new PlayerPosition { IsPrimary = false, PlayerId = 901, PositionId = 3 });
            builder.HasData(new PlayerPosition { IsPrimary = true, PlayerId = 902, PositionId = 4 });
            builder.HasData(new PlayerPosition { IsPrimary = true, PlayerId = 903, PositionId = 5 });
            builder.HasData(new PlayerPosition { IsPrimary = true, PlayerId = 904, PositionId = 6 });
            builder.HasData(new PlayerPosition { IsPrimary = true, PlayerId = 905, PositionId = 18 });
            builder.HasData(new PlayerPosition { IsPrimary = false, PlayerId = 905, PositionId = 7 });
            builder.HasData(new PlayerPosition { IsPrimary = true, PlayerId = 906, PositionId = 11 });
            builder.HasData(new PlayerPosition { IsPrimary = true, PlayerId = 907, PositionId = 12 });

            builder.HasData(new PlayerPosition { IsPrimary = true, PlayerId = 908, PositionId = 13 });
            builder.HasData(new PlayerPosition { IsPrimary = false, PlayerId = 909, PositionId = 7 });
            builder.HasData(new PlayerPosition { IsPrimary = true, PlayerId = 909, PositionId = 11 });
            builder.HasData(new PlayerPosition { IsPrimary = true, PlayerId = 910, PositionId = 12 });
            builder.HasData(new PlayerPosition { IsPrimary = true, PlayerId = 911, PositionId = 13 });
            builder.HasData(new PlayerPosition { IsPrimary = true, PlayerId = 912, PositionId = 14 });
            builder.HasData(new PlayerPosition { IsPrimary = false, PlayerId = 912, PositionId = 15 });
#endif
        }
    }
}
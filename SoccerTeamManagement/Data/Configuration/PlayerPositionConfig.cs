using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Models.Joins;

namespace SoccerTeamManagement.Data.Configuration
{
    public class PlayerPositionConfig : IEntityTypeConfiguration<PlayerPosition>
    {
        public void Configure(EntityTypeBuilder<PlayerPosition> builder)
        {
            ///Configure join table to create Many to Many relationship between
            ///Player and Position
            builder.ToTable("PlayerPosition");
            builder.HasKey(x => new { x.PlayerId, x.PositionId });

            builder.HasOne(x => x.Position)
                   .WithMany(x => x.PlayerPositions)
                   .HasForeignKey(x => x.PositionId);

            builder.HasOne(x => x.Player)
                   .WithMany(x => x.PlayerPositions)
                   .HasForeignKey(x => x.PlayerId);
        }
    }
}
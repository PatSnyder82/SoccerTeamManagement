using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Models.Joins;

namespace SoccerTeamManagement.Data.Configuration
{
    public class PlayerTeamConfig : IEntityTypeConfiguration<PlayerTeam>
    {
        public void Configure(EntityTypeBuilder<PlayerTeam> builder)
        {
            ///Configure join table to create Many to Many relationship between
            ///Player and Team
            builder.ToTable("PlayerTeam");
            builder.HasKey(x => new { x.PlayerId, x.TeamId });

            builder.HasOne(x => x.Team)
                   .WithMany(x => x.PlayerTeams)
                   .HasForeignKey(x => x.TeamId);

            builder.HasOne(x => x.Player)
                   .WithMany(x => x.PlayerTeams)
                   .HasForeignKey(x => x.PlayerId);
        }
    }
}
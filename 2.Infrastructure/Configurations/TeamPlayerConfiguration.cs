using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;
using Infrastructure.Abstractions;
using System;

namespace Infrastructure.Configuration
{
    public class TeamPlayerConfiguration : IEntityTypeConfiguration<TeamPlayer>, ISeed<TeamPlayer>
    {
        public void Configure(EntityTypeBuilder<TeamPlayer> builder)
        {
            builder.ToTable("TeamPlayer");
            builder.HasKey(x => new { x.PlayerId, x.TeamId });
            builder.HasOne(x => x.Player)
                .WithMany(x => x.TeamPlayers)
                .HasForeignKey(x => x.PlayerId)
                .IsRequired();
            builder.HasOne(x => x.Team)
                .WithMany(x => x.TeamPlayers)
                .HasForeignKey(x => x.TeamId)
                .IsRequired();

            #region Relationships

            builder.HasOne(x => x.Team)
                   .WithMany(x => x.TeamPlayers)
                   .HasForeignKey(x => x.TeamId);

            builder.HasOne(x => x.Player)
                   .WithMany(x => x.TeamPlayers)
                   .HasForeignKey(x => x.PlayerId);

            #endregion Relationships

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<TeamPlayer> builder)
        {
        }

        public void SeedDebug(EntityTypeBuilder<TeamPlayer> builder)
        {
#if DEBUG
            builder.HasData(new TeamPlayer { TeamId = 901, PlayerId = 901, JoinedTeam = DateTimeOffset.MinValue, DepartedTeam = DateTimeOffset.Now });
            builder.HasData(new TeamPlayer { TeamId = 901, PlayerId = 902, JoinedTeam = DateTimeOffset.MinValue, DepartedTeam = DateTimeOffset.Now });
            builder.HasData(new TeamPlayer { TeamId = 901, PlayerId = 903, JoinedTeam = DateTimeOffset.MinValue, DepartedTeam = DateTimeOffset.Now });
            builder.HasData(new TeamPlayer { TeamId = 901, PlayerId = 904, JoinedTeam = DateTimeOffset.MinValue, DepartedTeam = DateTimeOffset.Now });
            builder.HasData(new TeamPlayer { TeamId = 902, PlayerId = 905, JoinedTeam = DateTimeOffset.MinValue, DepartedTeam = DateTimeOffset.Now });
            builder.HasData(new TeamPlayer { TeamId = 902, PlayerId = 906, JoinedTeam = DateTimeOffset.MinValue, DepartedTeam = DateTimeOffset.Now });
            builder.HasData(new TeamPlayer { TeamId = 902, PlayerId = 907, JoinedTeam = DateTimeOffset.MinValue, DepartedTeam = DateTimeOffset.Now });
            builder.HasData(new TeamPlayer { TeamId = 903, PlayerId = 908, JoinedTeam = DateTimeOffset.MinValue, DepartedTeam = DateTimeOffset.Now });
            builder.HasData(new TeamPlayer { TeamId = 903, PlayerId = 909, JoinedTeam = DateTimeOffset.MinValue, DepartedTeam = DateTimeOffset.Now });
            builder.HasData(new TeamPlayer { TeamId = 903, PlayerId = 910, JoinedTeam = DateTimeOffset.MinValue, DepartedTeam = DateTimeOffset.Now });
            builder.HasData(new TeamPlayer { TeamId = 903, PlayerId = 911, JoinedTeam = DateTimeOffset.MinValue, DepartedTeam = DateTimeOffset.Now });
            builder.HasData(new TeamPlayer { TeamId = 904, PlayerId = 912, JoinedTeam = DateTimeOffset.MinValue, DepartedTeam = DateTimeOffset.Now });
            builder.HasData(new TeamPlayer { TeamId = 905, PlayerId = 901, JoinedTeam = DateTimeOffset.MinValue, DepartedTeam = DateTimeOffset.Now });
#endif
        }
    }
}
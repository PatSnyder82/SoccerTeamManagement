using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;
using Infrastructure.Abstractions;

namespace Infrastructure.Configuration
{
    public class LeagueTeamConfiguration : IEntityTypeConfiguration<LeagueTeam>, ISeed<LeagueTeam>
    {
        public void Configure(EntityTypeBuilder<LeagueTeam> builder)
        {
            builder.ToTable("LeagueTeam");
            builder.HasKey(x => new { x.LeagueId, x.TeamId });

            #region Relationships

            builder.HasOne(x => x.Team)
                   .WithMany(x => x.LeagueTeams)
                   .HasForeignKey(x => x.TeamId);

            builder.HasOne(x => x.League)
                   .WithMany(x => x.LeagueTeams)
                   .HasForeignKey(x => x.LeagueId);

            #endregion Relationships

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<LeagueTeam> builder)
        {
            #region MLS Teams

            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 1, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 2, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 3, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 4, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 5, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 6, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 7, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 8, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 9, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 10, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 11, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 12, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 13, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 14, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 15, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 16, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 17, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 18, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 19, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 20, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 21, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 22, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 23, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 24, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 25, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 26, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 27, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 1, TeamId = 28, IsPrimary = true });

            #endregion MLS Teams
        }

        public void SeedDebug(EntityTypeBuilder<LeagueTeam> builder)
        {
#if DEBUG
            builder.HasData(new LeagueTeam { LeagueId = 901, TeamId = 901, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 901, TeamId = 902, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 901, TeamId = 903, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 901, TeamId = 904, IsPrimary = true });

            builder.HasData(new LeagueTeam { LeagueId = 902, TeamId = 905, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 902, TeamId = 906, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 902, TeamId = 907, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 902, TeamId = 908, IsPrimary = true });

            builder.HasData(new LeagueTeam { LeagueId = 903, TeamId = 909, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 903, TeamId = 910, IsPrimary = true });
            builder.HasData(new LeagueTeam { LeagueId = 903, TeamId = 911, IsPrimary = true });

            builder.HasData(new LeagueTeam { LeagueId = 904, TeamId = 901, IsPrimary = false });
            builder.HasData(new LeagueTeam { LeagueId = 904, TeamId = 902, IsPrimary = false });

            builder.HasData(new LeagueTeam { LeagueId = 905, TeamId = 903, IsPrimary = false });
            builder.HasData(new LeagueTeam { LeagueId = 905, TeamId = 904, IsPrimary = false });

            builder.HasData(new LeagueTeam { LeagueId = 906, TeamId = 905, IsPrimary = false });
            builder.HasData(new LeagueTeam { LeagueId = 906, TeamId = 906, IsPrimary = false });

            builder.HasData(new LeagueTeam { LeagueId = 907, TeamId = 907, IsPrimary = false });
            builder.HasData(new LeagueTeam { LeagueId = 907, TeamId = 908, IsPrimary = false });

            builder.HasData(new LeagueTeam { LeagueId = 908, TeamId = 909, IsPrimary = false });
            builder.HasData(new LeagueTeam { LeagueId = 908, TeamId = 910, IsPrimary = false });

            builder.HasData(new LeagueTeam { LeagueId = 909, TeamId = 911, IsPrimary = false });
            builder.HasData(new LeagueTeam { LeagueId = 909, TeamId = 912, IsPrimary = false });
#endif
        }
    }
}
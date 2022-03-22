using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;
using Infrastructure.Abstractions;

namespace Infrastructure.Configuration
{
    public class ClubLeagueConfiguration : IEntityTypeConfiguration<ClubLeague>, ISeed<ClubLeague>
    {
        public void Configure(EntityTypeBuilder<ClubLeague> builder)
        {
            builder.ToTable("ClubLeague");
            builder.HasKey(x => new { x.LeagueId, x.ClubId });

            #region Relationships

            builder.HasOne(x => x.Club)
                   .WithMany(x => x.ClubLeagues)
                   .HasForeignKey(x => x.ClubId);

            builder.HasOne(x => x.League)
                   .WithMany(x => x.ClubLeagues)
                   .HasForeignKey(x => x.LeagueId);

            #endregion Relationships

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<ClubLeague> builder)
        {
            #region MLS Clubs

            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 1 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 2 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 3 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 4 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 5 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 6 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 7 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 8 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 9 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 10 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 11 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 12 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 13 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 14 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 15 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 16 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 17 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 18 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 19 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 20 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 21 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 22 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 23 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 24 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 25 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 26 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 27 });
            builder.HasData(new ClubLeague { LeagueId = 1, ClubId = 28 });

            #endregion MLS Clubs
        }

        public void SeedDebug(EntityTypeBuilder<ClubLeague> builder)
        {
#if DEBUG
            builder.HasData(new ClubLeague { LeagueId = 901, ClubId = 901 });
            builder.HasData(new ClubLeague { LeagueId = 901, ClubId = 902 });
            builder.HasData(new ClubLeague { LeagueId = 901, ClubId = 903 });
            builder.HasData(new ClubLeague { LeagueId = 901, ClubId = 904 });

            builder.HasData(new ClubLeague { LeagueId = 902, ClubId = 901 });
            builder.HasData(new ClubLeague { LeagueId = 902, ClubId = 902 });
            builder.HasData(new ClubLeague { LeagueId = 902, ClubId = 903 });
            builder.HasData(new ClubLeague { LeagueId = 902, ClubId = 904 });

            builder.HasData(new ClubLeague { LeagueId = 903, ClubId = 905 });
            builder.HasData(new ClubLeague { LeagueId = 903, ClubId = 906 });
            builder.HasData(new ClubLeague { LeagueId = 903, ClubId = 907 });

            builder.HasData(new ClubLeague { LeagueId = 903, ClubId = 908 });
            builder.HasData(new ClubLeague { LeagueId = 903, ClubId = 909 });

            builder.HasData(new ClubLeague { LeagueId = 904, ClubId = 909 });
            builder.HasData(new ClubLeague { LeagueId = 904, ClubId = 910 });

            builder.HasData(new ClubLeague { LeagueId = 905, ClubId = 909 });
            builder.HasData(new ClubLeague { LeagueId = 905, ClubId = 910 });

            builder.HasData(new ClubLeague { LeagueId = 906, ClubId = 909 });
            builder.HasData(new ClubLeague { LeagueId = 906, ClubId = 910 });

            builder.HasData(new ClubLeague { LeagueId = 907, ClubId = 909 });
            builder.HasData(new ClubLeague { LeagueId = 907, ClubId = 910 });

            builder.HasData(new ClubLeague { LeagueId = 908, ClubId = 911 });
            builder.HasData(new ClubLeague { LeagueId = 908, ClubId = 912 });
#endif
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Interfaces;
using SoccerTeamManagement.Data.Models;

namespace SoccerTeamManagement.Data.Configuration
{
    public class TeamConfig : IEntityTypeConfiguration<Team>, ISeed<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Team");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            #region Relationships

            builder.HasOne(x => x.Club)
                   .WithMany(x => x.Teams);

            #endregion Relationships

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<Team> builder)
        {
            #region Seed MLS Teams

            builder.HasData(new Team { Id = 1, Name = "Atlanta United", ClubId = 1 });
            builder.HasData(new Team { Id = 2, Name = "Austin FC", ClubId = 2 });
            builder.HasData(new Team { Id = 3, Name = "Charlotte FC", ClubId = 3 });
            builder.HasData(new Team { Id = 4, Name = "Chicago Fire FC", ClubId = 4 });
            builder.HasData(new Team { Id = 5, Name = "FC Cincinnati", ClubId = 5 });
            builder.HasData(new Team { Id = 6, Name = "Colorado Rapids", ClubId = 6 });
            builder.HasData(new Team { Id = 7, Name = "Columbus Crew", ClubId = 7 });
            builder.HasData(new Team { Id = 8, Name = "D.C. United", ClubId = 8 });
            builder.HasData(new Team { Id = 9, Name = "FC Dallas", ClubId = 9 });
            builder.HasData(new Team { Id = 10, Name = "Houston Dynamo FC", ClubId = 10 });
            builder.HasData(new Team { Id = 11, Name = "Sporting Kansas City", ClubId = 11 });
            builder.HasData(new Team { Id = 12, Name = "LA Galaxy", ClubId = 12 });
            builder.HasData(new Team { Id = 13, Name = "Los Angeles Football Team", ClubId = 13 });
            builder.HasData(new Team { Id = 14, Name = "Inter Miami CF", ClubId = 14 });
            builder.HasData(new Team { Id = 15, Name = "Minnesota United", ClubId = 15 });
            builder.HasData(new Team { Id = 16, Name = "CF Montreal", ClubId = 16 });
            builder.HasData(new Team { Id = 17, Name = "Nashville SC", ClubId = 17 });
            builder.HasData(new Team { Id = 18, Name = "New England Revolution", ClubId = 18 });
            builder.HasData(new Team { Id = 19, Name = "New York Red Bulls", ClubId = 19 });
            builder.HasData(new Team { Id = 20, Name = "New York City FC", ClubId = 20 });
            builder.HasData(new Team { Id = 21, Name = "Orlando City", ClubId = 21 });
            builder.HasData(new Team { Id = 22, Name = "Philadelphia Union", ClubId = 22 });
            builder.HasData(new Team { Id = 23, Name = "Portland Timbers", ClubId = 23 });
            builder.HasData(new Team { Id = 24, Name = "Real Salt Lake", ClubId = 24 });
            builder.HasData(new Team { Id = 25, Name = "San Jose Earthquakes", ClubId = 25 });
            builder.HasData(new Team { Id = 26, Name = "Seattle Sounders", ClubId = 26 });
            builder.HasData(new Team { Id = 27, Name = "Toronto FC", ClubId = 27 });
            builder.HasData(new Team { Id = 28, Name = "Vancouver Whitecaps", ClubId = 28 });

            #endregion Seed MLS Teams
        }

        public void SeedDebug(EntityTypeBuilder<Team> builder)
        {
#if DEBUG
            builder.HasData(new Team { Id = 901, Name = "Test Team 1", ClubId = 901 });
            builder.HasData(new Team { Id = 902, Name = "Test Team 2", ClubId = 902 });
            builder.HasData(new Team { Id = 903, Name = "Test Team 3", ClubId = 903 });
            builder.HasData(new Team { Id = 904, Name = "Test Team 4", ClubId = 904 });
            builder.HasData(new Team { Id = 905, Name = "Test Team 5", ClubId = 905 });
            builder.HasData(new Team { Id = 906, Name = "Test Team 6", ClubId = 906 });
            builder.HasData(new Team { Id = 907, Name = "Test Team 7", ClubId = 907 });
            builder.HasData(new Team { Id = 908, Name = "Test Team 8", ClubId = 908 });
            builder.HasData(new Team { Id = 909, Name = "Test Team 9", ClubId = 909 });
            builder.HasData(new Team { Id = 910, Name = "Test Team 10", ClubId = 910 });

            builder.HasData(new Team { Id = 911, Name = "Test Team 11", ClubId = 911 });
            builder.HasData(new Team { Id = 912, Name = "Test Team 12", ClubId = 912 });
            builder.HasData(new Team { Id = 913, Name = "Test Team 13", ClubId = 901 });
            builder.HasData(new Team { Id = 914, Name = "Test Team 14", ClubId = 901 });
            builder.HasData(new Team { Id = 915, Name = "Test Team 15", ClubId = 901 });
            builder.HasData(new Team { Id = 916, Name = "Test Team 16", ClubId = 902 });
            builder.HasData(new Team { Id = 917, Name = "Test Team 17", ClubId = 903 });
            builder.HasData(new Team { Id = 918, Name = "Test Team 18", ClubId = 904 });
            builder.HasData(new Team { Id = 919, Name = "Test Team 19", ClubId = 905 });
            builder.HasData(new Team { Id = 920, Name = "Test Team 20", ClubId = 906 });

            builder.HasData(new Team { Id = 921, Name = "Test Team 21", ClubId = 907 });
            builder.HasData(new Team { Id = 922, Name = "Test Team 22", ClubId = 908 });
            builder.HasData(new Team { Id = 923, Name = "Test Team 23", ClubId = 909 });
            builder.HasData(new Team { Id = 924, Name = "Test Team 24", ClubId = 910 });
#endif
        }
    }
}
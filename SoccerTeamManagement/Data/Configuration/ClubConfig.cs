using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Interfaces;
using SoccerTeamManagement.Data.Models;

namespace SoccerTeamManagement.Data.Configuration
{
    public class ClubConfig : IEntityTypeConfiguration<Club>, ISeed<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.ToTable("Club");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            #region Relationships

            builder.HasMany(x => x.Teams)
                   .WithOne()
                   .HasForeignKey(x => x.ClubId);

            #endregion Relationships

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<Club> builder)
        {
            #region Seed MLS Clubs

            builder.HasData(new Club { Id = 1, Name = "Atlanta United" });
            builder.HasData(new Club { Id = 2, Name = "Austin FC" });
            builder.HasData(new Club { Id = 3, Name = "Charlotte FC" });
            builder.HasData(new Club { Id = 4, Name = "Chicago Fire FC" });
            builder.HasData(new Club { Id = 5, Name = "FC Cincinnati" });
            builder.HasData(new Club { Id = 6, Name = "Colorado Rapids" });
            builder.HasData(new Club { Id = 7, Name = "Columbus Crew" });
            builder.HasData(new Club { Id = 8, Name = "D.C. United" });
            builder.HasData(new Club { Id = 9, Name = "FC Dallas" });
            builder.HasData(new Club { Id = 10, Name = "Houston Dynamo FC" });
            builder.HasData(new Club { Id = 11, Name = "Sporting Kansas City" });
            builder.HasData(new Club { Id = 12, Name = "LA Galaxy" });
            builder.HasData(new Club { Id = 13, Name = "Los Angeles Football Club" });
            builder.HasData(new Club { Id = 14, Name = "Inter Miami CF" });
            builder.HasData(new Club { Id = 15, Name = "Minnesota United" });
            builder.HasData(new Club { Id = 16, Name = "CF Montreal" });
            builder.HasData(new Club { Id = 17, Name = "Nashville SC" });
            builder.HasData(new Club { Id = 18, Name = "New England Revolution" });
            builder.HasData(new Club { Id = 19, Name = "New York Red Bulls" });
            builder.HasData(new Club { Id = 20, Name = "New York City FC" });
            builder.HasData(new Club { Id = 21, Name = "Orlando City" });
            builder.HasData(new Club { Id = 22, Name = "Philadelphia Union" });
            builder.HasData(new Club { Id = 23, Name = "Portland Timbers" });
            builder.HasData(new Club { Id = 24, Name = "Real Salt Lake" });
            builder.HasData(new Club { Id = 25, Name = "San Jose Earthquakes" });
            builder.HasData(new Club { Id = 26, Name = "Seattle Sounders" });
            builder.HasData(new Club { Id = 27, Name = "Toronto FC" });
            builder.HasData(new Club { Id = 28, Name = "Vancouver Whitecaps" });

            #endregion Seed MLS Clubs
        }

        public void SeedDebug(EntityTypeBuilder<Club> builder)
        {
#if DEBUG
            builder.HasData(new Club { Id = 901, Name = "Test Club 1" });
            builder.HasData(new Club { Id = 902, Name = "Test Club 2" });
            builder.HasData(new Club { Id = 903, Name = "Test Club 3" });
            builder.HasData(new Club { Id = 904, Name = "Test Club 4" });
            builder.HasData(new Club { Id = 905, Name = "Test Club 5" });
            builder.HasData(new Club { Id = 906, Name = "Test Club 6" });
            builder.HasData(new Club { Id = 907, Name = "Test Club 7" });
            builder.HasData(new Club { Id = 908, Name = "Test Club 8" });
            builder.HasData(new Club { Id = 909, Name = "Test Club 9" });
            builder.HasData(new Club { Id = 910, Name = "Test Club 10" });

            builder.HasData(new Club { Id = 911, Name = "Test Club 11" });
            builder.HasData(new Club { Id = 912, Name = "Test Club 12" });
#endif
        }
    }
}
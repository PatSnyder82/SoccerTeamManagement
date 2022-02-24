using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Interfaces;
using SoccerTeamManagement.Data.Models;

namespace SoccerTeamManagement.Data.Configuration
{
    public class LeagueConfig : IEntityTypeConfiguration<League>, ISeed<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.ToTable("League");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<League> builder)
        {
            builder.HasData(new League { Id = 1, Name = "Major League Soccer" });
            builder.HasData(new League { Id = 2, Name = "Premier League" });
            builder.HasData(new League { Id = 3, Name = "La Liga" });
            builder.HasData(new League { Id = 4, Name = "Serie A" });
            builder.HasData(new League { Id = 5, Name = "Bundesliga" });
            builder.HasData(new League { Id = 6, Name = "Ligue 1" });
            builder.HasData(new League { Id = 7, Name = "Eredivisie" });
            builder.HasData(new League { Id = 8, Name = "Serie A" });
            builder.HasData(new League { Id = 9, Name = "Local League" });
        }

        public void SeedDebug(EntityTypeBuilder<League> builder)
        {
#if DEBUG
            builder.HasData(new League { Id = 901, Name = "Test League 1" });
            builder.HasData(new League { Id = 902, Name = "Test League 2" });
            builder.HasData(new League { Id = 903, Name = "Test League 3" });
            builder.HasData(new League { Id = 904, Name = "Test League 4" });
            builder.HasData(new League { Id = 905, Name = "Test League 5" });
            builder.HasData(new League { Id = 906, Name = "Test League 6" });
            builder.HasData(new League { Id = 907, Name = "Test League 7" });
            builder.HasData(new League { Id = 908, Name = "Test League 8" });
            builder.HasData(new League { Id = 909, Name = "Test League 9" });
            builder.HasData(new League { Id = 910, Name = "Test League 10" });
            builder.HasData(new League { Id = 911, Name = "Test League 11" });
            builder.HasData(new League { Id = 912, Name = "Test League 12" });
#endif
        }
    }
}
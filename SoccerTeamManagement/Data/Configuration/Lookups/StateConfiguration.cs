using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Interfaces;
using SoccerTeamManagement.Data.Models;

namespace SoccerTeamManagement.Data.Configuration.Lookups
{
    public class StateConfiguration : IEntityTypeConfiguration<State>, ISeed<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("State");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            #region Relationships

            builder.HasOne(x => x.Country)
                   .WithMany()
                   .HasForeignKey(x => x.CountryId);

            #endregion Relationships

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<State> builder)
        {
            //ISO 3166 values as of Mar 2022
            builder.HasData(new State { Id = 1, CountryId = 237, Text = "Alabama", Alpha2Code = "AL", Value = "US-AL", SortOrder = 1, IsDisabled = false });
            builder.HasData(new State { Id = 2, CountryId = 237, Text = "Alaska", Alpha2Code = "AK", Value = "US-AK", SortOrder = 2, IsDisabled = false });
            builder.HasData(new State { Id = 3, CountryId = 237, Text = "American Samoa", Alpha2Code = "AS", Value = "US-AS", SortOrder = 3, IsDisabled = false });
            builder.HasData(new State { Id = 4, CountryId = 237, Text = "Arizona", Alpha2Code = "AZ", Value = "US-AZ", SortOrder = 4, IsDisabled = false });
            builder.HasData(new State { Id = 5, CountryId = 237, Text = "Arkansas", Alpha2Code = "AR", Value = "US-AR", SortOrder = 5, IsDisabled = false });
            builder.HasData(new State { Id = 6, CountryId = 237, Text = "California", Alpha2Code = "CA", Value = "US-CA", SortOrder = 6, IsDisabled = false });
            builder.HasData(new State { Id = 7, CountryId = 237, Text = "Colorado", Alpha2Code = "CO", Value = "US-CO", SortOrder = 7, IsDisabled = false });
            builder.HasData(new State { Id = 8, CountryId = 237, Text = "Connecticut", Alpha2Code = "CT", Value = "US-CT", SortOrder = 8, IsDisabled = false });
            builder.HasData(new State { Id = 9, CountryId = 237, Text = "Delaware", Alpha2Code = "DE", Value = "US-DE", SortOrder = 9, IsDisabled = false });
            builder.HasData(new State { Id = 10, CountryId = 237, Text = "District of Columbia", Alpha2Code = "DC", Value = "US-DC", SortOrder = 10, IsDisabled = false });

            builder.HasData(new State { Id = 11, CountryId = 237, Text = "Florida", Alpha2Code = "FL", Value = "US-FL", SortOrder = 11, IsDisabled = false });
            builder.HasData(new State { Id = 12, CountryId = 237, Text = "Georgia", Alpha2Code = "GA", Value = "US-GA", SortOrder = 12, IsDisabled = false });
            builder.HasData(new State { Id = 13, CountryId = 237, Text = "Guam", Alpha2Code = "GU", Value = "US-GU", SortOrder = 13, IsDisabled = false });
            builder.HasData(new State { Id = 14, CountryId = 237, Text = "Hawaii", Alpha2Code = "HI", Value = "US-HI", SortOrder = 14, IsDisabled = false });
            builder.HasData(new State { Id = 15, CountryId = 237, Text = "Idaho", Alpha2Code = "ID", Value = "US-ID", SortOrder = 15, IsDisabled = false });
            builder.HasData(new State { Id = 16, CountryId = 237, Text = "Illinois", Alpha2Code = "IL", Value = "US-IL", SortOrder = 16, IsDisabled = false });
            builder.HasData(new State { Id = 17, CountryId = 237, Text = "Indiana", Alpha2Code = "IN", Value = "US-IN", SortOrder = 17, IsDisabled = false });
            builder.HasData(new State { Id = 18, CountryId = 237, Text = "Iowa", Alpha2Code = "IA", Value = "US-IA", SortOrder = 18, IsDisabled = false });
            builder.HasData(new State { Id = 19, CountryId = 237, Text = "Kansas", Alpha2Code = "KS", Value = "US-KS", SortOrder = 19, IsDisabled = false });
            builder.HasData(new State { Id = 20, CountryId = 237, Text = "Kentucky", Alpha2Code = "KY", Value = "US-KY", SortOrder = 20, IsDisabled = false });

            builder.HasData(new State { Id = 21, CountryId = 237, Text = "Louisiana", Alpha2Code = "LA", Value = "US-LA", SortOrder = 21, IsDisabled = false });
            builder.HasData(new State { Id = 22, CountryId = 237, Text = "Maine", Alpha2Code = "ME", Value = "US-ME", SortOrder = 22, IsDisabled = false });
            builder.HasData(new State { Id = 23, CountryId = 237, Text = "Maryland", Alpha2Code = "MD", Value = "US-MD", SortOrder = 23, IsDisabled = false });
            builder.HasData(new State { Id = 24, CountryId = 237, Text = "Massachusetts", Alpha2Code = "MA", Value = "US-MA", SortOrder = 24, IsDisabled = false });
            builder.HasData(new State { Id = 25, CountryId = 237, Text = "Michigan", Alpha2Code = "MI", Value = "US-MI", SortOrder = 25, IsDisabled = false });
            builder.HasData(new State { Id = 26, CountryId = 237, Text = "Minnesota", Alpha2Code = "MN", Value = "US-MN", SortOrder = 26, IsDisabled = false });
            builder.HasData(new State { Id = 27, CountryId = 237, Text = "Mississippi", Alpha2Code = "MS", Value = "US-MS", SortOrder = 27, IsDisabled = false });
            builder.HasData(new State { Id = 28, CountryId = 237, Text = "Missouri", Alpha2Code = "MO", Value = "US-MO", SortOrder = 28, IsDisabled = false });
            builder.HasData(new State { Id = 29, CountryId = 237, Text = "Montana", Alpha2Code = "MT", Value = "US-MT", SortOrder = 29, IsDisabled = false });
            builder.HasData(new State { Id = 30, CountryId = 237, Text = "Nebraska", Alpha2Code = "NE", Value = "US-NE", SortOrder = 30, IsDisabled = false });

            builder.HasData(new State { Id = 31, CountryId = 237, Text = "Nevada", Alpha2Code = "NV", Value = "US-NV", SortOrder = 31, IsDisabled = false });
            builder.HasData(new State { Id = 32, CountryId = 237, Text = "New Hampshire", Alpha2Code = "NH", Value = "US-NH", SortOrder = 32, IsDisabled = false });
            builder.HasData(new State { Id = 33, CountryId = 237, Text = "New Jersey", Alpha2Code = "NJ", Value = "US-NJ", SortOrder = 33, IsDisabled = false });
            builder.HasData(new State { Id = 34, CountryId = 237, Text = "New Mexico", Alpha2Code = "NM", Value = "US-NM", SortOrder = 34, IsDisabled = false });
            builder.HasData(new State { Id = 35, CountryId = 237, Text = "New York", Alpha2Code = "NY", Value = "US-NY", SortOrder = 35, IsDisabled = false });
            builder.HasData(new State { Id = 36, CountryId = 237, Text = "North Carolina", Alpha2Code = "NC", Value = "US-NC", SortOrder = 36, IsDisabled = false });
            builder.HasData(new State { Id = 37, CountryId = 237, Text = "North Dakota", Alpha2Code = "ND", Value = "US-ND", SortOrder = 37, IsDisabled = false });
            builder.HasData(new State { Id = 38, CountryId = 237, Text = "Northern Mariana Islands", Alpha2Code = "MP", Value = "US-MP", SortOrder = 38, IsDisabled = false });
            builder.HasData(new State { Id = 39, CountryId = 237, Text = "Ohio", Alpha2Code = "OH", Value = "US-OH", SortOrder = 39, IsDisabled = false });
            builder.HasData(new State { Id = 40, CountryId = 237, Text = "Oklahoma", Alpha2Code = "OK", Value = "US-OK", SortOrder = 40, IsDisabled = false });

            builder.HasData(new State { Id = 41, CountryId = 237, Text = "Oregon", Alpha2Code = "OR", Value = "US-OR", SortOrder = 41, IsDisabled = false });
            builder.HasData(new State { Id = 42, CountryId = 237, Text = "Pennsylvania", Alpha2Code = "PA", Value = "US-PA", SortOrder = 42, IsDisabled = false });
            builder.HasData(new State { Id = 43, CountryId = 237, Text = "Puerto Rico", Alpha2Code = "PR", Value = "US-PR", SortOrder = 43, IsDisabled = false });
            builder.HasData(new State { Id = 44, CountryId = 237, Text = "Rhode Island", Alpha2Code = "RI", Value = "US-RI", SortOrder = 44, IsDisabled = false });
            builder.HasData(new State { Id = 45, CountryId = 237, Text = "South Carolina", Alpha2Code = "SC", Value = "US-SC", SortOrder = 45, IsDisabled = false });
            builder.HasData(new State { Id = 46, CountryId = 237, Text = "South Dakota", Alpha2Code = "SD", Value = "US-SD", SortOrder = 46, IsDisabled = false });
            builder.HasData(new State { Id = 47, CountryId = 237, Text = "Tennessee", Alpha2Code = "TN", Value = "US-TN", SortOrder = 47, IsDisabled = false });
            builder.HasData(new State { Id = 48, CountryId = 237, Text = "Texas", Alpha2Code = "TX", Value = "US-TX", SortOrder = 48, IsDisabled = false });
            builder.HasData(new State { Id = 49, CountryId = 237, Text = "United States Minor Outlying Islands", Alpha2Code = "UM", Value = "US-UM", SortOrder = 49, IsDisabled = false });
            builder.HasData(new State { Id = 50, CountryId = 237, Text = "Utah", Alpha2Code = "UT", Value = "US-UT", SortOrder = 50, IsDisabled = false });

            builder.HasData(new State { Id = 51, CountryId = 237, Text = "Vermont", Alpha2Code = "VT", Value = "US-VT", SortOrder = 51, IsDisabled = false });
            builder.HasData(new State { Id = 52, CountryId = 237, Text = "Virgin Islands, U.S.", Alpha2Code = "VI", Value = "US-VI", SortOrder = 52, IsDisabled = false });
            builder.HasData(new State { Id = 53, CountryId = 237, Text = "Virginia", Alpha2Code = "VA", Value = "US-VA", SortOrder = 53, IsDisabled = false });
            builder.HasData(new State { Id = 54, CountryId = 237, Text = "Washington", Alpha2Code = "WA", Value = "US-WA", SortOrder = 54, IsDisabled = false });
            builder.HasData(new State { Id = 55, CountryId = 237, Text = "West Virginia", Alpha2Code = "WV", Value = "US-WV", SortOrder = 55, IsDisabled = false });
            builder.HasData(new State { Id = 56, CountryId = 237, Text = "Wisconsin", Alpha2Code = "WI", Value = "US-WI", SortOrder = 56, IsDisabled = false });
            builder.HasData(new State { Id = 57, CountryId = 237, Text = "Wyoming", Alpha2Code = "WY", Value = "US-WY", SortOrder = 57, IsDisabled = false });
        }

        public void SeedDebug(EntityTypeBuilder<State> builder)
        {
#if DEBUG

#endif
        }
    }
}
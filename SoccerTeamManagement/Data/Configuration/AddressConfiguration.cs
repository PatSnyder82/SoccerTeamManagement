using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Interfaces;
using SoccerTeamManagement.Data.Models;

namespace SoccerTeamManagement.Data.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>, ISeed<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<Address> builder)
        {
        }

        public void SeedDebug(EntityTypeBuilder<Address> builder)
        {
#if DEBUG
            builder.HasData(new Address { Id = 901, AddressLine1 = "1600 Pennsylvania Avenue NW", City = "Washington", State = "DC", Country = "United States", ZipCode = "20500" });
            builder.HasData(new Address { Id = 902, AddressLine1 = "11 Wall Street", City = "New York", State = "New York", Country = "United States", ZipCode = "10118" });
            builder.HasData(new Address { Id = 903, AddressLine1 = "350 Fifth Avenue", City = "New York", State = "New York", Country = "United States", ZipCode = "10118" });
            builder.HasData(new Address { Id = 904, AddressLine1 = "221 B Baker Street", City = "London", State = "", Country = "England", ZipCode = "" });
            builder.HasData(new Address { Id = 905, AddressLine1 = "4059 Mt. Lee Drive", City = "Hollywood", State = "California", Country = "United States", ZipCode = "90068" });
            builder.HasData(new Address { Id = 906, AddressLine1 = "400 S. Monroe Street", City = "Tallahassee", State = "Florida", Country = "United States", ZipCode = "32399" });
            builder.HasData(new Address { Id = 907, AddressLine1 = "1100 Congress Avenue", City = "Austin", State = "Texas", Country = "United States", ZipCode = "78701" });
            builder.HasData(new Address { Id = 908, AddressLine1 = "2300 N Lincoln Blvd", City = "Oklahoma City", State = "Oklahoma", Country = "United States", ZipCode = "73105" });
            builder.HasData(new Address { Id = 909, AddressLine1 = "350 State Street", City = "Salt Lake City", State = "Utah", Country = "United States", ZipCode = "84103" });
            builder.HasData(new Address { Id = 910, AddressLine1 = "501 N. 3rd Street", City = "Harrisburg", State = "Pennsylvania", Country = "United States", ZipCode = "17120" });

            builder.HasData(new Address { Id = 911, AddressLine1 = "200 E. Colfax Ave", City = "Denver", State = "Colorado", Country = "United States", ZipCode = "80203" });
            builder.HasData(new Address { Id = 912, AddressLine1 = "416 Sid Snyder Avenue SW", City = "Olympia", State = "Washington", Country = "United States", ZipCode = "98504" });
#endif
        }
    }
}
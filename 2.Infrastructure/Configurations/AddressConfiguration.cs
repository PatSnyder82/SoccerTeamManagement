using Core.Models;
using Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
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
            builder.HasData(new Address { Id = 901, StateId = 10, CountryId = 237, AddressLine1 = "1600 Pennsylvania Avenue NW", City = "Washington", ZipCode = "20500" });
            builder.HasData(new Address { Id = 902, StateId = 35, CountryId = 237, AddressLine1 = "11 Wall Street", City = "New York", ZipCode = "10118" });
            builder.HasData(new Address { Id = 903, StateId = 35, CountryId = 237, AddressLine1 = "350 Fifth Avenue", City = "New York", ZipCode = "10118" });
            builder.HasData(new Address { Id = 904, StateId = null, CountryId = 237, AddressLine1 = "221 B Baker Street", City = "London", ZipCode = "" });
            builder.HasData(new Address { Id = 905, StateId = 6, CountryId = 237, AddressLine1 = "4059 Mt. Lee Drive", City = "Hollywood", ZipCode = "90068" });
            builder.HasData(new Address { Id = 906, StateId = 11, CountryId = 237, AddressLine1 = "400 S. Monroe Street", City = "Tallahassee", ZipCode = "32399" });
            builder.HasData(new Address { Id = 907, StateId = 48, CountryId = 237, AddressLine1 = "1100 Congress Avenue", City = "Austin", ZipCode = "78701" });
            builder.HasData(new Address { Id = 908, StateId = 40, CountryId = 237, AddressLine1 = "2300 N Lincoln Blvd", City = "Oklahoma City", ZipCode = "73105" });
            builder.HasData(new Address { Id = 909, StateId = 50, CountryId = 237, AddressLine1 = "350 State Street", City = "Salt Lake City", ZipCode = "84103" });
            builder.HasData(new Address { Id = 910, StateId = 42, CountryId = 237, AddressLine1 = "501 N. 3rd Street", City = "Harrisburg", ZipCode = "17120" });

            builder.HasData(new Address { Id = 911, StateId = 7, CountryId = 237, AddressLine1 = "200 E. Colfax Ave", City = "Denver", ZipCode = "80203" });
            builder.HasData(new Address { Id = 912, StateId = 54, CountryId = 237, AddressLine1 = "416 Sid Snyder Avenue SW", City = "Olympia", ZipCode = "98504" });
#endif
        }
    }
}
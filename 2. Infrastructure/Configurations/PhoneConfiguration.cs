using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;
using Infrastructure.Abstractions;
using Core.Enumerations;

namespace Infrastructure.Configuration
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>, ISeed<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable("Phone");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.Property(s => s.PhoneType).HasConversion<string>();

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<Phone> builder)
        {
        }

        public void SeedDebug(EntityTypeBuilder<Phone> builder)
        {
#if DEBUG
            builder.HasData(new Phone { Id = 901, CountryCode = "1", AreaCode = "360", Extension = null, Number = "9028880", PhoneType = Enums.PhoneType.Cell });
            builder.HasData(new Phone { Id = 902, CountryCode = "1", AreaCode = "405", Extension = null, Number = "9028880", PhoneType = Enums.PhoneType.Cell });
            builder.HasData(new Phone { Id = 903, CountryCode = "1", AreaCode = "405", Extension = null, Number = "9028880", PhoneType = Enums.PhoneType.Cell });
            builder.HasData(new Phone { Id = 904, CountryCode = "1", AreaCode = "940", Extension = null, Number = "9028880", PhoneType = Enums.PhoneType.Home });
            builder.HasData(new Phone { Id = 905, CountryCode = "1", AreaCode = "850", Extension = null, Number = "9028880", PhoneType = Enums.PhoneType.Cell });
            builder.HasData(new Phone { Id = 906, CountryCode = "1", AreaCode = "717", Extension = null, Number = "9028880", PhoneType = Enums.PhoneType.Cell });
            builder.HasData(new Phone { Id = 907, CountryCode = "1", AreaCode = "719", Extension = null, Number = "9028880", PhoneType = Enums.PhoneType.Work });
            builder.HasData(new Phone { Id = 908, CountryCode = "1", AreaCode = "123", Extension = null, Number = "9028880", PhoneType = Enums.PhoneType.Cell });
            builder.HasData(new Phone { Id = 909, CountryCode = "1", AreaCode = "456", Extension = null, Number = "9028880", PhoneType = Enums.PhoneType.Cell });
            builder.HasData(new Phone { Id = 910, CountryCode = "1", AreaCode = "789", Extension = null, Number = "9028880", PhoneType = Enums.PhoneType.Home });

            builder.HasData(new Phone { Id = 911, CountryCode = "49", AreaCode = "", Extension = null, Number = "9028880", PhoneType = Enums.PhoneType.Cell });
            builder.HasData(new Phone { Id = 912, CountryCode = "1", AreaCode = "234", Extension = null, Number = "9028880", PhoneType = Enums.PhoneType.Cell });
            builder.HasData(new Phone { Id = 913, CountryCode = "1", AreaCode = "837", Extension = null, Number = "9028880", PhoneType = Enums.PhoneType.Cell });
#endif
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Interfaces;
using SoccerTeamManagement.Data.Models.People;
using System;

namespace SoccerTeamManagement.Data.Configuration.People
{
    public class ParentConfiguration : PersonConfiguration<Parent>, IEntityTypeConfiguration<Parent>, ISeed<Parent>
    {
        public override void Configure(EntityTypeBuilder<Parent> builder)
        {
            base.Configure(builder);

            builder.ToTable("Parent");
            builder.HasBaseType<Person>();

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<Parent> builder)
        {
        }

        public void SeedDebug(EntityTypeBuilder<Parent> builder)
        {
#if DEBUG
            builder.HasData(new Parent { Id = 901, AddressId = 901, PhoneId = 901, FirstName = "TestParentFirst1", LastName = "TestParentLast1", NickName = "TestParent 1", DateOfBirth = new DateTime(1984, 11, 13) });
            builder.HasData(new Parent { Id = 902, AddressId = 902, PhoneId = 902, FirstName = "TestParentFirst2", LastName = "TestParentLast2", NickName = "TestParent 2", DateOfBirth = new DateTime(1985, 9, 5) });
            builder.HasData(new Parent { Id = 903, AddressId = 903, PhoneId = 903, FirstName = "TestParentFirst3", LastName = "TestParentLast3", NickName = "TestParent 3", DateOfBirth = new DateTime(1986, 8, 3) });
            builder.HasData(new Parent { Id = 904, AddressId = 904, PhoneId = 904, FirstName = "TestParentFirst4", LastName = "TestParentLast4", NickName = "TestParent 4", DateOfBirth = new DateTime(1987, 7, 1) });
            builder.HasData(new Parent { Id = 905, AddressId = 905, PhoneId = 905, FirstName = "TestParentFirst5", LastName = "TestParentLast5", NickName = "TestParent 5", DateOfBirth = new DateTime(1988, 6, 17) });
            builder.HasData(new Parent { Id = 906, AddressId = 906, PhoneId = 906, FirstName = "TestParentFirst6", LastName = "TestParentLast6", NickName = "TestParent 6", DateOfBirth = new DateTime(1989, 5, 28) });
            builder.HasData(new Parent { Id = 907, AddressId = 907, PhoneId = 907, FirstName = "TestParentFirst7", LastName = "TestParentLast7", NickName = "TestParent 7", DateOfBirth = new DateTime(1990, 4, 13) });
            builder.HasData(new Parent { Id = 908, AddressId = 908, PhoneId = 908, FirstName = "TestParentFirst8", LastName = "TestParentLast8", NickName = "TestParent 8", DateOfBirth = new DateTime(1967, 3, 20) });
            builder.HasData(new Parent { Id = 909, AddressId = 909, PhoneId = 909, FirstName = "TestParentFirst9", LastName = "TestParentLast9", NickName = "TestParent 9", DateOfBirth = new DateTime(1968, 2, 26) });
            builder.HasData(new Parent { Id = 910, AddressId = 910, PhoneId = 910, FirstName = "TestParentFirst10", LastName = "TestParentLast10", NickName = "TestParent 10", DateOfBirth = new DateTime(1954, 1, 12) });

            builder.HasData(new Parent { Id = 911, AddressId = 911, PhoneId = 911, FirstName = "TestParentFirst11", LastName = "TestParentLast11", NickName = "TestParent 11", DateOfBirth = new DateTime(1978, 12, 24) });
            builder.HasData(new Parent { Id = 912, AddressId = 912, PhoneId = 912, FirstName = "TestParentFirst12", LastName = "TestParentLast12", NickName = "TestParent 12", DateOfBirth = new DateTime(1999, 5, 13) });
#endif
        }
    }
}
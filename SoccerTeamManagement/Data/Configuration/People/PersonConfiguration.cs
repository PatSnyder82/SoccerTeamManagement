using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Models.People;

namespace SoccerTeamManagement.Data.Configuration.People
{
    public class PersonConfiguration<T> : IEntityTypeConfiguration<T> where T : Person
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            #region Relationships

            //One Person to One Phone
            builder.HasOne(x => x.Phone)
                   .WithOne()
                   .HasForeignKey<T>(x => x.PhoneId);

            //One Person to One Address
            builder.HasOne(x => x.Address)
                   .WithOne()
                   .HasForeignKey<T>(x => x.AddressId);

            ///A Person has One Nation
            builder.HasOne(x => x.Country)
                   .WithMany()
                   .HasForeignKey(x => x.CountryId);

            #endregion Relationships

            //No Seed in base class.  Seeding performed in derived classes...Person, Parent, etc
        }
    }
}
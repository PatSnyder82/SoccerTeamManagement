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

            #region Relationships

            //One Person to One Phone
            builder.HasOne(x => x.Phone)
                   .WithOne()
                   .HasForeignKey<Person>(x => x.PhoneId);

            //One Person to One Address
            builder.HasOne(x => x.Address)
                   .WithOne()
                   .HasForeignKey<Person>(x => x.AddressId);

            ///A Person has One Nation
            builder.HasOne(x => x.Nation)
                   .WithMany()
                   .HasForeignKey(x => x.NationId);

            #endregion Relationships

            //No Seed in base class.  Seeding performed in derived classes...Person, Parent, etc
        }
    }
}
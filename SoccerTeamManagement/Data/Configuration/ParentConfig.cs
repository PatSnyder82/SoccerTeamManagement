using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Models;

namespace SoccerTeamManagement.Data.Configuration
{
    public class ParentConfig : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.ToTable("Parent");

            #region Relationships

            //One Person to One Phone
            builder.HasOne(x => x.Phone)
                   .WithOne()
                   .HasForeignKey<Parent>(x => x.PhoneId);

            //One Person to One Address
            builder.HasOne(x => x.Address)
                   .WithOne()
                   .HasForeignKey<Parent>(x => x.AddressId);

            #endregion Relationships
        }
    }
}
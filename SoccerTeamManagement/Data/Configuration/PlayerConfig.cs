using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Models;

namespace SoccerTeamManagement.Data.Configuration
{
    public class PlayerConfig : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Player");

            #region Relationships

            //One Person to One Phone
            builder.HasOne(x => x.Phone)
                   .WithOne()
                   .HasForeignKey<Player>(x => x.PhoneId);

            //One Person to One Address
            builder.HasOne(x => x.Address)
                   .WithOne()
                   .HasForeignKey<Player>(x => x.AddressId);

            ///One Player has One Nation
            builder.HasOne(x => x.Nation)
                   .WithOne()
                   .HasForeignKey<Player>(x => x.NationId);

            //One Player has One Attributes Record
            builder.HasOne(x => x.Attributes)
                   .WithOne(x => x.Player)
                   .HasForeignKey<Player>(x => x.AttributesId);

            #endregion Relationships
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Models;

namespace SoccerTeamManagement.Data.Configuration
{
    public class PlayerAttributesConfig : IEntityTypeConfiguration<PlayerAttributes>
    {
        public void Configure(EntityTypeBuilder<PlayerAttributes> builder)
        {
            builder.ToTable("PlayerAttributes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            #region Relationships

            //One Player has One PlayerAttributes
            builder.HasOne(x => x.Player)
                   .WithOne(x => x.Attributes)
                   .HasForeignKey<Player>(x => x.AttributesId);

            #endregion Relationships
        }
    }
}
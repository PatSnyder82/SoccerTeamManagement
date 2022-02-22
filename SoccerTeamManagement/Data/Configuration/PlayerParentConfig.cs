using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Models.Joins;

namespace SoccerTeamManagement.Data.Configuration
{
    public class PlayerParentConfig : IEntityTypeConfiguration<PlayerParent>
    {
        public void Configure(EntityTypeBuilder<PlayerParent> builder)
        {
            ///Configure join table to create Many to Many relationship between
            ///Player and Parent
            builder.ToTable("PlayerParent");
            builder.HasKey(x => new { x.PlayerId, x.ParentId });

            builder.HasOne(x => x.Parent)
                   .WithMany(x => x.Children)
                   .HasForeignKey(x => x.ParentId);

            builder.HasOne(x => x.Player)
                   .WithMany(x => x.Parents)
                   .HasForeignKey(x => x.PlayerId);
        }
    }
}
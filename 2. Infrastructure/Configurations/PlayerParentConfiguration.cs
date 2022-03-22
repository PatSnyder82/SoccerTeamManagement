using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;
using Infrastructure.Abstractions;

namespace Infrastructure.Configuration
{
    public class PlayerParentConfiguration : IEntityTypeConfiguration<PlayerParent>, ISeed<PlayerParent>
    {
        public void Configure(EntityTypeBuilder<PlayerParent> builder)
        {
            builder.ToTable("PlayerParent");
            builder.HasKey(x => new { x.PlayerId, x.ParentId });

            #region Relationships

            builder.HasOne(x => x.Parent)
                   .WithMany(x => x.PlayerParents)
                   .HasForeignKey(x => x.ParentId);

            builder.HasOne(x => x.Player)
                   .WithMany(x => x.PlayerParents)
                   .HasForeignKey(x => x.PlayerId);

            #endregion Relationships

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<PlayerParent> builder)
        {
        }

        public void SeedDebug(EntityTypeBuilder<PlayerParent> builder)
        {
#if DEBUG
            builder.HasData(new PlayerParent { ParentId = 901, PlayerId = 901 });
            builder.HasData(new PlayerParent { ParentId = 901, PlayerId = 902 });
            builder.HasData(new PlayerParent { ParentId = 902, PlayerId = 903 });
            builder.HasData(new PlayerParent { ParentId = 902, PlayerId = 904 });
            builder.HasData(new PlayerParent { ParentId = 903, PlayerId = 905 });
            builder.HasData(new PlayerParent { ParentId = 903, PlayerId = 906 });
            builder.HasData(new PlayerParent { ParentId = 904, PlayerId = 907 });
            builder.HasData(new PlayerParent { ParentId = 904, PlayerId = 908 });
            builder.HasData(new PlayerParent { ParentId = 907, PlayerId = 909 });
            builder.HasData(new PlayerParent { ParentId = 908, PlayerId = 910 });
            builder.HasData(new PlayerParent { ParentId = 910, PlayerId = 911 });
            builder.HasData(new PlayerParent { ParentId = 911, PlayerId = 912 });
            builder.HasData(new PlayerParent { ParentId = 912, PlayerId = 901 });
#endif
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;
using Infrastructure.Abstractions;

namespace Infrastructure.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>, ISeed<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Image");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            //Do not store image in database
            //builder.Ignore(x => x.File);

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<Image> builder)
        {
        }

        public void SeedDebug(EntityTypeBuilder<Image> builder)
        {
#if DEBUG

#endif
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Models;

namespace SoccerTeamManagement.Data.Configuration
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Image");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.OwnsOne(x => x.Source);
        }
    }
}
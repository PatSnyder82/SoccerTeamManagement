using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Interfaces;
using SoccerTeamManagement.Data.Models;

namespace SoccerTeamManagement.Data.Configuration
{
    public class LinkConfiguration : IEntityTypeConfiguration<Link>, ISeed<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<Link> builder)
        {
        }

        public void SeedDebug(EntityTypeBuilder<Link> builder)
        {
#if DEBUG

#endif
        }
    }
}
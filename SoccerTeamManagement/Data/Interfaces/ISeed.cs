using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SoccerTeamManagement.Data.Interfaces
{
    internal interface ISeed<T> where T : class
    {
        void Seed(EntityTypeBuilder<T> builder);

        void SeedDebug(EntityTypeBuilder<T> builder);
    }
}
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SoccerTeamManagement.Data.Configuration;
using SoccerTeamManagement.Data.Configuration.Joins;
using SoccerTeamManagement.Data.Configuration.Lookups;
using SoccerTeamManagement.Data.Configuration.People;
using SoccerTeamManagement.Data.Models;
using SoccerTeamManagement.Data.Models.Joins;
using SoccerTeamManagement.Data.Models.People;
using SoccerTeamManagement.Data.People;

namespace SoccerTeamManagement.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //add the EntityType Configuration Classes

            #region Lookups

            new PositionCategoryLookupConfiguration().Configure(builder.Entity<PositionCategoryLookup>());
            new PositionLookupConfiguration().Configure(builder.Entity<PositionLookup>());
            new CountryLookupConfiguration().Configure(builder.Entity<CountryLookup>());

            #endregion Lookups

            new AddressConfiguration().Configure(builder.Entity<Address>());
            new ImageConfiguration().Configure(builder.Entity<Image>());
            new PhoneConfiguration().Configure(builder.Entity<Phone>());
            new ClubConfiguration().Configure(builder.Entity<Club>());
            new LeagueConfiguration().Configure(builder.Entity<League>());
            new TeamConfiguration().Configure(builder.Entity<Team>());
            new PlayerAttributesConfiguration().Configure(builder.Entity<PlayerAttributes>());
            new PlayerConfiguration().Configure(builder.Entity<Player>());
            new ParentConfiguration().Configure(builder.Entity<Parent>());

            #region Joins

            new LeagueTeamConfiguration().Configure(builder.Entity<LeagueTeam>());
            new PlayerPositionConfiguration().Configure(builder.Entity<PlayerPosition>());
            new TeamPlayerConfiguration().Configure(builder.Entity<TeamPlayer>());
            new PlayerParentConfiguration().Configure(builder.Entity<PlayerParent>());

            #endregion Joins
        }

        public DbSet<SoccerTeamManagement.Data.Models.People.Player> Players { get; set; }

        public DbSet<SoccerTeamManagement.Data.Models.CountryLookup> CountryLookup { get; set; }
    }
}
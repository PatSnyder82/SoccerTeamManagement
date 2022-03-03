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
        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<State> States { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Lookups

            new CountryConfiguration().Configure(builder.Entity<Country>());
            new StateConfiguration().Configure(builder.Entity<State>());
            new PositionCategoryConfiguration().Configure(builder.Entity<PositionCategory>());
            new PositionConfiguration().Configure(builder.Entity<Position>());

            #endregion Lookups

            #region Entities

            new AddressConfiguration().Configure(builder.Entity<Address>());
            new ImageConfiguration().Configure(builder.Entity<Image>());
            new PhoneConfiguration().Configure(builder.Entity<Phone>());
            new ClubConfiguration().Configure(builder.Entity<Club>());
            new LeagueConfiguration().Configure(builder.Entity<League>());
            new TeamConfiguration().Configure(builder.Entity<Team>());
            new PlayerAttributesConfiguration().Configure(builder.Entity<PlayerAttributes>());
            new PlayerConfiguration().Configure(builder.Entity<Player>());
            new ParentConfiguration().Configure(builder.Entity<Parent>());

            #endregion Entities

            #region Joins

            new LeagueTeamConfiguration().Configure(builder.Entity<LeagueTeam>());
            new PlayerPositionConfiguration().Configure(builder.Entity<PlayerPosition>());
            new TeamPlayerConfiguration().Configure(builder.Entity<TeamPlayer>());
            new PlayerParentConfiguration().Configure(builder.Entity<PlayerParent>());

            #endregion Joins
        }
    }
}
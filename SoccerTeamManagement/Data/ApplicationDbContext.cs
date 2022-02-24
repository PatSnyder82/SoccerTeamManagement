using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SoccerTeamManagement.Data.Configuration;
using SoccerTeamManagement.Data.Configuration.Joins;
using SoccerTeamManagement.Data.Configuration.Lookups;
using SoccerTeamManagement.Data.Models;
using SoccerTeamManagement.Data.Models.Joins;

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

            new PositionCategoryLookupConfig().Configure(builder.Entity<PositionCategoryLookup>());
            new PositionLookupConfig().Configure(builder.Entity<PositionLookup>());
            new NationLookupConfig().Configure(builder.Entity<NationLookup>());

            #endregion Lookups

            new AddressConfig().Configure(builder.Entity<Address>());
            new ImageConfig().Configure(builder.Entity<Image>());
            new PhoneConfig().Configure(builder.Entity<Phone>());
            new ClubConfig().Configure(builder.Entity<Club>());
            new LeagueConfig().Configure(builder.Entity<League>());
            new TeamConfig().Configure(builder.Entity<Team>());
            new PlayerAttributesConfig().Configure(builder.Entity<PlayerAttributes>());
            new PlayerConfig().Configure(builder.Entity<Player>());
            new ParentConfig().Configure(builder.Entity<Parent>());

            #region Joins

            new LeagueTeamConfig().Configure(builder.Entity<LeagueTeam>());
            new PlayerPositionConfig().Configure(builder.Entity<PlayerPosition>());
            new TeamPlayerConfig().Configure(builder.Entity<TeamPlayer>());
            new PlayerParentConfig().Configure(builder.Entity<PlayerParent>());

            #endregion Joins
        }
    }
}
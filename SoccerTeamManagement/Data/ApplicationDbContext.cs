using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SoccerTeamManagement.Data.Configuration;
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
            new AddressConfig().Configure(builder.Entity<Address>());
            new LeagueConfig().Configure(builder.Entity<League>());
            new PhoneConfig().Configure(builder.Entity<Phone>());
            new PlayerAttributesConfig().Configure(builder.Entity<PlayerAttributes>());
            new PlayerConfig().Configure(builder.Entity<Player>());
            new PlayerPositionConfig().Configure(builder.Entity<PlayerPosition>());
            new PlayerTeamConfig().Configure(builder.Entity<PlayerTeam>());
            new TeamConfig().Configure(builder.Entity<Team>());
            new ParentConfig().Configure(builder.Entity<Parent>());
            new PlayerParentConfig().Configure(builder.Entity<PlayerParent>());
            new ImageConfig().Configure(builder.Entity<Image>());
        }
    }
}
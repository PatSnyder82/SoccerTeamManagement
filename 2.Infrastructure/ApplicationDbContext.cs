using Core.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Infrastructure.Configuration;
using Core.Models.Lookups;
using Infrastructure.Configuration.Lookups;
using Infrastructure.Identity;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<ClubLeague> ClubLeagues { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<League> Leagues { get; set; }

        public DbSet<LeagueTeam> LeagueTeams { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerPosition> PlayerPositions { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<TeamPlayer> TeamPlayers { get; set; }

        public ApplicationDbContext() {}

        public ApplicationDbContext(
            DbContextOptions options) : base (options)
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
            new ClubLeagueConfiguration().Configure(builder.Entity<ClubLeague>());
            new PlayerPositionConfiguration().Configure(builder.Entity<PlayerPosition>());
            new TeamPlayerConfiguration().Configure(builder.Entity<TeamPlayer>());
            new PlayerParentConfiguration().Configure(builder.Entity<PlayerParent>());

            #endregion Joins
        }
    }
}
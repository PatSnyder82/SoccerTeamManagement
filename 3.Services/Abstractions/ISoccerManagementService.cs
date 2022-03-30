using System;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ISoccerManagementService : IAsyncDisposable
    {
        #region Properties

        public IAddressService Addresses { get; }

        public IClubService Clubs { get; }

        public ICountryService Countries { get; }

        public ILeagueService Leagues { get; }

        public IPlayerService Players { get; }

        public IPositionService Positions { get; }

        public IStateService States { get; }

        public ITeamService Teams { get; }

        public ITeamPlayerService TeamPlayers { get; }

        #endregion Properties

        public Task<bool> SaveChangesAsync();
    }
}
using Infrastructure;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using System;
using System.Threading.Tasks;

namespace Services.Services
{
    public class SoccerManagementService : ISoccerManagementService, IAsyncDisposable
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger _logger;

        public IAddressService Addresses { get; private set; }

        public IClubService Clubs { get; private set; }

        public ICountryService Countries { get; private set; }

        public ILeagueService Leagues { get; private set; }

        public IPlayerService Players { get; private set; }

        public IPositionService Positions { get; private set; }

        public IStateService States { get; private set; }

        public ITeamService Teams { get; private set; }

        public ITeamPlayerService TeamPlayers { get; private set; }

        public SoccerManagementService(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Addresses = new AddressService(_context, _logger);
            Clubs = new ClubService(_context, _logger);
            Countries = new CountryService(_context, _logger);
            Leagues = new LeagueService(_context, _logger);
            Players = new PlayerService(_context, _logger);
            Positions = new PositionService(_context, _logger);
            States = new StateService(_context, _logger);
            Teams = new TeamService(_context, _logger);
            TeamPlayers = new TeamPlayerService(_context, _logger);
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception exception)
            {
                LogError(exception, "SaveChangesAsync");
                return false;
            }
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        protected virtual void LogError(Exception exception, string method)
        {
            string type = typeof(SoccerManagementService).ToString();
            _logger.LogError(exception, "{type} {method} method error");
        }
    }
}
using Core.Models;
using Infrastructure;
using Microsoft.Extensions.Logging;
using Services.Abstractions;

namespace Services.Services
{
    public class LeagueService : EntityServiceBase<League>, ILeagueService
    {
        #region Constructor

        public LeagueService(ApplicationDbContext context, ILogger logger)
            : base(context, logger)
        {
        }

        #endregion Constructor
    }
}
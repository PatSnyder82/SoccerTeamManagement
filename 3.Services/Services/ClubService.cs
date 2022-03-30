using Core.Models;
using Core.Models.Lookups;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ClubService : EntityServiceBase<Club>, IClubService
    {
        #region Constructor

        public ClubService(ApplicationDbContext context, ILogger logger)
            : base(context, logger)
        {
        }

        #endregion Constructor

        #region Methods

        public async Task<IEnumerable<Club>> GetByLeagueId(int leagueId)
        {
            try
            {
                var entity = await _set.SelectMany(x => x.ClubLeagues).Where(x => x.LeagueId == leagueId).Select(x => x.Club).OrderBy(x => x.Name).ToListAsync();

                if (entity != null)
                    return entity;

                return null;
            }
            catch (Exception exception)
            {
                LogError(exception, "GetByLeagueId");
                return null;
            }
        }

        #endregion Methods
    }
}
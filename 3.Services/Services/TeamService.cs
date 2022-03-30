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
    public class TeamService : EntityServiceBase<Team>, ITeamService
    {
        #region Constructor

        public TeamService(ApplicationDbContext context, ILogger logger)
            : base(context, logger)
        {
        }

        #endregion Constructor

        #region Methods

        public async Task<IEnumerable<Team>> GetByClubId(int clubId)
        {
            try
            {
                var entity = await _set.AsNoTracking().Where(x => x.ClubId == clubId).OrderBy(x => x.Name).ToListAsync();

                if (entity != null)
                    return entity;

                return null;
            }
            catch (Exception exception)
            {
                LogError(exception, "GetByClubId");
                return null;
            }
        }

        public async Task<IEnumerable<Team>> GetByLeagueId(int leagueId)
        {
            try
            {
                var entity = await _set.AsNoTracking().SelectMany(x => x.LeagueTeams).Where(x => x.LeagueId == leagueId).Select(x => x.Team).OrderBy(x => x.Name).ToListAsync();

                if (entity != null)
                    return entity;

                return null;
            }
            catch (Exception exception)
            {
                LogError(exception, "GetByClubId");
                return null;
            }
        }

        //public async Task<bool> DeletePlayerFromTeam(int playerId, int teamId)
        //{
        //    try
        //    {
        //        if (playerId < 1 || teamId < 1)
        //            return false;

        //        var teamPlayers = _context.Set<TeamPlayer>();

        //        var entity = await teamPlayers.FirstOrDefaultAsync(x => x.TeamId == teamId && x.PlayerId == playerId);

        //        if (entity != null)
        //        {
        //            teamPlayers.Remove(entity);
        //            return true;
        //        }

        //        return false;
        //    }
        //    catch (Exception exception)
        //    {
        //        LogError(exception, "DeletePlayer");
        //        return false;
        //    }
        //}

        #endregion Methods
    }
}
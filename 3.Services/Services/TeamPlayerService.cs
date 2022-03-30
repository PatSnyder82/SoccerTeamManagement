using Core.Models;
using Core.Models.Lookups;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TeamPlayerService : ServiceBase<TeamPlayer>, ITeamPlayerService
    {
        #region Constructor

        public TeamPlayerService(ApplicationDbContext context, ILogger logger)
            : base(context, logger)
        {
        }

        #endregion Constructor

        #region Methods

        public async Task<bool> Delete(int teamId, int playerId)
        {
            try
            {
                var entity = await GetById(teamId, playerId);

                if (entity != null)
                {
                    _set.Remove(entity);
                    return true;
                }

                return false;
            }
            catch (Exception exception)
            {
                LogError(exception, "Delete");
                return false;
            }
        }

        public virtual async Task<TeamPlayer> GetById(int teamId, int playerId)
        {
            try
            {
                if (playerId < 1 || teamId < 1)
                    return null;

                return await _set.FirstOrDefaultAsync(x => x.TeamId == teamId && x.PlayerId == playerId);
            }
            catch (Exception exception)
            {
                LogError(exception, "GetById");
                return null;
            }
        }

        public virtual async Task<bool> Upsert(TeamPlayer entity)
        {
            try
            {
                var existingEntity = await GetById(entity.TeamId, entity.PlayerId);

                if (existingEntity == null)
                    return await Create(entity);

                existingEntity = entity;

                _context.Entry(existingEntity).State = EntityState.Modified;
                _context.Update(existingEntity);

                return true;
            }
            catch (Exception exception)
            {
                LogError(exception, "Upsert");
                return false;
            }
        }

        #endregion Methods
    }
}
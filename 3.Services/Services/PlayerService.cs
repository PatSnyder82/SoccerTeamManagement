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
    public class PlayerService : EntityServiceBase<Player>, IPlayerService
    {
        #region Constructor

        public PlayerService(ApplicationDbContext context, ILogger logger)
            : base(context, logger)
        {
        }

        #endregion Constructor

        #region Methods

        public override async Task<Player> GetById(int id)
        {
            try
            {
                if (id < 1)
                    return null;

                return await _set.Where(x => x.Id == id).AsNoTracking()
                    .Include(x => x.Country)
                    .Include(x => x.Phone)
                    .Include(x => x.PlayerPositions).ThenInclude(x => x.Position).ThenInclude(x => x.PositionCategory)
                    .Include(x => x.TeamPlayers).ThenInclude(x => x.Team)
                    .Include(x => x.Address).ThenInclude(x => x.State)
                    .Include(x => x.Address).ThenInclude(x => x.Country).FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception exception)
            {
                LogError(exception, "GetById");
                return null;
            }
        }

        public override async Task<bool> Upsert(Player entity)
        {
            try
            {
                var existingEntity = await _set.AsNoTracking().Include(x => x.PlayerPositions).AsNoTracking()
                    .Include(x => x.TeamPlayers).AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);

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
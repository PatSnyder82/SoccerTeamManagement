using Core.Abstractions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public class EntityServiceBase<T> : ServiceBase<T>, IEntityServiceBase<T> where T : EntityBase
    {
        #region Constructor

        public EntityServiceBase(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        #endregion Constructor

        #region Virtual Methods

        public virtual async Task<bool> Delete(int id)
        {
            try
            {
                if (id < 1)
                    return false;

                var entity = await _set.Where(x => x.Id == id).FirstOrDefaultAsync();

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

        public virtual async Task<T> GetById(int id)
        {
            try
            {
                if (id < 1)
                    return null;

                return await _set.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception exception)
            {
                LogError(exception, "GetById");
                return null;
            }
        }

        public virtual async Task<bool> Upsert(T entity)
        {
            try
            {
                var existingEntity = await _set.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

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

        #endregion Virtual Methods
    }
}
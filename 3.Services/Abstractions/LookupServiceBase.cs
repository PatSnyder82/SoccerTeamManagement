using Core.Abstractions;
using Core.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public class LookupServiceBase<T> : EntityServiceBase<T>, ILookupServiceBase<T> where T : LookupBase
    {
        #region Constructor

        public LookupServiceBase(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        #endregion Constructor

        #region Virtual Methods

        public override async Task<IEnumerable<T>> GetAll(string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null)
        {
            try
            {
                var entities = _set.OrderBy(x => x.SortOrder).AsQueryable<T>();

                entities = Sort(entities, sortColumn, sortOrder);

                entities = Filter(entities, filterColumn, filterQuery);

                return await entities.AsNoTracking().ToListAsync();
            }
            catch (Exception exception)
            {
                LogError(exception, "GetAll");
                return null;
            }
        }

        public override async Task<Table<T>> GetTable(int pageIndex, int pageSize, string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null)
        {
            IQueryable<T> entities = _set.OrderBy(x => x.SortOrder).AsQueryable();

            entities = Filter(entities, filterColumn, filterQuery);

            var totalCount = await entities.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            entities = Sort(entities, sortColumn, sortOrder);

            entities = Paginate(entities, pageIndex, pageSize);

            var data = await entities.AsNoTracking().ToListAsync();

            return new Table<T>
            {
                Data = data,
                FilterColumn = filterColumn,
                FilterQuery = filterQuery,
                PageIndex = pageIndex,
                PageSize = pageSize,
                SortColumn = sortColumn,
                SortOrder = sortOrder,
                TotalCount = totalCount,
                TotalPages = totalPages
            };
        }

        #endregion Virtual Methods
    }
}
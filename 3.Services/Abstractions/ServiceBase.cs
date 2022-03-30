using Core.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : class
    {
        #region Properties

        protected ApplicationDbContext _context;

        protected DbSet<T> _set;

        protected readonly ILogger _logger;

        #endregion Properties

        #region Constructor

        public ServiceBase(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            _set = context.Set<T>();
        }

        #endregion Constructor

        #region Virtual Methods

        public virtual async Task<bool> Create(T entity)
        {
            try
            {
                if (entity == null)
                    return false;

                await _set.AddAsync(entity);
                return true;
            }
            catch (Exception exception)
            {
                LogError(exception, "Create");
                return false;
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll(string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null)
        {
            try
            {
                var entities = _set.AsQueryable<T>();

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

        public virtual async Task<Table<T>> GetTable(int pageIndex, int pageSize, string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null)
        {
            IQueryable<T> entities = _set.AsQueryable();

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

        protected virtual void LogError(Exception exception, string method)
        {
            string type = typeof(T).ToString();
            _logger.LogError(exception, "{type} {method} method error");
        }

        #endregion Virtual Methods

        #region Methods

        protected bool IsValidProperty(string propertyName, bool throwExceptionIfNotFound = true)
        {
            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            if (property == null && throwExceptionIfNotFound)
                throw new NotSupportedException(string.Format("ERROR: Property '{0}' does not exist.", propertyName));

            return property != null;
        }

        protected virtual IQueryable<T> Filter(IQueryable<T> entities, string column, string query)
        {
            if (!string.IsNullOrEmpty(column) && !string.IsNullOrEmpty(query) && IsValidProperty(column))
            {
                entities = entities.Where(string.Format("{0}.Contains(@0)", column), query);
            }

            return entities;
        }

        protected virtual IQueryable<T> Paginate(IQueryable<T> entities, int pageIndex, int pageSize)
        {
            return entities.Skip(pageIndex * pageSize).Take(pageSize);
        }

        protected virtual IQueryable<T> Sort(IQueryable<T> entities, string column, string order)
        {
            if (!string.IsNullOrEmpty(column) && !string.IsNullOrEmpty(order) && IsValidProperty(column))
            {
                order = !string.IsNullOrEmpty(order) && order.ToUpper() == "ASC" ? "ASC" : "DESC";
                entities = entities.OrderBy(string.Format("{0} {1}", column, order));
            }

            return entities;
        }

        #endregion Methods
    }
}
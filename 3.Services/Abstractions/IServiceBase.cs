using Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IServiceBase<T> where T : class
    {
        Task<bool> Create(T entity);

        Task<IEnumerable<T>> GetAll(string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null);

        Task<Table<T>> GetTable(int pageIndex = 0, int pageSize = 10, string sortColumn = null, string sortOrder = null, string filterColumn = null, string filterQuery = null);
    }
}
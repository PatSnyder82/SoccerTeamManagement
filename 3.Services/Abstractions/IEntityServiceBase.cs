using Core.Abstractions;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IEntityServiceBase<T> : IServiceBase<T> where T : EntityBase
    {
        Task<bool> Delete(int id);

        Task<T> GetById(int id);

        Task<bool> Upsert(T entity);
    }
}
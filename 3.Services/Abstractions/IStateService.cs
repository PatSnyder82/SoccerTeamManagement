using Core.Models.Lookups;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IStateService : IEntityServiceBase<State>
    {
        public Task<IEnumerable<State>> GetByCountryId(int countryId);
    }
}
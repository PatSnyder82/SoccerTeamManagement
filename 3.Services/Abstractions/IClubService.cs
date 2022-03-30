using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IClubService : IEntityServiceBase<Club>
    {
        public Task<IEnumerable<Club>> GetByLeagueId(int clubId);
    }
}
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ITeamService : IEntityServiceBase<Team>
    {
        public Task<IEnumerable<Team>> GetByClubId(int clubId);

        public Task<IEnumerable<Team>> GetByLeagueId(int leagueId);
    }
}
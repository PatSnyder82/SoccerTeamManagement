using Core.Models;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ITeamPlayerService : IServiceBase<TeamPlayer>
    {
        public Task<bool> Delete(int teamId, int playerId);

        public Task<TeamPlayer> GetById(int teamId, int playerId);

        public Task<bool> Upsert(TeamPlayer entity);
    }
}
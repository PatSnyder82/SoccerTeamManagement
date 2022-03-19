using SoccerTeamManagement.Data.Interfaces;

namespace SoccerTeamManagement.Data.Models
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
    }
}
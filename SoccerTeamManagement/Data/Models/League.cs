using SoccerTeamManagement.Data.Models.Joins;
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.Models
{
    public class League : EntityBase
    {
        public string Name { get; set; }

        /// TODO: Relationship Managers/Coaches

        #region Relationships

        public int? ImageId { get; set; }

        public Image Image { get; set; }

        public ICollection<LeagueTeam> LeagueTeams { get; set; }

        #endregion Relationships
    }
}
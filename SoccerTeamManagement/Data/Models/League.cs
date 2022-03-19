using SoccerTeamManagement.Data.Models.Joins;
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.Models
{
    public class League : EntityBase
    {
        #region Properties

        public string Name { get; set; }

        #endregion Properties

        /// TODO: Relationship Managers/Coaches

        #region Relationships

        public int? LogoId { get; set; }

        public Image Logo { get; set; }

        public ICollection<LeagueTeam> LeagueTeams { get; set; }

        #endregion Relationships
    }
}
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.Models
{
    public class Club : EntityBase
    {
        public string Name { get; set; }

        /// TODO: Logo
        /// TODO: Relationship Managers/Coaches

        #region Relationships

        public ICollection<Team> Teams { get; set; }

        #endregion Relationships
    }
}
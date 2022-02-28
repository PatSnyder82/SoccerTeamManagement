using System.Collections.Generic;

namespace SoccerTeamManagement.Data.Models
{
    public class Club : EntityBase
    {
        public string Name { get; set; }

        /// TODO: Relationship Managers/Coaches

        #region Relationships

        public int? ImageId { get; set; }

        public Image Logo { get; set; }

        public ICollection<Team> Teams { get; set; }

        #endregion Relationships
    }
}
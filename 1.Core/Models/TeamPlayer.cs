using System;

namespace Core.Models
{
    public class TeamPlayer
    {
        #region Relationships

        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public DateTimeOffset? JoinedTeam { get; set; }

        public DateTimeOffset? DepartedTeam { get; set; }

        #endregion Relationships
    }
}
using System;

namespace SoccerTeamManagement.Data.Models.Joins
{
    public class LeagueTeam
    {
        #region Relationships

        public int LeagueId { get; set; }

        public League League { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public bool IsPrimary { get; set; }

        #endregion Relationships
    }
}
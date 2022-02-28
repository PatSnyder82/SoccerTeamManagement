﻿using SoccerTeamManagement.Data.Models.People;

namespace SoccerTeamManagement.Data.Models.Joins
{
    public class PlayerPosition
    {
        #region Relationships

        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int PositionId { get; set; }

        public PositionLookup Position { get; set; }

        public bool IsPrimary { get; set; }

        #endregion Relationships
    }
}
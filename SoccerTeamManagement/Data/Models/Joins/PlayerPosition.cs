using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
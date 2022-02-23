using SoccerTeamManagement.Data.Models.Joins;
using SoccerTeamManagement.Data.Models.Lookups;
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.Models
{
    public class PositionLookup : LookupBase
    {
        #region Properties

        public string Abbreviation { get; set; }

        #endregion Properties

        #region Relationships

        public ICollection<PlayerPosition> PlayerPositions { get; set; }

        public int? PositionCategoryId { get; set; }

        public PositionCategoryLookup PositionCategory { get; set; }

        #endregion Relationships
    }
}
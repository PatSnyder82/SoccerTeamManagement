using SoccerTeamManagement.Data.Models.Lookups;
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.Models
{
    public class PositionCategory : LookupBase
    {
        #region Relationships

        public ICollection<Position> Positions { get; set; }

        #endregion Relationships
    }
}
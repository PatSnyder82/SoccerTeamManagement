using Core.Abstractions;
using System.Collections.Generic;

namespace Core.Models.Lookups
{
    public class Position : LookupBase
    {
        #region Properties

        public string Abbreviation { get; set; }

        #endregion Properties

        #region Relationships

        public ICollection<PlayerPosition> PlayerPositions { get; set; }

        public int? PositionCategoryId { get; set; }

        public PositionCategory PositionCategory { get; set; }

        #endregion Relationships
    }
}
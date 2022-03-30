using Core.Abstractions;
using System.Collections.Generic;

namespace Core.Models.Lookups
{
    public class PositionCategory : LookupBase
    {
        #region Relationships

        public IList<Position> Positions { get; set; }

        #endregion Relationships
    }
}
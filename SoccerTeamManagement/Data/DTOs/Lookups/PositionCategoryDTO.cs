using System.Collections.Generic;

namespace SoccerTeamManagement.Data.DTOs.Lookups
{
    public class PositionCategoryDTO : LookupBaseDTO
    {
        #region Relationships

        public IList<PlayerPositionDTO> Positions { get; set; }

        #endregion Relationships
    }
}
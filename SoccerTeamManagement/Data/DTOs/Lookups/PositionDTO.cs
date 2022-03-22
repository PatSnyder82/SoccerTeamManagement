namespace SoccerTeamManagement.Data.DTOs.Lookups
{
    public class PositionDTO : LookupBaseDTO
    {
        #region Properties

        public string Abbreviation { get; set; }

        #endregion Properties

        #region Relationships

        public int? PositionCategoryId { get; set; }

        #endregion Relationships
    }
}
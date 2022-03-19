namespace SoccerTeamManagement.Data.DTOs.Lookups
{
    public class PlayerPositionDTO : LookupBaseDTO
    {
        #region Properties

        public string Abbreviation { get; set; }

        #endregion Properties

        #region Relationships

        public int? PositionCategoryId { get; set; }

        #endregion Relationships
    }
}
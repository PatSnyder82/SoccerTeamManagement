namespace SoccerTeamManagement.Data.DTOs.Lookups
{
    public class PositionListDTO : ListLookupBaseDTO
    {
        #region Properties

        public string Abbreviation { get; set; }

        public bool IsPrimary { get; set; }

        public string Category { get; set; }

        #endregion Properties

        #region Relationships

        public int? PositionCategoryId { get; set; }

        #endregion Relationships
    }
}
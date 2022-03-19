namespace SoccerTeamManagement.Data.DTOs.Lookups
{
    public class PlayerPositionFlatDTO
    {
        #region Properties

        public string Abbreviation { get; set; }

        public bool IsPrimary { get; set; }

        public string Category { get; set; }

        #endregion Properties

        #region Relationships

        public int PlayerId { get; set; }

        public int? PositionCategoryId { get; set; }

        public int PositionId { get; set; }

        public PositionFlatDTO Position { get; set; }

        #endregion Relationships
    }
}
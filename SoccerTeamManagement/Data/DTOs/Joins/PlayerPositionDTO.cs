using SoccerTeamManagement.Data.DTOs.Lookups;

namespace SoccerTeamManagement.Data.DTOs.Joins
{
    public class PlayerPositionDTO
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

        public PositionDetailsDTO Position { get; set; }

        #endregion Relationships
    }
}
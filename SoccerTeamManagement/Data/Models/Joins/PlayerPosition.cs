using SoccerTeamManagement.Data.Models.People;

namespace SoccerTeamManagement.Data.Models.Joins
{
    public class PlayerPosition
    {
        #region Properties

        public bool IsPrimary { get; set; }

        #endregion Properties

        #region Relationships

        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

        #endregion Relationships
    }
}
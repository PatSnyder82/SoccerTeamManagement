using Core.Models.Lookups;

namespace Core.Models
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
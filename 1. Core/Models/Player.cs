using Core.Enumerations;
using System.Collections.Generic;

namespace Core.Models
{
    public class Player : PersonBase
    {
        #region Properties

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public Enums.Foot Foot { get; set; }

        public Enums.StarRating WeakFootRating { get; set; }

        public Enums.StarRating FlareRating { get; set; }

        #endregion Properties

        #region Relationships

        public int? AttributesId { get; set; }

        public PlayerAttributes Attributes { get; set; }

        public ICollection<PlayerPosition> PlayerPositions { get; set; }

        public ICollection<TeamPlayer> TeamPlayers { get; set; }

        public ICollection<PlayerParent> PlayerParents { get; set; }

        #endregion Relationships
    }
}
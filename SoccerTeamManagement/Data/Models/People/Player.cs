using SoccerTeamManagement.Data.Models.Joins;
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.Models.People
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
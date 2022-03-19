using SoccerTeamManagement.Data.DTOs.Lookups;
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.DTOs.People
{
    public class PlayerDTO : PersonBaseDTO
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

        public PlayerAttributesDTO Attributes { get; set; }

        public IList<PlayerPositionFlatDTO> PlayerPositions { get; set; }

        public IList<TeamDTO> Teams { get; set; }

        public IList<ParentDTO> Parents { get; set; }

        #endregion Relationships
    }
}
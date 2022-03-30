using Core.Enumerations;
using SoccerTeamManagement.Data.DTOs.Joins;
using SoccerTeamManagement.Data.Models.Joins;
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.DTOs.People
{
    public class PlayerDetailsDTO : PersonDetailsBaseDTO
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

        public PlayerAttributesDetailsDTO Attributes { get; set; }

        public IList<PlayerPositionDetailsDTO> PlayerPositions { get; set; }

        public IList<TeamPlayerDetailsDTO> TeamPlayers { get; set; }

        public IList<ParentDetailsDTO> Parents { get; set; }

        #endregion Relationships
    }
}
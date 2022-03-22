using Core.Enumerations;
using SoccerTeamManagement.Data.DTOs.Joins;
using SoccerTeamManagement.Data.DTOs.Lookups;
using SoccerTeamManagement.Data.Models.Joins;
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.DTOs.People
{
    public class PlayerDetailsDTO : PersonFlatBaseDTO
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

        public IList<PlayerPositionDTO> PlayerPositions { get; set; }

        public IList<TeamPlayerDTO> TeamPlayers { get; set; }

        public IList<ParentFlatDTO> Parents { get; set; }

        #endregion Relationships
    }
}
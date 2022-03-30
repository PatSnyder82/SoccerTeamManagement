using System.Collections.Generic;

namespace SoccerTeamManagement.Data.DTOs
{
    public class ClubDetailsDTO : DetailsBaseDTO
    {
        #region Properties

        public string Name { get; set; }

        #endregion Properties

        /// TODO: Relationship Managers/Coaches

        #region Relationships

        public int? ImageId { get; set; }

        public ImageDTO Logo { get; set; }

        public IList<TeamDetailsDTO> Teams { get; set; }

        #endregion Relationships
    }
}
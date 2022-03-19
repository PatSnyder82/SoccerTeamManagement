using System.Collections.Generic;

namespace SoccerTeamManagement.Data.DTOs
{
    public class ClubFlatDTO : EntityBaseDTO
    {
        #region Properties

        public string Name { get; set; }

        #endregion Properties

        /// TODO: Relationship Managers/Coaches

        #region Relationships

        public int? ImageId { get; set; }

        public ImageDTO Logo { get; set; }

        public IList<TeamFlatDTO> Teams { get; set; }

        #endregion Relationships
    }
}
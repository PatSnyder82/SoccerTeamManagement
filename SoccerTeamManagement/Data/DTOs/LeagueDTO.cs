using System.Collections.Generic;

namespace SoccerTeamManagement.Data.DTOs
{
    public class LeagueDTO : EntityBaseDTO
    {
        #region Properties

        public string Name { get; set; }

        #endregion Properties

        /// TODO: Relationship Managers/Coaches

        #region Relationships

        public int? LogoId { get; set; }

        public ImageDTO Logo { get; set; }

        public IList<TeamDTO> Teams { get; set; }

        #endregion Relationships
    }
}
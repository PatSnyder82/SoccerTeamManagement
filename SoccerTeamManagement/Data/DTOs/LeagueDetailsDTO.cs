using System.Collections.Generic;

namespace SoccerTeamManagement.Data.DTOs
{
    public class LeagueDetailsDTO : EntityBaseDTO
    {
        #region Properties

        public string Name { get; set; }

        #endregion Properties

        #region Relationships

        public int? LogoId { get; set; }

        public ImageDTO Logo { get; set; }

        #endregion Relationships
    }
}
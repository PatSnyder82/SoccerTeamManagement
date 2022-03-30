using System.Collections.Generic;

namespace SoccerTeamManagement.Data.DTOs
{
    public class TeamDetailsDTO : DetailsBaseDTO
    {
        #region Properties

        public string Name { get; set; }

        #endregion Properties

        #region Relationships

        public int? LogoId { get; set; }

        public ImageDTO Logo { get; set; }

        public int? ClubId { get; set; }

        public IList<LeagueDetailsDTO> Leagues { get; set; }

        #endregion Relationships
    }
}
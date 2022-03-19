using SoccerTeamManagement.Data.DTOs.People;
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.DTOs
{
    public class TeamFlatDTO : EntityBaseDTO
    {
        #region Properties

        public string Name { get; set; }

        #endregion Properties

        #region Relationships

        public int? LogoId { get; set; }

        public ImageDTO Logo { get; set; }

        public int? ClubId { get; set; }

        public IList<LeagueFlatDTO> Leagues { get; set; }

        #endregion Relationships
    }
}
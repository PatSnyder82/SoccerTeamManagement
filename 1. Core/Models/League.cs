using Core.Abstractions;
using System.Collections.Generic;

namespace Core.Models
{
    public class League : EntityBase
    {
        #region Properties

        public string Name { get; set; }

        #endregion Properties

        /// TODO: Relationship Managers/Coaches

        #region Relationships

        public ICollection<ClubLeague> ClubLeagues { get; set; }

        public int? LogoId { get; set; }

        public Image Logo { get; set; }

        public ICollection<LeagueTeam> LeagueTeams { get; set; }

        #endregion Relationships
    }
}
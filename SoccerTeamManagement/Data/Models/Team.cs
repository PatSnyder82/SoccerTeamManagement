using SoccerTeamManagement.Data.Models.Joins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Data.Models
{
    public class Team : EntityBase
    {
        #region Properties

        public string Name { get; set; }

        ///TODO: Create LOGO Entity
        ///

        ///TODO: Create Transfers
        ///

        #endregion Properties

        #region Relationships

        public int? ClubId { get; set; }

        public Club Club { get; set; }

        public ICollection<LeagueTeam> LeagueTeams { get; set; }

        public ICollection<TeamPlayer> TeamPlayers { get; set; }

        #endregion Relationships
    }
}
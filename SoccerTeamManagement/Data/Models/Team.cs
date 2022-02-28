using SoccerTeamManagement.Data.Models.Joins;
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.Models
{
    public class Team : EntityBase
    {
        #region Properties

        public string Name { get; set; }

        ///TODO: Create Transfers
        ///

        #endregion Properties

        #region Relationships

        public int? ImageId { get; set; }

        public Image Image { get; set; }

        public int? ClubId { get; set; }

        public Club Club { get; set; }

        public ICollection<LeagueTeam> LeagueTeams { get; set; }

        public ICollection<TeamPlayer> TeamPlayers { get; set; }

        #endregion Relationships
    }
}
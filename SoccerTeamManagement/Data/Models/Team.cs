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

        public int? LeagueId { get; set; }

        public League League { get; set; }

        public ICollection<Player> Players { get; set; }

        #endregion Relationships
    }
}
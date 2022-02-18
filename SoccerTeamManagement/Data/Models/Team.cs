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

        ///TODO: Create Positions
        ///

        ///TODO: Create Club
        ///

        ///TODO: Create Transfers
        ///

        #endregion Properties

        #region Relationships

        public ICollection<Team> Teams { get; set; }

        #endregion Relationships
    }
}
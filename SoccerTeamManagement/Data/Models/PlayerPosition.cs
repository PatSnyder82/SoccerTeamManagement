using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Data.Models
{
    public class PlayerPosition
    {
        #region Properties

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        #endregion Properties

        #region Relationships

        public PositionCategory PositionCategory { get; set; }

        #endregion Relationships
    }
}
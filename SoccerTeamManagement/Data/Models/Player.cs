using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Data.Models
{
    public class Player : EntityBase
    {
        #region Properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        #endregion Properties

        #region Relationships

        public int? NationId { get; set; }

        public Nation Nation { get; set; }

        public int? PlayerAttributesId { get; set; }

        public PlayerAttributes Attributes { get; set; }

        public int? PlayerPositionId { get; set; }

        public PlayerPosition PrimaryPosition { get; set; }

        public ICollection<PlayerPosition> SecondaryPositions { get; set; }

        public ICollection<Team> Teams { get; set; }

        #endregion Relationships
    }
}
using SoccerTeamManagement.Data.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Data.Models.Joins
{
    public class PlayerParent
    {
        #region Relationships

        public int PlayerId { get; set; }

        public Player Player { get; set; }

        public int ParentId { get; set; }

        public Parent Parent { get; set; }

        #endregion Relationships
    }
}
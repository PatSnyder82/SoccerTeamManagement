using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Data.Models
{
    public class League : EntityBase
    {
        public string Name { get; set; }

        /// TODO: Logo

        #region Relationships

        public ICollection<Team> Teams { get; set; }

        #endregion Relationships
    }
}
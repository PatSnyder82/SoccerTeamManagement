using SoccerTeamManagement.Data.Models.Joins;
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.Models
{
    public class Parent : Person
    {
        #region Relationships

        public ICollection<PlayerParent> PlayerParents { get; set; }

        #endregion Relationships
    }
}
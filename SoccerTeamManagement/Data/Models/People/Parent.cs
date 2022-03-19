using SoccerTeamManagement.Data.Models.Joins;
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.Models.People
{
    public class Parent : PersonBase
    {
        #region Relationships

        public ICollection<PlayerParent> PlayerParents { get; set; }

        #endregion Relationships
    }
}
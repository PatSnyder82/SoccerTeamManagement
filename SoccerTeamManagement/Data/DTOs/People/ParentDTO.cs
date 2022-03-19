using SoccerTeamManagement.Data.Models.Joins;
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.DTOs.People
{
    public class ParentDTO : PersonBaseDTO
    {
        #region Relationships

        public IList<PlayerDTO> Players { get; set; }

        #endregion Relationships
    }
}
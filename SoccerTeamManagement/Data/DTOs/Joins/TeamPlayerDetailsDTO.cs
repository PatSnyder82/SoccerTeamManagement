using SoccerTeamManagement.Data.DTOs;
using System;

namespace SoccerTeamManagement.Data.Models.Joins
{
    public class TeamPlayerDetailsDTO : DetailsBaseDTO
    {
        #region Relationships

        public int PlayerId { get; set; }

        public int TeamId { get; set; }

        public TeamDetailsDTO Team { get; set; }

        public DateTimeOffset? JoinedTeam { get; set; }

        public DateTimeOffset? DepartedTeam { get; set; }

        #endregion Relationships
    }
}
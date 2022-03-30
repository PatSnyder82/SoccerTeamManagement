using SoccerTeamManagement.Data.DTOs.Lookups;
using System;

namespace SoccerTeamManagement.Data.DTOs.People
{
    public abstract class PersonListBaseDTO : ListBaseDTO
    {
        #region Properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        #endregion Properties
    }
}
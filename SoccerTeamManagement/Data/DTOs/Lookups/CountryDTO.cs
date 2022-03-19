using System.Collections.Generic;

namespace SoccerTeamManagement.Data.DTOs.Lookups
{
    public class CountryDTO : LookupBaseDTO
    {
        #region Properties

        public string Alpha2Code { get; set; }

        public string Alpha3Code { get; set; }

        #endregion Properties

        #region Relationships

        public IList<StateDTO> States { get; set; }

        #endregion Relationships
    }
}
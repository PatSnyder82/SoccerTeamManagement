using System.Collections.Generic;

namespace SoccerTeamManagement.Data.DTOs.Lookups
{
    public class CountryDetailsDTO : DetailsLookupBaseDTO
    {
        #region Properties

        public string Alpha2Code { get; set; }

        public string Alpha3Code { get; set; }

        #endregion Properties
    }
}
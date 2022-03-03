using SoccerTeamManagement.Data.Models.Lookups;
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.Models
{
    public class Country : LookupBase
    {
        #region Properties

        // ISO 3166 values

        public string Alpha2Code { get; set; }

        public string Alpha3Code { get; set; }

        #endregion Properties

        #region Relationships

        public ICollection<State> States { get; set; }

        #endregion Relationships
    }
}
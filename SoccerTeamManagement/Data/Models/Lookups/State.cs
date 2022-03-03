using SoccerTeamManagement.Data.Models.Lookups;

namespace SoccerTeamManagement.Data.Models
{
    public class State : LookupBase
    {
        #region Properties

        // ISO 3166 values

        public string Alpha2Code { get; set; }

        #endregion Properties

        #region Relationships

        public int? CountryId { get; set; }

        public Country Country { get; set; }

        #endregion Relationships
    }
}
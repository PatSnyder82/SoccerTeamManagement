using SoccerTeamManagement.Data.Models.Lookups;

namespace SoccerTeamManagement.Data.Models
{
    public class CountryLookup : LookupBase
    {
        // ISO 3166 values

        public string Alpha2Code { get; set; }

        public string Alpha3Code { get; set; }
    }
}
namespace SoccerTeamManagement.Data.DTOs.Lookups
{
    public class StateDetailsDTO : DetailsLookupBaseDTO
    {
        #region Properties

        public string Alpha2Code { get; set; }

        #endregion Properties

        #region Relationships

        public int? CountryId { get; set; }

        #endregion Relationships
    }
}
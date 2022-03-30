using SoccerTeamManagement.Data.DTOs.Lookups;

namespace SoccerTeamManagement.Data.DTOs
{
    public class AddressDetailsDTO : DetailsBaseDTO
    {
        #region Properties

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public int? CountryId { get; set; }

        public string CountryText { get; set; }

        public string CountryAlpha2Code { get; set; }

        public string ZipCode { get; set; }

        public int? StateId { get; set; }

        public string StateText { get; set; }

        public string StateAlpha2Code { get; set; }

        #endregion Properties
    }
}
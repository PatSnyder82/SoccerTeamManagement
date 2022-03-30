namespace SoccerTeamManagement.Data.DTOs
{
    public class AddressListDTO : ListBaseDTO
    {
        #region Properties

        public string AddressLine1 { get; set; }

        public string City { get; set; }

        public string CountryAlpha2Code { get; set; }

        public string CountryText { get; set; }

        public string StateAlpha2Code { get; set; }

        public string StateText { get; set; }

        #endregion Properties
    }
}
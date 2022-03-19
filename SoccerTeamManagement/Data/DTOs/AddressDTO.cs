using SoccerTeamManagement.Data.DTOs.Lookups;

namespace SoccerTeamManagement.Data.DTOs
{
    public class AddressDTO : EntityBaseDTO
    {
        #region Properties

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        #endregion Properties

        #region Relationships

        public int? CountryId { get; set; }

        public CountryDTO Country { get; set; }

        public int? StateId { get; set; }

        public StateDTO State { get; set; }

        #endregion Relationships
    }
}
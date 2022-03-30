using Core.Abstractions;
using Core.Models.Lookups;

namespace Core.Models
{
    public class Address : EntityBase
    {
        #region Properties

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        #endregion Properties

        #region Relationships

        public int? CountryId { get; set; }

        public Country Country { get; set; }

        public int? StateId { get; set; }

        public State State { get; set; }

        #endregion Relationships
    }
}
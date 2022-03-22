using Core.Abstractions;
using Core.Models.Lookups;
using System;

namespace Core.Models
{
    public abstract class PersonBase : EntityBase
    {
        #region Properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        #endregion Properties

        #region Relationships

        public int? PhoneId { get; set; }

        public Phone Phone { get; set; }

        public int? AddressId { get; set; }

        public Address Address { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }

        public int? CountryId { get; set; }

        public Country Country { get; set; }

        #endregion Relationships
    }
}
using SoccerTeamManagement.Data.DTOs.Lookups;
using System;

namespace SoccerTeamManagement.Data.DTOs.People
{
    public abstract class PersonBaseDTO : EntityBaseDTO
    {
        #region Properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        #endregion Properties

        #region Relationships

        public int? PhoneId { get; set; }

        public PhoneDTO Phone { get; set; }

        public int? AddressId { get; set; }

        public AddressDTO Address { get; set; }

        public int? ImageId { get; set; }

        public ImageDTO Image { get; set; }

        public int? CountryId { get; set; }

        public CountryDTO Country { get; set; }

        #endregion Relationships
    }
}
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.Models.People
{
    public abstract class Person : EntityBase
    {
        #region Properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public bool IsAdult { get; set; }

        #endregion Properties

        #region Relationships

        public int? PhoneId { get; set; }

        public Phone Phone { get; set; }

        public int? AddressId { get; set; }

        public Address Address { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }

        public int? NationId { get; set; }

        public CountryLookup Nation { get; set; }

        #endregion Relationships
    }
}
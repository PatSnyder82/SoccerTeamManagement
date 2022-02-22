namespace SoccerTeamManagement.Data.Models
{
    public class Address : EntityBase
    {
        #region Properties

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        #endregion Properties

        //#region Relationships

        //public int? PersonId { get; set; }

        //public Person Person { get; set; }

        //#endregion Relationships
    }
}
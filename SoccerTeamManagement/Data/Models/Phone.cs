namespace SoccerTeamManagement.Data.Models
{
    public class Phone : EntityBase
    {
        #region Properties

        public int AreaCode { get; set; }

        public int? Extension { get; set; }

        public int Number { get; set; }

        public Enums.PhoneType PhoneType { get; set; }

        #endregion Properties

        //#region Relationship

        //public int? PersonId { get; set; }

        //public Player Player { get; set; }

        //#endregion Relationship
    }
}
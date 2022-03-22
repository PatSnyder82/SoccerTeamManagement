using Core.Enumerations;

namespace SoccerTeamManagement.Data.DTOs
{
    public class PhoneDTO : EntityBaseDTO
    {
        #region Properties

        public string CountryCode { get; set; }

        public string AreaCode { get; set; }

        public string Extension { get; set; }

        public string Number { get; set; }

        public Enums.PhoneType PhoneType { get; set; }

        #endregion Properties
    }
}
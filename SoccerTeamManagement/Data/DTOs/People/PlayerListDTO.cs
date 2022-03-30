using Core.Enumerations;

namespace SoccerTeamManagement.Data.DTOs.People
{
    public class PlayerListDTO : PersonListBaseDTO
    {
        #region Properties

        public Enums.Foot Foot { get; set; }

        public Enums.StarRating WeakFootRating { get; set; }

        public Enums.StarRating FlareRating { get; set; }

        #endregion Properties
    }
}
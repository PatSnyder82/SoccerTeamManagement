namespace Core.Models
{
    public class ClubLeague
    {
        #region Relationships

        public int ClubId { get; set; }

        public Club Club { get; set; }

        public int LeagueId { get; set; }

        public League League { get; set; }

        #endregion Relationships
    }
}
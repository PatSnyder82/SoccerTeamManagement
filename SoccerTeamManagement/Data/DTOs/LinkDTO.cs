namespace SoccerTeamManagement.Data.DTOs
{
    public class LinkDTO : EntityBaseDTO
    {
        #region Properties

        public bool OpenNewWindow { get; set; }

        public string Text { get; set; }

        public string Url { get; set; }

        #endregion Properties
    }
}
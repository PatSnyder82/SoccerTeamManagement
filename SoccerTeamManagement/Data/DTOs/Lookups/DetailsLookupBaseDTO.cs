namespace SoccerTeamManagement.Data.DTOs.Lookups
{
    public abstract class DetailsLookupBaseDTO : DetailsBaseDTO
    {
        #region Properties

        public bool? IsDisabled { get; set; }

        public int? SortOrder { get; set; }

        public string Text { get; set; }

        public string Value { get; set; }

        #endregion Properties
    }
}
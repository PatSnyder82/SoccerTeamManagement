namespace Core.Abstractions
{
    internal interface ILookup
    {
        #region Properties

        string Text { get; set; }

        string Value { get; set; }

        int? SortOrder { get; set; }

        bool? IsDisabled { get; set; }

        #endregion Properties
    }
}
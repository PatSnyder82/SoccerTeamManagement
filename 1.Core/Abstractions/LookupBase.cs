using Core.Abstractions;

namespace Core.Abstractions
{
    public abstract class LookupBase : EntityBase, ILookup
    {
        #region ILookup Implementation

        public bool? IsDisabled { get; set; }

        public int? SortOrder { get; set; }

        public string Text { get; set; }

        public string Value { get; set; }

        #endregion ILookup Implementation
    }
}
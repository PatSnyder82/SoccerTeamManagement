using System.Collections.Generic;

namespace Core.Models
{
    public class Table<T>
    {
        #region Properties

        public List<T> Data { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return ((PageIndex + 1) < TotalPages);
            }
        }

        public string SortColumn { get; set; }

        public string SortOrder { get; set; }

        public string FilterColumn { get; set; }

        public string FilterQuery { get; set; }

        #endregion Properties
    }
}
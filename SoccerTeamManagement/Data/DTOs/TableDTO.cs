using System.Collections.Generic;

namespace SoccerTeamManagement.Data.DTOs
{
    public class TableDTO<T>
    {
        #region Properties

        public List<T> Data { get; private set; }

        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public int TotalCount { get; private set; }

        public int TotalPages { get; private set; }

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
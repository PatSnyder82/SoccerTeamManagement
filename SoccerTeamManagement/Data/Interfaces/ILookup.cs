using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Data.Interfaces
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
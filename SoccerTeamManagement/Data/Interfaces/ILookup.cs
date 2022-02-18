using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Data.Interfaces
{
    internal interface ILookup
    {
        #region Properties

        bool? IsDisabled { get; set; }

        int? SortOrder { get; set; }

        string Text { get; set; }

        string Value { get; set; }

        #endregion Properties
    }
}
using SoccerTeamManagement.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Data.Models.Lookups
{
    public abstract class LookupBase : ILookup, IEntity
    {
        #region ILookup Implementation

        public bool? IsDisabled { get; set; }

        public int? SortOrder { get; set; }

        public string Text { get; set; }

        public string Value { get; set; }

        #endregion ILookup Implementation

        #region IEntity Implementation

        public int Id { get; set; }

        #endregion IEntity Implementation
    }
}
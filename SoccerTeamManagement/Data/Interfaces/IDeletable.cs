using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Data.Interfaces
{
    internal interface IDeletable
    {
        #region Properties

        DateTimeOffset? DateDeleted { get; set; }

        string DeletedBy { get; set; }

        #endregion Properties
    }
}
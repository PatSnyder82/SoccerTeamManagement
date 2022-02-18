using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Data.Interfaces
{
    internal interface IArchivable
    {
        #region Properties

        string ArchivedBy { get; set; }

        DateTimeOffset? DateArchived { get; set; }

        #endregion Properties
    }
}
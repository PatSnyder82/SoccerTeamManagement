using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Data.Interfaces
{
    internal interface ICreatable
    {
        #region Properties

        DateTimeOffset? DateCreated { get; set; }

        string CreatedBy { get; set; }

        #endregion Properties
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Data.Interfaces
{
    internal interface IUpdatable
    {
        public interface IUpdatable
        {
            #region Properties

            string UpdatedBy { get; set; }

            DateTimeOffset? DateUpdated { get; set; }

            #endregion Properties
        }
    }
}
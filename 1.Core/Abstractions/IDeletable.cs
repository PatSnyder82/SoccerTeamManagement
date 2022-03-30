using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Abstractions
{
    internal interface IDeletable
    {
        #region Properties

        DateTimeOffset? DateDeleted { get; set; }

        string DeletedBy { get; set; }

        #endregion Properties
    }
}
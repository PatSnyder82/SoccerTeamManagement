using System;

namespace Core.Abstractions
{
    internal interface IArchivable
    {
        #region Properties

        string ArchivedBy { get; set; }

        DateTimeOffset? DateArchived { get; set; }

        #endregion Properties
    }
}
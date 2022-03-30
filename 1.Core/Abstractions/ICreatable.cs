using System;

namespace Core.Abstractions
{
    internal interface ICreatable
    {
        #region Properties

        DateTimeOffset? DateCreated { get; set; }

        string CreatedBy { get; set; }

        #endregion Properties
    }
}
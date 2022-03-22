using System;

namespace Core.Abstractions
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
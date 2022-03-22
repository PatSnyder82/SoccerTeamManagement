using System.Collections.Generic;

namespace Core.Models
{
    public class Parent : PersonBase
    {
        #region Relationships

        public ICollection<PlayerParent> PlayerParents { get; set; }

        #endregion Relationships
    }
}
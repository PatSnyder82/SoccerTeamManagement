using Core.Abstractions;
using System.Collections.Generic;

namespace Core.Models
{
    public class Club : EntityBase
    {
        #region Properties

        public string Name { get; set; }

        #endregion Properties

        /// TODO: Relationship Managers/Coaches

        #region Relationships

        public int? ImageId { get; set; }

        public ICollection<ClubLeague> ClubLeagues { get; set; }

        public Image Logo { get; set; }

        public ICollection<Team> Teams { get; set; }

        #endregion Relationships
    }
}
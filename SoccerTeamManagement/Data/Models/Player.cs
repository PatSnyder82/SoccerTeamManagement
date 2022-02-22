using SoccerTeamManagement.Data.Models.Joins;
using System.Collections.Generic;

namespace SoccerTeamManagement.Data.Models
{
    public class Player : Person
    {
        #region Properties

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public Enums.Foot Foot { get; set; }

        /// TODO:   modelBuilder.Entity<Player>().Property(s => s.Foot).HasConversion<string>();

        public int? WeakFootRating { get; set; }

        public int? FlareRating { get; set; }

        #endregion Properties

        #region Relationships

        public int? NationId { get; set; }

        public NationLookup Nation { get; set; }

        public int? AttributesId { get; set; }

        public PlayerAttributes Attributes { get; set; }

        public ICollection<PlayerPosition> PlayerPositions { get; set; }

        public ICollection<PlayerTeam> PlayerTeams { get; set; }

        #region Parents

        public ICollection<PlayerParent> Parents { get; set; }

        #endregion Parents

        #endregion Relationships
    }
}
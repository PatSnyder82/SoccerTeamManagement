namespace SoccerTeamManagement.Data.DTOs.People
{
    public class PlayerAttributesDTO : EntityBaseDTO
    {
        #region Properties

        #region Pace Properties

        public int? Acceleration { get; set; }

        public int? SprintSpeed { get; set; }

        #endregion Pace Properties

        #region Dribbling

        public int? Agility { get; set; }

        public int? Balance { get; set; }

        public int? Reactions { get; set; }

        public int? BallControl { get; set; }

        public int? Dribbling { get; set; }

        public int? Composure { get; set; }

        #endregion Dribbling

        #region Shooting

        public int? OffensivePositioning { get; set; }

        public int? Finishing { get; set; }

        public int? ShotPower { get; set; }

        public int? LongShots { get; set; }

        public int? Volleys { get; set; }

        public int? Penalties { get; set; }

        #endregion Shooting

        #region Defending

        public int? Interceptions { get; set; }

        public int? HeadingAccuracy { get; set; }

        public int? DefensiveAwareness { get; set; }

        public int? StandingTackle { get; set; }

        public int? SlidingTackle { get; set; }

        #endregion Defending

        #region Passing

        public int? Vision { get; set; }

        public int? Crossing { get; set; }

        public int? FreeKickAccuracy { get; set; }

        public int? ShortPassing { get; set; }

        public int? LongPassing { get; set; }

        public int? Curve { get; set; }

        #endregion Passing

        #region Physicality

        public int? Jumping { get; set; }

        public int? Stamina { get; set; }

        public int? Strength { get; set; }

        public int? Aggression { get; set; }

        #endregion Physicality

        #region Goalie

        public int? Diving { get; set; }

        public int? Reflexes { get; set; }

        public int? Handling { get; set; }

        public int? Kicking { get; set; }

        public int? GoaliePositioning { get; set; }

        #endregion Goalie

        #endregion Properties

        #region Relationships

        public int? PlayerId { get; set; }

        #endregion Relationships
    }
}
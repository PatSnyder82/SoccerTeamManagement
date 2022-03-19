using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Interfaces;
using SoccerTeamManagement.Data.Models.People;

namespace SoccerTeamManagement.Data.Configuration.People
{
    public class PlayerAttributesConfiguration : IEntityTypeConfiguration<PlayerAttributes>, ISeed<PlayerAttributes>
    {
        public void Configure(EntityTypeBuilder<PlayerAttributes> builder)
        {
            builder.ToTable("PlayerAttributes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            #region Relationships

            //One Player has One PlayerAttributes
            builder.HasOne(x => x.Player)
                   .WithOne(x => x.Attributes)
                   .HasForeignKey<Player>(x => x.AttributesId);

            #endregion Relationships

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<PlayerAttributes> builder)
        {
        }

        public void SeedDebug(EntityTypeBuilder<PlayerAttributes> builder)
        {
#if DEBUG
            builder.HasData(new PlayerAttributes { Id = 901, PlayerId = 901, Acceleration = 80, Aggression = 80, Agility = 80, Balance = 80, BallControl = 80, Composure = 80, Crossing = 80, Curve = 80, DefensiveAwareness = 80, Diving = 80, Dribbling = 80, Finishing = 80, FreeKickAccuracy = 80, GoaliePositioning = 0, Handling = 80, HeadingAccuracy = 80, Interceptions = 80, Jumping = 80, Kicking = 80, LongPassing = 80, LongShots = 80, OffensivePositioning = 80, Penalties = 80, Reactions = 80, Reflexes = 80, ShortPassing = 80, ShotPower = 80, Volleys = 80, SlidingTackle = 80, SprintSpeed = 80, Stamina = 80, StandingTackle = 80, Strength = 80, Vision = 80 });
            builder.HasData(new PlayerAttributes { Id = 902, PlayerId = 902, Acceleration = 82, Aggression = 82, Agility = 82, Balance = 82, BallControl = 82, Composure = 82, Crossing = 82, Curve = 82, DefensiveAwareness = 82, Diving = 82, Dribbling = 82, Finishing = 82, FreeKickAccuracy = 82, GoaliePositioning = 0, Handling = 82, HeadingAccuracy = 82, Interceptions = 82, Jumping = 82, Kicking = 82, LongPassing = 82, LongShots = 82, OffensivePositioning = 82, Penalties = 82, Reactions = 82, Reflexes = 82, ShortPassing = 82, ShotPower = 82, Volleys = 82, SlidingTackle = 82, SprintSpeed = 82, Stamina = 82, StandingTackle = 82, Strength = 82, Vision = 82 });
            builder.HasData(new PlayerAttributes { Id = 903, PlayerId = 902, Acceleration = 70, Aggression = 70, Agility = 70, Balance = 70, BallControl = 70, Composure = 70, Crossing = 70, Curve = 70, DefensiveAwareness = 70, Diving = 70, Dribbling = 70, Finishing = 70, FreeKickAccuracy = 70, GoaliePositioning = 0, Handling = 70, HeadingAccuracy = 70, Interceptions = 70, Jumping = 70, Kicking = 70, LongPassing = 70, LongShots = 70, OffensivePositioning = 70, Penalties = 70, Reactions = 70, Reflexes = 70, ShortPassing = 70, ShotPower = 70, Volleys = 70, SlidingTackle = 70, SprintSpeed = 70, Stamina = 70, StandingTackle = 70, Strength = 70, Vision = 70 });
            builder.HasData(new PlayerAttributes { Id = 904, PlayerId = 902, Acceleration = 72, Aggression = 72, Agility = 72, Balance = 72, BallControl = 72, Composure = 72, Crossing = 72, Curve = 72, DefensiveAwareness = 72, Diving = 72, Dribbling = 72, Finishing = 72, FreeKickAccuracy = 72, GoaliePositioning = 0, Handling = 72, HeadingAccuracy = 72, Interceptions = 72, Jumping = 72, Kicking = 72, LongPassing = 72, LongShots = 72, OffensivePositioning = 72, Penalties = 72, Reactions = 72, Reflexes = 72, ShortPassing = 72, ShotPower = 72, Volleys = 72, SlidingTackle = 72, SprintSpeed = 72, Stamina = 72, StandingTackle = 72, Strength = 72, Vision = 72 });
            builder.HasData(new PlayerAttributes { Id = 905, PlayerId = 902, Acceleration = 60, Aggression = 60, Agility = 60, Balance = 60, BallControl = 60, Composure = 60, Crossing = 60, Curve = 60, DefensiveAwareness = 60, Diving = 60, Dribbling = 60, Finishing = 60, FreeKickAccuracy = 60, GoaliePositioning = 0, Handling = 60, HeadingAccuracy = 60, Interceptions = 60, Jumping = 60, Kicking = 60, LongPassing = 60, LongShots = 60, OffensivePositioning = 60, Penalties = 60, Reactions = 60, Reflexes = 60, ShortPassing = 60, ShotPower = 60, Volleys = 60, SlidingTackle = 60, SprintSpeed = 60, Stamina = 60, StandingTackle = 60, Strength = 60, Vision = 60 });
            builder.HasData(new PlayerAttributes { Id = 906, PlayerId = 906, Acceleration = 62, Aggression = 62, Agility = 62, Balance = 62, BallControl = 62, Composure = 62, Crossing = 62, Curve = 62, DefensiveAwareness = 62, Diving = 62, Dribbling = 62, Finishing = 62, FreeKickAccuracy = 62, GoaliePositioning = 0, Handling = 62, HeadingAccuracy = 62, Interceptions = 62, Jumping = 62, Kicking = 62, LongPassing = 62, LongShots = 62, OffensivePositioning = 62, Penalties = 62, Reactions = 62, Reflexes = 62, ShortPassing = 62, ShotPower = 62, Volleys = 62, SlidingTackle = 62, SprintSpeed = 62, Stamina = 62, StandingTackle = 62, Strength = 62, Vision = 62 });
            builder.HasData(new PlayerAttributes { Id = 907, PlayerId = 907, Acceleration = 50, Aggression = 50, Agility = 50, Balance = 50, BallControl = 50, Composure = 50, Crossing = 50, Curve = 50, DefensiveAwareness = 50, Diving = 50, Dribbling = 50, Finishing = 50, FreeKickAccuracy = 50, GoaliePositioning = 0, Handling = 50, HeadingAccuracy = 50, Interceptions = 50, Jumping = 50, Kicking = 50, LongPassing = 50, LongShots = 50, OffensivePositioning = 50, Penalties = 50, Reactions = 50, Reflexes = 50, ShortPassing = 50, ShotPower = 50, Volleys = 50, SlidingTackle = 50, SprintSpeed = 50, Stamina = 50, StandingTackle = 50, Strength = 50, Vision = 50 });
            builder.HasData(new PlayerAttributes { Id = 908, PlayerId = 908, Acceleration = 52, Aggression = 52, Agility = 52, Balance = 52, BallControl = 52, Composure = 52, Crossing = 52, Curve = 52, DefensiveAwareness = 52, Diving = 52, Dribbling = 52, Finishing = 52, FreeKickAccuracy = 52, GoaliePositioning = 0, Handling = 52, HeadingAccuracy = 52, Interceptions = 52, Jumping = 52, Kicking = 52, LongPassing = 52, LongShots = 52, OffensivePositioning = 52, Penalties = 52, Reactions = 52, Reflexes = 52, ShortPassing = 52, ShotPower = 52, Volleys = 52, SlidingTackle = 52, SprintSpeed = 52, Stamina = 52, StandingTackle = 52, Strength = 52, Vision = 52 });
            builder.HasData(new PlayerAttributes { Id = 909, PlayerId = 909, Acceleration = 90, Aggression = 90, Agility = 90, Balance = 90, BallControl = 90, Composure = 90, Crossing = 90, Curve = 90, DefensiveAwareness = 90, Diving = 90, Dribbling = 90, Finishing = 90, FreeKickAccuracy = 90, GoaliePositioning = 0, Handling = 90, HeadingAccuracy = 90, Interceptions = 90, Jumping = 90, Kicking = 90, LongPassing = 90, LongShots = 90, OffensivePositioning = 90, Penalties = 90, Reactions = 90, Reflexes = 90, ShortPassing = 90, ShotPower = 90, Volleys = 90, SlidingTackle = 90, SprintSpeed = 90, Stamina = 90, StandingTackle = 90, Strength = 90, Vision = 90 });
            builder.HasData(new PlayerAttributes { Id = 910, PlayerId = 910, Acceleration = 92, Aggression = 92, Agility = 92, Balance = 92, BallControl = 92, Composure = 92, Crossing = 92, Curve = 92, DefensiveAwareness = 92, Diving = 92, Dribbling = 92, Finishing = 92, FreeKickAccuracy = 92, GoaliePositioning = 0, Handling = 92, HeadingAccuracy = 92, Interceptions = 92, Jumping = 92, Kicking = 92, LongPassing = 92, LongShots = 92, OffensivePositioning = 92, Penalties = 92, Reactions = 92, Reflexes = 92, ShortPassing = 92, ShotPower = 92, Volleys = 92, SlidingTackle = 92, SprintSpeed = 92, Stamina = 92, StandingTackle = 92, Strength = 92, Vision = 92 });
            builder.HasData(new PlayerAttributes { Id = 911, PlayerId = 911, Acceleration = 94, Aggression = 94, Agility = 94, Balance = 94, BallControl = 94, Composure = 94, Crossing = 94, Curve = 94, DefensiveAwareness = 94, Diving = 94, Dribbling = 94, Finishing = 94, FreeKickAccuracy = 94, GoaliePositioning = 0, Handling = 94, HeadingAccuracy = 94, Interceptions = 94, Jumping = 94, Kicking = 94, LongPassing = 94, LongShots = 94, OffensivePositioning = 94, Penalties = 94, Reactions = 94, Reflexes = 94, ShortPassing = 94, ShotPower = 94, Volleys = 94, SlidingTackle = 94, SprintSpeed = 94, Stamina = 94, StandingTackle = 94, Strength = 94, Vision = 94 });
            builder.HasData(new PlayerAttributes { Id = 912, PlayerId = 912, Acceleration = 96, Aggression = 96, Agility = 96, Balance = 96, BallControl = 96, Composure = 96, Crossing = 96, Curve = 96, DefensiveAwareness = 96, Diving = 96, Dribbling = 96, Finishing = 96, FreeKickAccuracy = 96, GoaliePositioning = 0, Handling = 96, HeadingAccuracy = 96, Interceptions = 96, Jumping = 96, Kicking = 96, LongPassing = 96, LongShots = 96, OffensivePositioning = 96, Penalties = 96, Reactions = 96, Reflexes = 96, ShortPassing = 96, ShotPower = 96, Volleys = 96, SlidingTackle = 96, SprintSpeed = 96, Stamina = 96, StandingTackle = 96, Strength = 96, Vision = 96 });
#else
#endif
        }
    }
}
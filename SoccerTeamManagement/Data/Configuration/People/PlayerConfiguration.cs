using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoccerTeamManagement.Data.Interfaces;
using SoccerTeamManagement.Data.Models.People;

namespace SoccerTeamManagement.Data.Configuration.People
{
    public class PlayerConfiguration : PersonConfiguration<Player>, IEntityTypeConfiguration<Player>, ISeed<Player>
    {
        public override void Configure(EntityTypeBuilder<Player> builder)
        {
            base.Configure(builder);

            builder.ToTable("Player");
            //builder.HasBaseType<Person>();

            builder.Property(s => s.Foot).HasConversion<string>();

            #region Relationships

            //One Player has One Attributes Record
            builder.HasOne(x => x.Attributes)
                   .WithOne(x => x.Player)
                   .HasForeignKey<Player>(x => x.AttributesId);

            #endregion Relationships

            #region Seed

            Seed(builder);
            SeedDebug(builder);

            #endregion Seed
        }

        public void Seed(EntityTypeBuilder<Player> builder)
        {
        }

        public void SeedDebug(EntityTypeBuilder<Player> builder)
        {
#if DEBUG
            builder.HasData(new Player { Id = 901, AddressId = 901, PhoneId = 901, AttributesId = 901, NationId = 10, Foot = Enums.Foot.Right, FlareRating = Enums.StarRating.TwoStar, WeakFootRating = Enums.StarRating.OneStar, Height = 64, Weight = 210, FirstName = "Clark", LastName = "Kent", NickName = "Superman", IsAdult = false });
            builder.HasData(new Player { Id = 902, AddressId = 902, PhoneId = 902, AttributesId = 902, NationId = 32, Foot = Enums.Foot.Right, FlareRating = Enums.StarRating.ThreeStar, WeakFootRating = Enums.StarRating.FourStar, Height = 65, Weight = 185, FirstName = "Peter", LastName = "Parker", NickName = "Spiderman", IsAdult = false });
            builder.HasData(new Player { Id = 903, AddressId = 903, PhoneId = 903, AttributesId = 903, NationId = 41, Foot = Enums.Foot.Left, FlareRating = Enums.StarRating.ThreeStar, WeakFootRating = Enums.StarRating.OneStar, Height = 66, Weight = 175, FirstName = "Bruce", LastName = "Wayne", NickName = "Batman", IsAdult = false });
            builder.HasData(new Player { Id = 904, AddressId = 904, PhoneId = 904, AttributesId = 904, NationId = 49, Foot = Enums.Foot.Right, FlareRating = Enums.StarRating.OneStar, WeakFootRating = Enums.StarRating.FiveStar, Height = 67, Weight = 165, FirstName = "Jack", LastName = "Reacher", NickName = "Reacher", IsAdult = false });
            builder.HasData(new Player { Id = 905, AddressId = 905, PhoneId = 905, AttributesId = 905, NationId = 237, Foot = Enums.Foot.Right, FlareRating = Enums.StarRating.ThreeStar, WeakFootRating = Enums.StarRating.OneStar, Height = 68, Weight = 155, FirstName = "Diana", LastName = "Prince", NickName = "Wonder Woman", IsAdult = true });
            builder.HasData(new Player { Id = 906, AddressId = 906, PhoneId = 906, AttributesId = 906, NationId = 237, Foot = Enums.Foot.Left, FlareRating = Enums.StarRating.ThreeStar, WeakFootRating = Enums.StarRating.ThreeStar, Height = 69, Weight = 195, FirstName = "Oliver", LastName = "Queen", NickName = "Green Arrow", IsAdult = true });
            builder.HasData(new Player { Id = 907, AddressId = 907, PhoneId = 907, AttributesId = 907, NationId = 237, Foot = Enums.Foot.Right, FlareRating = Enums.StarRating.FourStar, WeakFootRating = Enums.StarRating.OneStar, Height = 70, Weight = 210, FirstName = "Natasha", LastName = "Romanoff", NickName = "Black Widow", IsAdult = false });
            builder.HasData(new Player { Id = 908, AddressId = 908, PhoneId = 908, AttributesId = 908, NationId = 77, Foot = Enums.Foot.Right, FlareRating = Enums.StarRating.ThreeStar, WeakFootRating = Enums.StarRating.FourStar, Height = 71, Weight = 190, FirstName = "Bruce", LastName = "Banner", NickName = "Hulk", IsAdult = false });
            builder.HasData(new Player { Id = 909, AddressId = 909, PhoneId = 909, AttributesId = 909, NationId = 84, Foot = Enums.Foot.Left, FlareRating = Enums.StarRating.ThreeStar, WeakFootRating = Enums.StarRating.OneStar, Height = 72, Weight = 200, FirstName = "Tony", LastName = "Stark", NickName = "Iron Man", IsAdult = true });
            builder.HasData(new Player { Id = 910, AddressId = 910, PhoneId = 910, AttributesId = 910, NationId = 10, Foot = Enums.Foot.Right, FlareRating = Enums.StarRating.FiveStar, WeakFootRating = Enums.StarRating.TwoStar, Height = 73, Weight = 160, FirstName = "Thor", LastName = "Odinson", NickName = "Thor", IsAdult = false });
            builder.HasData(new Player { Id = 911, AddressId = 911, PhoneId = 911, AttributesId = 911, NationId = 235, Foot = Enums.Foot.Right, FlareRating = Enums.StarRating.ThreeStar, WeakFootRating = Enums.StarRating.OneStar, Height = 74, Weight = 170, FirstName = "Steve", LastName = "Rodgers", NickName = "Captain America", IsAdult = false });
            builder.HasData(new Player { Id = 912, AddressId = 912, PhoneId = 912, AttributesId = 912, NationId = 210, Foot = Enums.Foot.Left, FlareRating = Enums.StarRating.TwoStar, WeakFootRating = Enums.StarRating.TwoStar, Height = 59, Weight = 180, FirstName = "Bob", LastName = "Smith", NickName = "BoSmith", IsAdult = false });
#endif
        }
    }
}
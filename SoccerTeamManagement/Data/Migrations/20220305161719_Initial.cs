using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerTeamManagement.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alpha2Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alpha3Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlternativeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsumedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acceleration = table.Column<int>(type: "int", nullable: true),
                    SprintSpeed = table.Column<int>(type: "int", nullable: true),
                    Agility = table.Column<int>(type: "int", nullable: true),
                    Balance = table.Column<int>(type: "int", nullable: true),
                    Reactions = table.Column<int>(type: "int", nullable: true),
                    BallControl = table.Column<int>(type: "int", nullable: true),
                    Dribbling = table.Column<int>(type: "int", nullable: true),
                    Composure = table.Column<int>(type: "int", nullable: true),
                    OffensivePositioning = table.Column<int>(type: "int", nullable: true),
                    Finishing = table.Column<int>(type: "int", nullable: true),
                    ShotPower = table.Column<int>(type: "int", nullable: true),
                    LongShots = table.Column<int>(type: "int", nullable: true),
                    Volleys = table.Column<int>(type: "int", nullable: true),
                    Penalties = table.Column<int>(type: "int", nullable: true),
                    Interceptions = table.Column<int>(type: "int", nullable: true),
                    HeadingAccuracy = table.Column<int>(type: "int", nullable: true),
                    DefensiveAwareness = table.Column<int>(type: "int", nullable: true),
                    StandingTackle = table.Column<int>(type: "int", nullable: true),
                    SlidingTackle = table.Column<int>(type: "int", nullable: true),
                    Vision = table.Column<int>(type: "int", nullable: true),
                    Crossing = table.Column<int>(type: "int", nullable: true),
                    FreeKickAccuracy = table.Column<int>(type: "int", nullable: true),
                    ShortPassing = table.Column<int>(type: "int", nullable: true),
                    LongPassing = table.Column<int>(type: "int", nullable: true),
                    Curve = table.Column<int>(type: "int", nullable: true),
                    Jumping = table.Column<int>(type: "int", nullable: true),
                    Stamina = table.Column<int>(type: "int", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: true),
                    Aggression = table.Column<int>(type: "int", nullable: true),
                    Diving = table.Column<int>(type: "int", nullable: true),
                    Reflexes = table.Column<int>(type: "int", nullable: true),
                    Handling = table.Column<int>(type: "int", nullable: true),
                    Kicking = table.Column<int>(type: "int", nullable: true),
                    GoaliePositioning = table.Column<int>(type: "int", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alpha2Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CountryId1 = table.Column<int>(type: "int", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId1",
                        column: x => x.CountryId1,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Club_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "League",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League", x => x.Id);
                    table.ForeignKey(
                        name: "FK_League_Image_LogoId",
                        column: x => x.LogoId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionCategoryId = table.Column<int>(type: "int", nullable: true),
                    IsDisabled = table.Column<bool>(type: "bit", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Position_PositionCategory_PositionCategoryId",
                        column: x => x.PositionCategoryId,
                        principalTable: "PositionCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Phone_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Foot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeakFootRating = table.Column<int>(type: "int", nullable: false),
                    FlareRating = table.Column<int>(type: "int", nullable: false),
                    AttributesId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Player_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Player_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Player_Phone_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Player_PlayerAttributes_AttributesId",
                        column: x => x.AttributesId,
                        principalTable: "PlayerAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoId = table.Column<int>(type: "int", nullable: true),
                    ClubId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Team_Image_LogoId",
                        column: x => x.LogoId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parent_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPosition",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPosition", x => new { x.PlayerId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_PlayerPosition_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerPosition_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeagueTeam",
                columns: table => new
                {
                    LeagueId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueTeam", x => new { x.LeagueId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_LeagueTeam_League_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "League",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeagueTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamPlayer",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    JoinedTeam = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DepartedTeam = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPlayer", x => new { x.PlayerId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_TeamPlayer_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamPlayer_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerParent",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerParent", x => new { x.PlayerId, x.ParentId });
                    table.ForeignKey(
                        name: "FK_PlayerParent_Parent_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerParent_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Club",
                columns: new[] { "Id", "ImageId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Atlanta United" },
                    { 23, null, "Portland Timbers" },
                    { 24, null, "Real Salt Lake" },
                    { 25, null, "San Jose Earthquakes" },
                    { 26, null, "Seattle Sounders" },
                    { 27, null, "Toronto FC" },
                    { 28, null, "Vancouver Whitecaps" },
                    { 901, null, "Test Club 1" },
                    { 902, null, "Test Club 2" },
                    { 903, null, "Test Club 3" },
                    { 904, null, "Test Club 4" },
                    { 905, null, "Test Club 5" },
                    { 906, null, "Test Club 6" },
                    { 908, null, "Test Club 8" },
                    { 909, null, "Test Club 9" },
                    { 910, null, "Test Club 10" },
                    { 911, null, "Test Club 11" },
                    { 912, null, "Test Club 12" },
                    { 22, null, "Philadelphia Union" },
                    { 21, null, "Orlando City" },
                    { 907, null, "Test Club 7" },
                    { 19, null, "New York Red Bulls" },
                    { 20, null, "New York City FC" },
                    { 2, null, "Austin FC" },
                    { 3, null, "Charlotte FC" },
                    { 4, null, "Chicago Fire FC" },
                    { 6, null, "Colorado Rapids" },
                    { 7, null, "Columbus Crew" },
                    { 8, null, "D.C. United" },
                    { 9, null, "FC Dallas" },
                    { 5, null, "FC Cincinnati" },
                    { 11, null, "Sporting Kansas City" },
                    { 12, null, "LA Galaxy" },
                    { 13, null, "Los Angeles Football Club" },
                    { 14, null, "Inter Miami CF" },
                    { 15, null, "Minnesota United" },
                    { 16, null, "CF Montreal" },
                    { 17, null, "Nashville SC" },
                    { 10, null, "Houston Dynamo FC" },
                    { 18, null, "New England Revolution" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 170, "PW", "PLW", false, 585, "Palau", "585" },
                    { 169, "PK", "PAK", false, 586, "Pakistan", "586" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 168, "OM", "OMN", false, 512, "Oman", "512" },
                    { 167, "NO", "NOR", false, 578, "Norway", "578" },
                    { 166, "MP", "MNP", false, 580, "Northern Mariana Islands", "580" },
                    { 162, "NG", "NGA", false, 566, "Nigeria", "566" },
                    { 164, "NF", "NFK", false, 574, "Norfolk Island", "574" },
                    { 163, "NU", "NIU", false, 570, "Niue", "570" },
                    { 161, "NE", "NER", false, 562, "Niger", "562" },
                    { 171, "PS", "PSE", false, 275, "Palestine, State of", "275" },
                    { 160, "NI", "NIC", false, 558, "Nicaragua", "558" },
                    { 165, "MK", "MKD", false, 807, "North Macedonia", "807" },
                    { 172, "PA", "PAN", false, 591, "Panama", "591" },
                    { 182, "RO", "ROU", false, 642, "Romania", "642" },
                    { 174, "PY", "PRY", false, 600, "Paraguay", "600" },
                    { 175, "PE", "PER", false, 604, "Peru", "604" },
                    { 176, "PH", "PHL", false, 608, "Philippines", "608" },
                    { 177, "PN", "PCN", false, 612, "Pitcairn", "612" },
                    { 178, "PL", "POL", false, 616, "Poland", "616" },
                    { 179, "PT", "PRT", false, 620, "Portugal", "620" },
                    { 180, "PR", "PRI", false, 630, "Puerto Rico", "630" },
                    { 181, "QA", "QAT", false, 634, "Qatar", "634" },
                    { 183, "RU", "RUS", false, 643, "Russian Federation", "643" },
                    { 184, "RW", "RWA", false, 646, "Rwanda", "646" },
                    { 185, "RE", "REU", false, 638, "Réunion", "638" },
                    { 186, "BL", "BLM", false, 652, "Saint Barthélemy", "652" },
                    { 159, "NZ", "NZL", false, 554, "New Zealand", "554" },
                    { 173, "PG", "PNG", false, 598, "Papua New Guinea", "598" },
                    { 158, "NC", "NCL", false, 540, "New Caledonia", "540" },
                    { 138, "MT", "MLT", false, 470, "Malta", "470" },
                    { 156, "NP", "NPL", false, 524, "Nepal", "524" },
                    { 127, "LR", "LBR", false, 430, "Liberia", "430" },
                    { 128, "LY", "LBY", false, 434, "Libya", "434" },
                    { 130, "LT", "LTU", false, 440, "Lithuania", "440" },
                    { 131, "LU", "LUX", false, 442, "Luxembourg", "442" },
                    { 132, "MO", "MAC", false, 446, "Macao", "446" },
                    { 133, "MG", "MDG", false, 450, "Madagascar", "450" },
                    { 134, "MW", "MWI", false, 454, "Malawi", "454" },
                    { 135, "MY", "MYS", false, 458, "Malaysia", "458" },
                    { 136, "MV", "MDV", false, 462, "Maldives", "462" },
                    { 137, "ML", "MLI", false, 466, "Mali", "466" },
                    { 187, "SH", "SHN", false, 654, "Saint Helena, Ascension and Tristan da Cunha", "654" },
                    { 139, "MH", "MHL", false, 584, "Marshall Islands", "584" },
                    { 140, "MQ", "MTQ", false, 474, "Martinique", "474" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 157, "NL", "NLD", false, 528, "Netherlands", "528" },
                    { 141, "MR", "MRT", false, 478, "Mauritania", "478" },
                    { 143, "YT", "MYT", false, 175, "Mayotte", "175" },
                    { 144, "MX", "MEX", false, 484, "Mexico", "484" },
                    { 145, "FM", "FSM", false, 583, "Micronesia (Federated States of)", "583" },
                    { 146, "MD", "MDA", false, 498, "Moldova (the Republic of)", "498" },
                    { 147, "MC", "MCO", false, 492, "Monaco", "492" },
                    { 148, "MN", "MNG", false, 496, "Mongolia", "496" },
                    { 149, "ME", "MNE", false, 499, "Montenegro", "499" },
                    { 150, "MS", "MSR", false, 500, "Montserrat", "500" },
                    { 151, "MA", "MAR", false, 504, "Morocco", "504" },
                    { 152, "MZ", "MOZ", false, 508, "Mozambique", "508" },
                    { 153, "MM", "MMR", false, 104, "Myanmar", "104" },
                    { 154, "NA", "NAM", false, 516, "Namibia", "516" },
                    { 155, "NR", "NRU", false, 520, "Nauru", "520" },
                    { 142, "MU", "MUS", false, 480, "Mauritius", "480" },
                    { 188, "KN", "KNA", false, 659, "Saint Kitts and Nevis", "659" },
                    { 208, "GS", "SGS", false, 239, "South Georgia and the South Sandwich Islands", "239" },
                    { 190, "MF", "MAF", false, 663, "Saint Martin (French part)", "663" },
                    { 223, "TG", "TGO", false, 768, "Togo", "768" },
                    { 224, "TK", "TKL", false, 772, "Tokelau", "772" },
                    { 225, "TO", "TON", false, 776, "Tonga", "776" },
                    { 226, "TT", "TTO", false, 780, "Trinidad and Tobago", "780" },
                    { 227, "TN", "TUN", false, 788, "Tunisia", "788" },
                    { 228, "TR", "TUR", false, 792, "Turkey", "792" },
                    { 229, "TM", "TKM", false, 795, "Turkmenistan", "795" },
                    { 230, "TC", "TCA", false, 796, "Turks and Caicos Islands", "796" },
                    { 231, "TV", "TUV", false, 798, "Tuvalu", "798" },
                    { 232, "UG", "UGA", false, 800, "Uganda", "800" },
                    { 233, "UA", "UKR", false, 804, "Ukraine", "804" },
                    { 234, "AE", "ARE", false, 784, "United Arab Emirates", "784" },
                    { 235, "GB", "GBR", false, 826, "United Kingdom of Great Britain and Northern Ireland", "826" },
                    { 236, "UM", "UMI", false, 581, "United States Minor Outlying Islands", "581" },
                    { 237, "US", "USA", false, 1, "United States of America", "840" },
                    { 238, "UY", "URY", false, 858, "Uruguay", "858" },
                    { 239, "UZ", "UZB", false, 860, "Uzbekistan", "860" },
                    { 240, "VU", "VUT", false, 548, "Vanuatu", "548" },
                    { 241, "VE", "VEN", false, 862, "Venezuela (Bolivarian Republic of)", "862" },
                    { 242, "VN", "VNM", false, 704, "Viet Nam", "704" },
                    { 243, "VG", "VGB", false, 92, "Virgin Islands (British)", "92" },
                    { 244, "VI", "VIR", false, 850, "Virgin Islands (U.S.)", "850" },
                    { 245, "WF", "WLF", false, 876, "Wallis and Futuna", "876" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 246, "EH", "ESH", false, 732, "Western Sahara", "732" },
                    { 247, "YE", "YEM", false, 887, "Yemen", "887" },
                    { 248, "ZM", "ZMB", false, 894, "Zambia", "894" },
                    { 249, "ZW", "ZWE", false, 716, "Zimbabwe", "716" },
                    { 222, "TL", "TLS", false, 626, "Timor-Leste", "626" },
                    { 221, "TH", "THA", false, 764, "Thailand", "764" },
                    { 220, "TZ", "TZA", false, 834, "Tanzania, the United Republic of", "834" },
                    { 219, "TJ", "TJK", false, 762, "Tajikistan", "762" },
                    { 191, "PM", "SPM", false, 666, "Saint Pierre and Miquelon", "666" },
                    { 192, "VC", "VCT", false, 670, "Saint Vincent and the Grenadines", "670" },
                    { 193, "WS", "WSM", false, 882, "Samoa", "882" },
                    { 194, "SM", "SMR", false, 674, "San Marino", "674" },
                    { 195, "ST", "STP", false, 678, "Sao Tome and Principe", "678" },
                    { 196, "SA", "SAU", false, 682, "Saudi Arabia", "682" },
                    { 197, "SN", "SEN", false, 686, "Senegal", "686" },
                    { 198, "RS", "SRB", false, 688, "Serbia", "688" },
                    { 199, "SC", "SYC", false, 690, "Seychelles", "690" },
                    { 200, "SL", "SLE", false, 694, "Sierra Leone", "694" },
                    { 201, "SG", "SGP", false, 702, "Singapore", "702" },
                    { 202, "SX", "SXM", false, 534, "Sint Maarten (Dutch part)", "534" },
                    { 203, "SK", "SVK", false, 703, "Slovakia", "703" },
                    { 189, "LC", "LCA", false, 662, "Saint Lucia", "662" },
                    { 204, "SI", "SVN", false, 705, "Slovenia", "705" },
                    { 206, "SO", "SOM", false, 706, "Somalia", "706" },
                    { 207, "ZA", "ZAF", false, 710, "South Africa", "710" },
                    { 126, "LS", "LSO", false, 426, "Lesotho", "426" },
                    { 209, "SS", "SSD", false, 728, "South Sudan", "728" },
                    { 210, "ES", "ESP", false, 724, "Spain", "724" },
                    { 211, "LK", "LKA", false, 144, "Sri Lanka", "144" },
                    { 212, "SD", "SDN", false, 729, "Sudan", "729" },
                    { 213, "SR", "SUR", false, 740, "Suriname", "740" },
                    { 214, "SJ", "SJM", false, 744, "Svalbard and Jan Mayen", "744" },
                    { 215, "SE", "SWE", false, 752, "Sweden", "752" },
                    { 216, "CH", "CHE", false, 756, "Switzerland", "756" },
                    { 217, "SY", "SYR", false, 760, "Syrian Arab Republic", "760" },
                    { 218, "TW", "TWN", false, 158, "Taiwan (Province of China)", "158" },
                    { 205, "SB", "SLB", false, 90, "Solomon Islands", "90" },
                    { 125, "LB", "LBN", false, 422, "Lebanon", "422" },
                    { 129, "LI", "LIE", false, 438, "Liechtenstein", "438" },
                    { 123, "LA", "LAO", false, 418, "Lao People's Democratic Republic", "418" },
                    { 33, "IO", "IOT", false, 86, "British Indian Ocean Territory", "86" },
                    { 34, "BN", "BRN", false, 96, "Brunei Darussalam", "96" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 35, "BG", "BGR", false, 100, "Bulgaria", "100" },
                    { 36, "BF", "BFA", false, 854, "Burkina Faso", "854" },
                    { 37, "BI", "BDI", false, 108, "Burundi", "108" },
                    { 124, "LV", "LVA", false, 428, "Latvia", "428" },
                    { 39, "KH", "KHM", false, 116, "Cambodia", "116" },
                    { 40, "CM", "CMR", false, 120, "Cameroon", "120" },
                    { 41, "CA", "CAN", false, 124, "Canada", "124" },
                    { 42, "KY", "CYM", false, 136, "Cayman Islands", "136" },
                    { 43, "CF", "CAF", false, 140, "Central African Republic", "140" },
                    { 44, "TD", "TCD", false, 148, "Chad", "148" },
                    { 45, "CL", "CHL", false, 152, "Chile", "152" },
                    { 46, "CN", "CHN", false, 156, "China", "156" },
                    { 47, "CX", "CXR", false, 162, "Christmas Island", "162" },
                    { 48, "CC", "CCK", false, 166, "Cocos (Keeling) Islands", "166" },
                    { 49, "CO", "COL", false, 170, "Colombia", "170" },
                    { 50, "KM", "COM", false, 174, "Comoros", "174" },
                    { 51, "CD", "COD", false, 180, "Congo (the Democratic Republic of the)", "180" },
                    { 52, "CG", "COG", false, 178, "Congo", "178" },
                    { 53, "CK", "COK", false, 184, "Cook Islands", "184" },
                    { 54, "CR", "CRI", false, 188, "Costa Rica", "188" },
                    { 55, "HR", "HRV", false, 191, "Croatia", "191" },
                    { 56, "CU", "CUB", false, 192, "Cuba", "192" },
                    { 57, "CW", "CUW", false, 531, "Curaçao", "531" },
                    { 58, "CY", "CYP", false, 196, "Cyprus", "196" },
                    { 59, "CZ", "CZE", false, 203, "Czechia", "203" },
                    { 32, "BR", "BRA", false, 76, "Brazil", "76" },
                    { 31, "BV", "BVT", false, 74, "Bouvet Island", "74" },
                    { 30, "BW", "BWA", false, 72, "Botswana", "72" },
                    { 29, "BA", "BIH", false, 70, "Bosnia and Herzegovina", "70" },
                    { 1, "AF", "AFG", false, 4, "Afghanistan", "4" },
                    { 2, "AL", "ALB", false, 8, "Albania", "8" },
                    { 3, "DZ", "DZA", false, 12, "Algeria", "12" },
                    { 4, "AS", "ASM", false, 16, "American Samoa", "16" },
                    { 5, "AD", "AND", false, 20, "Andorra", "20" },
                    { 6, "AO", "AGO", false, 24, "Angola", "24" },
                    { 7, "AI", "AIA", false, 660, "Anguilla", "660" },
                    { 8, "AQ", "ATA", false, 10, "Antarctica", "10" },
                    { 9, "AG", "ATG", false, 28, "Antigua and Barbuda", "28" },
                    { 10, "AR", "ARG", false, 32, "Argentina", "32" },
                    { 11, "AM", "ARM", false, 51, "Armenia", "51" },
                    { 12, "AW", "ABW", false, 533, "Aruba", "533" },
                    { 13, "AU", "AUS", false, 36, "Australia", "36" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 60, "CI", "CIV", false, 384, "Côte d'Ivoire", "384" },
                    { 14, "AT", "AUT", false, 40, "Austria", "40" },
                    { 16, "BS", "BHS", false, 44, "Bahamas", "44" },
                    { 17, "BH", "BHR", false, 48, "Bahrain", "48" },
                    { 18, "BD", "BGD", false, 50, "Bangladesh", "50" },
                    { 19, "BB", "BRB", false, 52, "Barbados", "52" },
                    { 20, "BY", "BLR", false, 112, "Belarus", "112" },
                    { 21, "BE", "BEL", false, 56, "Belgium", "56" },
                    { 22, "BZ", "BLZ", false, 84, "Belize", "84" },
                    { 23, "BJ", "BEN", false, 204, "Benin", "204" },
                    { 24, "BM", "BMU", false, 60, "Bermuda", "60" },
                    { 25, "AX", "ALA", false, 248, "Åland Islands", "248" },
                    { 26, "BT", "BTN", false, 64, "Bhutan", "64" },
                    { 27, "BO", "BOL", false, 68, "Bolivia (Plurinational State of)", "68" },
                    { 28, "BQ", "BES", false, 535, "Bonaire, Sint Eustatius and Saba", "535" },
                    { 15, "AZ", "AZE", false, 31, "Azerbaijan", "31" },
                    { 61, "DK", "DNK", false, 208, "Denmark", "208" },
                    { 38, "CV", "CPV", false, 132, "Cabo Verde", "132" },
                    { 63, "DM", "DMA", false, 212, "Dominica", "212" },
                    { 96, "GY", "GUY", false, 328, "Guyana", "328" },
                    { 97, "HT", "HTI", false, 332, "Haiti", "332" },
                    { 98, "HM", "HMD", false, 334, "Heard Island and McDonald Islands", "334" },
                    { 99, "VA", "VAT", false, 336, "Holy See", "336" },
                    { 100, "HN", "HND", false, 340, "Honduras", "340" },
                    { 101, "HK", "HKG", false, 344, "Hong Kong", "344" },
                    { 102, "HU", "HUN", false, 348, "Hungary", "348" },
                    { 103, "IS", "ISL", false, 352, "Iceland", "352" },
                    { 104, "IN", "IND", false, 356, "India", "356" },
                    { 105, "ID", "IDN", false, 360, "Indonesia", "360" },
                    { 106, "IR", "IRN", false, 364, "Iran (Islamic Republic of)", "364" },
                    { 107, "IQ", "IRQ", false, 368, "Iraq", "368" },
                    { 108, "IE", "IRL", false, 372, "Ireland", "372" },
                    { 109, "IM", "IMN", false, 833, "Isle of Man", "833" },
                    { 110, "IL", "ISR", false, 376, "Israel", "376" },
                    { 111, "IT", "ITA", false, 380, "Italy", "380" },
                    { 112, "JM", "JAM", false, 388, "Jamaica", "388" },
                    { 113, "JP", "JPN", false, 392, "Japan", "392" },
                    { 114, "JE", "JEY", false, 832, "Jersey", "832" },
                    { 115, "JO", "JOR", false, 400, "Jordan", "400" },
                    { 116, "KZ", "KAZ", false, 398, "Kazakhstan", "398" },
                    { 62, "DJ", "DJI", false, 262, "Djibouti", "262" },
                    { 118, "KI", "KIR", false, 296, "Kiribati", "296" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 119, "KP", "PRK", false, 408, "Korea (the Democratic People's Republic of)", "408" },
                    { 120, "KR", "KOR", false, 410, "Korea (the Republic of)", "410" },
                    { 121, "KW", "KWT", false, 414, "Kuwait", "414" },
                    { 122, "KG", "KGZ", false, 417, "Kyrgyzstan", "417" },
                    { 95, "GW", "GNB", false, 624, "Guinea-Bissau", "624" },
                    { 94, "GN", "GIN", false, 324, "Guinea", "324" },
                    { 117, "KE", "KEN", false, 404, "Kenya", "404" },
                    { 92, "GT", "GTM", false, 320, "Guatemala", "320" },
                    { 64, "DO", "DOM", false, 214, "Dominican Republic", "214" },
                    { 65, "EC", "ECU", false, 218, "Ecuador", "218" },
                    { 66, "EG", "EGY", false, 818, "Egypt", "818" },
                    { 67, "SV", "SLV", false, 222, "El Salvador", "222" },
                    { 68, "GQ", "GNQ", false, 226, "Equatorial Guinea", "226" },
                    { 69, "ER", "ERI", false, 232, "Eritrea", "232" },
                    { 70, "EE", "EST", false, 233, "Estonia", "233" },
                    { 71, "SZ", "SWZ", false, 748, "Eswatini", "748" },
                    { 72, "ET", "ETH", false, 231, "Ethiopia", "231" },
                    { 74, "FO", "FRO", false, 234, "Faroe Islands", "234" },
                    { 75, "FJ", "FJI", false, 242, "Fiji", "242" },
                    { 76, "FI", "FIN", false, 246, "Finland", "246" },
                    { 77, "FR", "FRA", false, 250, "France", "250" },
                    { 73, "FK", "FLK", false, 238, "Falkland Islands [Malvinas]", "238" },
                    { 79, "PF", "PYF", false, 258, "French Polynesia", "258" },
                    { 91, "GU", "GUM", false, 316, "Guam", "316" },
                    { 90, "GP", "GLP", false, 312, "Guadeloupe", "312" },
                    { 78, "GF", "GUF", false, 254, "French Guiana", "254" },
                    { 89, "GD", "GRD", false, 308, "Grenada", "308" },
                    { 88, "GL", "GRL", false, 304, "Greenland", "304" },
                    { 87, "GR", "GRC", false, 300, "Greece", "300" },
                    { 86, "GI", "GIB", false, 292, "Gibraltar", "292" },
                    { 93, "GG", "GGY", false, 831, "Guernsey", "831" },
                    { 84, "DE", "DEU", false, 276, "Germany", "276" },
                    { 83, "GE", "GEO", false, 268, "Georgia", "268" },
                    { 82, "GM", "GMB", false, 270, "Gambia", "270" },
                    { 81, "GA", "GAB", false, 266, "Gabon", "266" },
                    { 80, "TF", "ATF", false, 260, "French Southern Territories", "260" },
                    { 85, "GH", "GHA", false, 288, "Ghana", "288" }
                });

            migrationBuilder.InsertData(
                table: "League",
                columns: new[] { "Id", "LogoId", "Name" },
                values: new object[,]
                {
                    { 903, null, "Test League 3" },
                    { 911, null, "Test League 11" },
                    { 910, null, "Test League 10" },
                    { 909, null, "Test League 9" },
                    { 908, null, "Test League 8" }
                });

            migrationBuilder.InsertData(
                table: "League",
                columns: new[] { "Id", "LogoId", "Name" },
                values: new object[,]
                {
                    { 907, null, "Test League 7" },
                    { 906, null, "Test League 6" },
                    { 905, null, "Test League 5" },
                    { 904, null, "Test League 4" },
                    { 912, null, "Test League 12" },
                    { 901, null, "Test League 1" },
                    { 9, null, "Local League" },
                    { 8, null, "Serie A" },
                    { 7, null, "Eredivisie" },
                    { 6, null, "Ligue 1" },
                    { 5, null, "Bundesliga" },
                    { 4, null, "Serie A" },
                    { 3, null, "La Liga" },
                    { 2, null, "Premier League" },
                    { 1, null, "Major League Soccer" },
                    { 902, null, "Test League 2" }
                });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "AreaCode", "CountryCode", "Extension", "Number", "PhoneType" },
                values: new object[,]
                {
                    { 913, "837", "1", null, "9028880", "Cell" },
                    { 912, "234", "1", null, "9028880", "Cell" },
                    { 911, "", "49", null, "9028880", "Cell" },
                    { 910, "789", "1", null, "9028880", "Home" },
                    { 908, "123", "1", null, "9028880", "Cell" },
                    { 907, "719", "1", null, "9028880", "Work" },
                    { 909, "456", "1", null, "9028880", "Cell" },
                    { 905, "850", "1", null, "9028880", "Cell" },
                    { 904, "940", "1", null, "9028880", "Home" },
                    { 903, "405", "1", null, "9028880", "Cell" },
                    { 902, "405", "1", null, "9028880", "Cell" },
                    { 901, "360", "1", null, "9028880", "Cell" },
                    { 906, "717", "1", null, "9028880", "Cell" }
                });

            migrationBuilder.InsertData(
                table: "PlayerAttributes",
                columns: new[] { "Id", "Acceleration", "Aggression", "Agility", "Balance", "BallControl", "Composure", "Crossing", "Curve", "DefensiveAwareness", "Diving", "Dribbling", "Finishing", "FreeKickAccuracy", "GoaliePositioning", "Handling", "HeadingAccuracy", "Interceptions", "Jumping", "Kicking", "LongPassing", "LongShots", "OffensivePositioning", "Penalties", "PlayerId", "Reactions", "Reflexes", "ShortPassing", "ShotPower", "SlidingTackle", "SprintSpeed", "Stamina", "StandingTackle", "Strength", "Vision", "Volleys" },
                values: new object[,]
                {
                    { 910, 92, 92, 92, 92, 92, 92, 92, 92, 92, 92, 92, 92, 92, 0, 92, 92, 92, 92, 92, 92, 92, 92, 92, 910, 92, 92, 92, 92, 92, 92, 92, 92, 92, 92, 92 },
                    { 909, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 0, 90, 90, 90, 90, 90, 90, 90, 90, 90, 909, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90 },
                    { 908, 52, 52, 52, 52, 52, 52, 52, 52, 52, 52, 52, 52, 52, 0, 52, 52, 52, 52, 52, 52, 52, 52, 52, 908, 52, 52, 52, 52, 52, 52, 52, 52, 52, 52, 52 },
                    { 907, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 0, 50, 50, 50, 50, 50, 50, 50, 50, 50, 907, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 },
                    { 906, 62, 62, 62, 62, 62, 62, 62, 62, 62, 62, 62, 62, 62, 0, 62, 62, 62, 62, 62, 62, 62, 62, 62, 906, 62, 62, 62, 62, 62, 62, 62, 62, 62, 62, 62 },
                    { 905, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 0, 60, 60, 60, 60, 60, 60, 60, 60, 60, 902, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60 },
                    { 902, 82, 82, 82, 82, 82, 82, 82, 82, 82, 82, 82, 82, 82, 0, 82, 82, 82, 82, 82, 82, 82, 82, 82, 902, 82, 82, 82, 82, 82, 82, 82, 82, 82, 82, 82 },
                    { 903, 70, 70, 70, 70, 70, 70, 70, 70, 70, 70, 70, 70, 70, 0, 70, 70, 70, 70, 70, 70, 70, 70, 70, 902, 70, 70, 70, 70, 70, 70, 70, 70, 70, 70, 70 },
                    { 901, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 0, 80, 80, 80, 80, 80, 80, 80, 80, 80, 901, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80 },
                    { 911, 94, 94, 94, 94, 94, 94, 94, 94, 94, 94, 94, 94, 94, 0, 94, 94, 94, 94, 94, 94, 94, 94, 94, 911, 94, 94, 94, 94, 94, 94, 94, 94, 94, 94, 94 },
                    { 904, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 0, 72, 72, 72, 72, 72, 72, 72, 72, 72, 902, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72 },
                    { 912, 96, 96, 96, 96, 96, 96, 96, 96, 96, 96, 96, 96, 96, 0, 96, 96, 96, 96, 96, 96, 96, 96, 96, 912, 96, 96, 96, 96, 96, 96, 96, 96, 96, 96, 96 }
                });

            migrationBuilder.InsertData(
                table: "PositionCategory",
                columns: new[] { "Id", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[] { 3, false, 3, "Defense", "3" });

            migrationBuilder.InsertData(
                table: "PositionCategory",
                columns: new[] { "Id", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[] { 2, false, 2, "Midfield", "2" });

            migrationBuilder.InsertData(
                table: "PositionCategory",
                columns: new[] { "Id", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[] { 1, false, 1, "Offense", "1" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "CountryId", "State", "StateId", "ZipCode" },
                values: new object[,]
                {
                    { 901, "1600 Pennsylvania Avenue NW", null, "Washington", 237, null, 10, "20500" },
                    { 902, "11 Wall Street", null, "New York", 237, null, 35, "10118" },
                    { 903, "350 Fifth Avenue", null, "New York", 237, null, 35, "10118" },
                    { 904, "221 B Baker Street", null, "London", 237, null, null, "" },
                    { 905, "4059 Mt. Lee Drive", null, "Hollywood", 237, null, 6, "90068" },
                    { 906, "400 S. Monroe Street", null, "Tallahassee", 237, null, 11, "32399" },
                    { 907, "1100 Congress Avenue", null, "Austin", 237, null, 48, "78701" },
                    { 908, "2300 N Lincoln Blvd", null, "Oklahoma City", 237, null, 40, "73105" },
                    { 909, "350 State Street", null, "Salt Lake City", 237, null, 50, "84103" },
                    { 910, "501 N. 3rd Street", null, "Harrisburg", 237, null, 42, "17120" },
                    { 911, "200 E. Colfax Ave", null, "Denver", 237, null, 7, "80203" },
                    { 912, "416 Sid Snyder Avenue SW", null, "Olympia", 237, null, 54, "98504" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Abbreviation", "IsDisabled", "PositionCategoryId", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 19, "CF", false, 3, 8, "Center Forward", "CF" },
                    { 1, "G", false, 1, 1, "Goalie", "G" },
                    { 2, "RB", false, 1, 2, "Right FullBack", "RB" },
                    { 18, "ST", false, 3, 8, "Striker", "ST" },
                    { 4, "LB", false, 1, 3, "Left FullBack", "LB" },
                    { 17, "RF", false, 3, 7, "Right Forward", "RF" },
                    { 16, "RW", false, 3, 7, "Right Wing", "RW" },
                    { 15, "RF", false, 3, 7, "Right Forward", "RF" },
                    { 14, "RW", false, 3, 7, "Right Wing", "RW" },
                    { 12, "LF", false, 3, 6, "Left Forward", "LF" },
                    { 11, "LW", false, 3, 6, "Left Wing", "LW" },
                    { 13, "RM", false, 2, 7, "Right Midfielder", "RM" },
                    { 10, "LM", false, 2, 6, "Left Midfielder", "LM" },
                    { 9, "CAM", false, 2, 5, "Center Attacking Midfielder", "CAM" },
                    { 3, "RWB", false, 1, 2, "Right Wing Back", "RWB" },
                    { 7, "CM", false, 2, 5, "Center Midfielder", "CM" },
                    { 8, "CDM", false, 2, 5, "Center Defensive Midfielder", "CDM" },
                    { 5, "LWB", false, 1, 3, "Left Wing Back", "LWB" },
                    { 6, "CB", false, 1, 4, "Center Back", "CB" }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "Alpha2Code", "CountryId", "CountryId1", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 23, "MD", 237, null, false, 23, "Maryland", "US-MD" },
                    { 27, "MS", 237, null, false, 27, "Mississippi", "US-MS" },
                    { 26, "MN", 237, null, false, 26, "Minnesota", "US-MN" },
                    { 25, "MI", 237, null, false, 25, "Michigan", "US-MI" },
                    { 24, "MA", 237, null, false, 24, "Massachusetts", "US-MA" },
                    { 15, "ID", 237, null, false, 15, "Idaho", "US-ID" },
                    { 16, "IL", 237, null, false, 16, "Illinois", "US-IL" },
                    { 18, "IA", 237, null, false, 18, "Iowa", "US-IA" },
                    { 28, "MO", 237, null, false, 28, "Missouri", "US-MO" },
                    { 19, "KS", 237, null, false, 19, "Kansas", "US-KS" },
                    { 20, "KY", 237, null, false, 20, "Kentucky", "US-KY" }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "Alpha2Code", "CountryId", "CountryId1", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 21, "LA", 237, null, false, 21, "Louisiana", "US-LA" },
                    { 22, "ME", 237, null, false, 22, "Maine", "US-ME" },
                    { 17, "IN", 237, null, false, 17, "Indiana", "US-IN" },
                    { 29, "MT", 237, null, false, 29, "Montana", "US-MT" },
                    { 38, "MP", 237, null, false, 38, "Northern Mariana Islands", "US-MP" },
                    { 31, "NV", 237, null, false, 31, "Nevada", "US-NV" },
                    { 57, "WY", 237, null, false, 57, "Wyoming", "US-WY" },
                    { 56, "WI", 237, null, false, 56, "Wisconsin", "US-WI" },
                    { 55, "WV", 237, null, false, 55, "West Virginia", "US-WV" },
                    { 54, "WA", 237, null, false, 54, "Washington", "US-WA" },
                    { 53, "VA", 237, null, false, 53, "Virginia", "US-VA" },
                    { 52, "VI", 237, null, false, 52, "Virgin Islands, U.S.", "US-VI" },
                    { 51, "VT", 237, null, false, 51, "Vermont", "US-VT" },
                    { 50, "UT", 237, null, false, 50, "Utah", "US-UT" },
                    { 49, "UM", 237, null, false, 49, "United States Minor Outlying Islands", "US-UM" },
                    { 48, "TX", 237, null, false, 48, "Texas", "US-TX" },
                    { 47, "TN", 237, null, false, 47, "Tennessee", "US-TN" },
                    { 46, "SD", 237, null, false, 46, "South Dakota", "US-SD" },
                    { 30, "NE", 237, null, false, 30, "Nebraska", "US-NE" },
                    { 45, "SC", 237, null, false, 45, "South Carolina", "US-SC" },
                    { 43, "PR", 237, null, false, 43, "Puerto Rico", "US-PR" },
                    { 42, "PA", 237, null, false, 42, "Pennsylvania", "US-PA" },
                    { 41, "OR", 237, null, false, 41, "Oregon", "US-OR" },
                    { 40, "OK", 237, null, false, 40, "Oklahoma", "US-OK" },
                    { 39, "OH", 237, null, false, 39, "Ohio", "US-OH" },
                    { 14, "HI", 237, null, false, 14, "Hawaii", "US-HI" },
                    { 37, "ND", 237, null, false, 37, "North Dakota", "US-ND" },
                    { 36, "NC", 237, null, false, 36, "North Carolina", "US-NC" },
                    { 35, "NY", 237, null, false, 35, "New York", "US-NY" },
                    { 34, "NM", 237, null, false, 34, "New Mexico", "US-NM" },
                    { 33, "NJ", 237, null, false, 33, "New Jersey", "US-NJ" },
                    { 32, "NH", 237, null, false, 32, "New Hampshire", "US-NH" },
                    { 44, "RI", 237, null, false, 44, "Rhode Island", "US-RI" },
                    { 13, "GU", 237, null, false, 13, "Guam", "US-GU" },
                    { 6, "CA", 237, null, false, 6, "California", "US-CA" },
                    { 11, "FL", 237, null, false, 11, "Florida", "US-FL" },
                    { 10, "DC", 237, null, false, 10, "District of Columbia", "US-DC" },
                    { 9, "DE", 237, null, false, 9, "Delaware", "US-DE" },
                    { 8, "CT", 237, null, false, 8, "Connecticut", "US-CT" },
                    { 7, "CO", 237, null, false, 7, "Colorado", "US-CO" },
                    { 5, "AR", 237, null, false, 5, "Arkansas", "US-AR" },
                    { 4, "AZ", 237, null, false, 4, "Arizona", "US-AZ" }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "Alpha2Code", "CountryId", "CountryId1", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 3, "AS", 237, null, false, 3, "American Samoa", "US-AS" },
                    { 2, "AK", 237, null, false, 2, "Alaska", "US-AK" },
                    { 1, "AL", 237, null, false, 1, "Alabama", "US-AL" },
                    { 12, "GA", 237, null, false, 12, "Georgia", "US-GA" }
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "ClubId", "LogoId", "Name" },
                values: new object[,]
                {
                    { 16, 16, null, "CF Montreal" },
                    { 17, 17, null, "Nashville SC" },
                    { 18, 18, null, "New England Revolution" },
                    { 19, 19, null, "New York Red Bulls" },
                    { 24, 24, null, "Real Salt Lake" },
                    { 21, 21, null, "Orlando City" },
                    { 22, 22, null, "Philadelphia Union" },
                    { 23, 23, null, "Portland Timbers" },
                    { 15, 15, null, "Minnesota United" },
                    { 20, 20, null, "New York City FC" },
                    { 14, 14, null, "Inter Miami CF" },
                    { 9, 9, null, "FC Dallas" },
                    { 12, 12, null, "LA Galaxy" },
                    { 11, 11, null, "Sporting Kansas City" },
                    { 10, 10, null, "Houston Dynamo FC" },
                    { 25, 25, null, "San Jose Earthquakes" },
                    { 8, 8, null, "D.C. United" },
                    { 7, 7, null, "Columbus Crew" },
                    { 6, 6, null, "Colorado Rapids" },
                    { 5, 5, null, "FC Cincinnati" },
                    { 4, 4, null, "Chicago Fire FC" },
                    { 3, 3, null, "Charlotte FC" },
                    { 2, 2, null, "Austin FC" },
                    { 13, 13, null, "Los Angeles Football Team" },
                    { 26, 26, null, "Seattle Sounders" },
                    { 914, 901, null, "Test Team 14" },
                    { 28, 28, null, "Vancouver Whitecaps" },
                    { 912, 912, null, "Test Team 12" },
                    { 911, 911, null, "Test Team 11" },
                    { 924, 910, null, "Test Team 24" },
                    { 910, 910, null, "Test Team 10" },
                    { 923, 909, null, "Test Team 23" },
                    { 909, 909, null, "Test Team 9" },
                    { 922, 908, null, "Test Team 22" },
                    { 908, 908, null, "Test Team 8" },
                    { 921, 907, null, "Test Team 21" },
                    { 907, 907, null, "Test Team 7" },
                    { 920, 906, null, "Test Team 20" }
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "ClubId", "LogoId", "Name" },
                values: new object[,]
                {
                    { 906, 906, null, "Test Team 6" },
                    { 919, 905, null, "Test Team 19" },
                    { 905, 905, null, "Test Team 5" },
                    { 918, 904, null, "Test Team 18" },
                    { 904, 904, null, "Test Team 4" },
                    { 917, 903, null, "Test Team 17" },
                    { 903, 903, null, "Test Team 3" },
                    { 916, 902, null, "Test Team 16" },
                    { 902, 902, null, "Test Team 2" },
                    { 915, 901, null, "Test Team 15" },
                    { 913, 901, null, "Test Team 13" },
                    { 901, 901, null, "Test Team 1" },
                    { 27, 27, null, "Toronto FC" },
                    { 1, 1, null, "Atlanta United" }
                });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "LeagueId", "TeamId", "IsPrimary" },
                values: new object[,]
                {
                    { 1, 1, true },
                    { 901, 901, true },
                    { 904, 901, false },
                    { 901, 902, true },
                    { 904, 902, false },
                    { 901, 903, true },
                    { 905, 903, false },
                    { 901, 904, true },
                    { 905, 904, false },
                    { 902, 905, true },
                    { 902, 906, true },
                    { 1, 28, true },
                    { 906, 906, false },
                    { 907, 907, false },
                    { 902, 908, true },
                    { 907, 908, false },
                    { 903, 909, true },
                    { 908, 909, false },
                    { 903, 910, true },
                    { 908, 910, false },
                    { 903, 911, true },
                    { 909, 911, false },
                    { 909, 912, false },
                    { 902, 907, true },
                    { 1, 27, true },
                    { 906, 905, false },
                    { 1, 25, true },
                    { 1, 26, true },
                    { 1, 3, true },
                    { 1, 4, true },
                    { 1, 5, true },
                    { 1, 6, true },
                    { 1, 7, true },
                    { 1, 8, true },
                    { 1, 9, true },
                    { 1, 10, true },
                    { 1, 11, true },
                    { 1, 12, true },
                    { 1, 13, true },
                    { 1, 2, true },
                    { 1, 23, true },
                    { 1, 15, true }
                });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "LeagueId", "TeamId", "IsPrimary" },
                values: new object[,]
                {
                    { 1, 16, true },
                    { 1, 17, true },
                    { 1, 18, true },
                    { 1, 19, true },
                    { 1, 20, true },
                    { 1, 21, true },
                    { 1, 22, true },
                    { 1, 14, true },
                    { 1, 24, true }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "AddressId", "CountryId", "DateOfBirth", "FirstName", "ImageId", "LastName", "NickName", "PhoneId" },
                values: new object[,]
                {
                    { 906, 906, null, new DateTime(1989, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestParentFirst6", null, "TestParentLast6", "TestParent 6", 906 },
                    { 907, 907, null, new DateTime(1990, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestParentFirst7", null, "TestParentLast7", "TestParent 7", 907 },
                    { 908, 908, null, new DateTime(1967, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestParentFirst8", null, "TestParentLast8", "TestParent 8", 908 },
                    { 912, 912, null, new DateTime(1999, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestParentFirst12", null, "TestParentLast12", "TestParent 12", 912 },
                    { 910, 910, null, new DateTime(1954, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestParentFirst10", null, "TestParentLast10", "TestParent 10", 910 },
                    { 911, 911, null, new DateTime(1978, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestParentFirst11", null, "TestParentLast11", "TestParent 11", 911 },
                    { 909, 909, null, new DateTime(1968, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestParentFirst9", null, "TestParentLast9", "TestParent 9", 909 },
                    { 905, 905, null, new DateTime(1988, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestParentFirst5", null, "TestParentLast5", "TestParent 5", 905 },
                    { 904, 904, null, new DateTime(1987, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestParentFirst4", null, "TestParentLast4", "TestParent 4", 904 },
                    { 903, 903, null, new DateTime(1986, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestParentFirst3", null, "TestParentLast3", "TestParent 3", 903 },
                    { 902, 902, null, new DateTime(1985, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestParentFirst2", null, "TestParentLast2", "TestParent 2", 902 },
                    { 901, 901, null, new DateTime(1984, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "TestParentFirst1", null, "TestParentLast1", "TestParent 1", 901 }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Id", "AddressId", "AttributesId", "CountryId", "DateOfBirth", "FirstName", "FlareRating", "Foot", "Height", "ImageId", "LastName", "NickName", "PhoneId", "WeakFootRating", "Weight" },
                values: new object[,]
                {
                    { 905, 905, 905, 237, new DateTime(1982, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diana", 3, "Right", 68, null, "Prince", "Wonder Woman", 905, 1, 155 },
                    { 903, 903, 903, 41, new DateTime(1981, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bruce", 3, "Left", 66, null, "Wayne", "Batman", 903, 1, 175 },
                    { 906, 906, 906, 237, new DateTime(2008, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oliver", 3, "Left", 69, null, "Queen", "Green Arrow", 906, 3, 195 },
                    { 907, 907, 907, 237, new DateTime(1983, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natasha", 4, "Right", 70, null, "Romanoff", "Black Widow", 907, 1, 210 },
                    { 902, 902, 902, 32, new DateTime(2010, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peter", 3, "Right", 65, null, "Parker", "Spiderman", 902, 4, 185 },
                    { 908, 908, 908, 77, new DateTime(2007, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bruce", 3, "Right", 71, null, "Banner", "Hulk", 908, 4, 190 },
                    { 909, 909, 909, 84, new DateTime(1984, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tony", 3, "Left", 72, null, "Stark", "Iron Man", 909, 1, 200 },
                    { 901, 901, 901, 10, new DateTime(1980, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clark", 2, "Right", 64, null, "Kent", "Superman", 901, 1, 210 },
                    { 910, 910, 910, 10, new DateTime(2006, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thor", 5, "Right", 73, null, "Odinson", "Thor", 910, 2, 160 },
                    { 911, 911, 911, 235, new DateTime(1985, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steve", 3, "Right", 74, null, "Rodgers", "Captain America", 911, 1, 170 },
                    { 904, 904, 904, 49, null, "Jack", 1, "Right", 67, null, "Reacher", "Reacher", 904, 5, 165 },
                    { 912, 912, 912, 210, new DateTime(2005, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", 2, "Left", 59, null, "Smith", "BoSmith", 912, 2, 180 }
                });

            migrationBuilder.InsertData(
                table: "Parent",
                column: "Id",
                values: new object[]
                {
                    901,
                    907,
                    905,
                    908,
                    904,
                    909,
                    910,
                    903,
                    911,
                    912,
                    902,
                    906
                });

            migrationBuilder.InsertData(
                table: "PlayerPosition",
                columns: new[] { "PlayerId", "PositionId", "IsPrimary" },
                values: new object[,]
                {
                    { 909, 11, true },
                    { 912, 15, false },
                    { 909, 19, false },
                    { 910, 12, true },
                    { 908, 13, true },
                    { 911, 13, true },
                    { 907, 12, true },
                    { 912, 14, true },
                    { 906, 11, true },
                    { 905, 19, false },
                    { 905, 18, true },
                    { 901, 1, true },
                    { 901, 2, false },
                    { 904, 6, true },
                    { 901, 3, false },
                    { 903, 5, true },
                    { 902, 4, true }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayer",
                columns: new[] { "PlayerId", "TeamId", "DepartedTeam", "JoinedTeam" },
                values: new object[,]
                {
                    { 906, 902, new DateTimeOffset(new DateTime(2022, 3, 5, 11, 17, 18, 618, DateTimeKind.Unspecified).AddTicks(7053), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 911, 903, new DateTimeOffset(new DateTime(2022, 3, 5, 11, 17, 18, 618, DateTimeKind.Unspecified).AddTicks(7079), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 901, 901, new DateTimeOffset(new DateTime(2022, 3, 5, 11, 17, 18, 614, DateTimeKind.Unspecified).AddTicks(5072), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 910, 903, new DateTimeOffset(new DateTime(2022, 3, 5, 11, 17, 18, 618, DateTimeKind.Unspecified).AddTicks(7074), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 909, 903, new DateTimeOffset(new DateTime(2022, 3, 5, 11, 17, 18, 618, DateTimeKind.Unspecified).AddTicks(7068), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 905, 902, new DateTimeOffset(new DateTime(2022, 3, 5, 11, 17, 18, 618, DateTimeKind.Unspecified).AddTicks(7041), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 902, 901, new DateTimeOffset(new DateTime(2022, 3, 5, 11, 17, 18, 618, DateTimeKind.Unspecified).AddTicks(6981), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 903, 901, new DateTimeOffset(new DateTime(2022, 3, 5, 11, 17, 18, 618, DateTimeKind.Unspecified).AddTicks(7028), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 908, 903, new DateTimeOffset(new DateTime(2022, 3, 5, 11, 17, 18, 618, DateTimeKind.Unspecified).AddTicks(7063), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 904, 901, new DateTimeOffset(new DateTime(2022, 3, 5, 11, 17, 18, 618, DateTimeKind.Unspecified).AddTicks(7036), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 907, 902, new DateTimeOffset(new DateTime(2022, 3, 5, 11, 17, 18, 618, DateTimeKind.Unspecified).AddTicks(7058), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 901, 905, new DateTimeOffset(new DateTime(2022, 3, 5, 11, 17, 18, 618, DateTimeKind.Unspecified).AddTicks(7089), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 912, 904, new DateTimeOffset(new DateTime(2022, 3, 5, 11, 17, 18, 618, DateTimeKind.Unspecified).AddTicks(7084), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "PlayerParent",
                columns: new[] { "ParentId", "PlayerId" },
                values: new object[,]
                {
                    { 901, 901 },
                    { 901, 902 },
                    { 902, 903 },
                    { 902, 904 },
                    { 903, 905 },
                    { 903, 906 },
                    { 904, 907 },
                    { 904, 908 },
                    { 907, 909 },
                    { 908, 910 },
                    { 910, 911 },
                    { 911, 912 },
                    { 912, 901 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Club_ImageId",
                table: "Club",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_League_LogoId",
                table: "League",
                column: "LogoId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueTeam_TeamId",
                table: "LeagueTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressId",
                table: "Person",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CountryId",
                table: "Person",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ImageId",
                table: "Person",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PhoneId",
                table: "Person",
                column: "PhoneId",
                unique: true,
                filter: "[PhoneId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Player_AddressId",
                table: "Player",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Player_AttributesId",
                table: "Player",
                column: "AttributesId",
                unique: true,
                filter: "[AttributesId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Player_CountryId",
                table: "Player",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_ImageId",
                table: "Player",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_PhoneId",
                table: "Player",
                column: "PhoneId",
                unique: true,
                filter: "[PhoneId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerParent_ParentId",
                table: "PlayerParent",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPosition_PositionId",
                table: "PlayerPosition",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_PositionCategoryId",
                table: "Position",
                column: "PositionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId1",
                table: "State",
                column: "CountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Team_ClubId",
                table: "Team",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_LogoId",
                table: "Team",
                column: "LogoId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayer_TeamId",
                table: "TeamPlayer",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "LeagueTeam");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "PlayerParent");

            migrationBuilder.DropTable(
                name: "PlayerPosition");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "TeamPlayer");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "League");

            migrationBuilder.DropTable(
                name: "Parent");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "PositionCategory");

            migrationBuilder.DropTable(
                name: "PlayerAttributes");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}

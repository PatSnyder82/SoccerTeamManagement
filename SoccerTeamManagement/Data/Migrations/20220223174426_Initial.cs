using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerTeamManagement.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

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
                    Source_OpenNewWindow = table.Column<bool>(type: "bit", nullable: true),
                    Source_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "League",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NationLookup",
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
                    table.PrimaryKey("PK_NationLookup", x => x.Id);
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
                    AreaCode = table.Column<int>(type: "int", nullable: false),
                    Extension = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
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
                name: "PositionCategoryLookup",
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
                    table.PrimaryKey("PK_PositionCategoryLookup", x => x.Id);
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
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeagueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_League_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "League",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdult = table.Column<bool>(type: "bit", nullable: false),
                    PhoneId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parent_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parent_Phone_PhoneId",
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
                    Foot = table.Column<int>(type: "int", nullable: false),
                    WeakFootRating = table.Column<int>(type: "int", nullable: true),
                    FlareRating = table.Column<int>(type: "int", nullable: true),
                    NationId = table.Column<int>(type: "int", nullable: true),
                    AttributesId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdult = table.Column<bool>(type: "bit", nullable: false),
                    PhoneId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Player_NationLookup_NationId",
                        column: x => x.NationId,
                        principalTable: "NationLookup",
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
                name: "PositionLookup",
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
                    table.PrimaryKey("PK_PositionLookup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionLookup_PositionCategoryLookup_PositionCategoryId",
                        column: x => x.PositionCategoryId,
                        principalTable: "PositionCategoryLookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "PlayerTeam",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    JoinedTeam = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DepartedTeam = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTeam", x => new { x.PlayerId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_PlayerTeam_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTeam_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_PlayerPosition_PositionLookup_PositionId",
                        column: x => x.PositionId,
                        principalTable: "PositionLookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NationLookup",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 1, "AF", "AFG", false, 4, "Afghanistan", "4" },
                    { 160, "NI", "NIC", false, 558, "Nicaragua", "558" },
                    { 161, "NE", "NER", false, 562, "Niger", "562" },
                    { 162, "NG", "NGA", false, 566, "Nigeria", "566" },
                    { 163, "NU", "NIU", false, 570, "Niue", "570" },
                    { 164, "NF", "NFK", false, 574, "Norfolk Island", "574" },
                    { 165, "MK", "MKD", false, 807, "North Macedonia", "807" },
                    { 166, "MP", "MNP", false, 580, "Northern Mariana Islands", "580" },
                    { 167, "NO", "NOR", false, 578, "Norway", "578" },
                    { 168, "OM", "OMN", false, 512, "Oman", "512" },
                    { 169, "PK", "PAK", false, 586, "Pakistan", "586" },
                    { 170, "PW", "PLW", false, 585, "Palau", "585" },
                    { 171, "PS", "PSE", false, 275, "Palestine, State of", "275" },
                    { 172, "PA", "PAN", false, 591, "Panama", "591" },
                    { 173, "PG", "PNG", false, 598, "Papua New Guinea", "598" },
                    { 174, "PY", "PRY", false, 600, "Paraguay", "600" },
                    { 175, "PE", "PER", false, 0, "Peru", "" },
                    { 176, "PH", "PHL", false, 608, "Philippines", "608" },
                    { 177, "PN", "PCN", false, 612, "Pitcairn", "612" },
                    { 178, "PL", "POL", false, 616, "Poland", "616" },
                    { 179, "PT", "PRT", false, 620, "Portugal", "620" },
                    { 180, "PR", "PRI", false, 630, "Puerto Rico", "630" },
                    { 181, "QA", "QAT", false, 634, "Qatar", "634" },
                    { 182, "RO", "ROU", false, 642, "Romania", "642" },
                    { 183, "RU", "RUS", false, 643, "Russian Federation", "643" },
                    { 184, "RW", "RWA", false, 646, "Rwanda", "646" },
                    { 185, "RE", "REU", false, 638, "Réunion", "638" },
                    { 186, "BL", "BLM", false, 652, "Saint Barthélemy", "652" },
                    { 159, "NZ", "NZL", false, 554, "New Zealand", "554" },
                    { 187, "SH", "SHN", false, 654, "Saint Helena, Ascension and Tristan da Cunha", "654" },
                    { 158, "NC", "NCL", false, 540, "New Caledonia", "540" },
                    { 156, "NP", "NPL", false, 524, "Nepal", "524" },
                    { 129, "LI", "LIE", false, 438, "Liechtenstein", "438" },
                    { 130, "LT", "LTU", false, 440, "Lithuania", "440" },
                    { 131, "LU", "LUX", false, 442, "Luxembourg", "442" },
                    { 132, "MO", "MAC", false, 446, "Macao", "446" },
                    { 133, "MG", "MDG", false, 450, "Madagascar", "450" },
                    { 134, "MW", "MWI", false, 454, "Malawi", "454" },
                    { 135, "MY", "MYS", false, 458, "Malaysia", "458" },
                    { 136, "MV", "MDV", false, 462, "Maldives", "462" },
                    { 137, "ML", "MLI", false, 466, "Mali", "466" },
                    { 138, "MT", "MLT", false, 470, "Malta", "470" }
                });

            migrationBuilder.InsertData(
                table: "NationLookup",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 139, "MH", "MHL", false, 584, "Marshall Islands", "584" },
                    { 140, "MQ", "MTQ", false, 474, "Martinique", "474" },
                    { 141, "MR", "MRT", false, 478, "Mauritania", "478" },
                    { 142, "MU", "MUS", false, 480, "Mauritius", "480" },
                    { 143, "YT", "MYT", false, 175, "Mayotte", "175" },
                    { 144, "MX", "MEX", false, 484, "Mexico", "484" },
                    { 145, "FM", "FSM", false, 583, "Micronesia (Federated States of)", "583" },
                    { 146, "MD", "MDA", false, 498, "Moldova (the Republic of)", "498" },
                    { 147, "MC", "MCO", false, 492, "Monaco", "492" },
                    { 148, "MN", "MNG", false, 496, "Mongolia", "496" },
                    { 149, "ME", "MNE", false, 499, "Montenegro", "499" },
                    { 150, "MS", "MSR", false, 0, "Montserrat", "" },
                    { 151, "MA", "MAR", false, 504, "Morocco", "504" },
                    { 152, "MZ", "MOZ", false, 508, "Mozambique", "508" },
                    { 153, "MM", "MMR", false, 104, "Myanmar", "104" },
                    { 154, "NA", "NAM", false, 516, "Namibia", "516" },
                    { 155, "NR", "NRU", false, 520, "Nauru", "520" },
                    { 157, "NL", "NLD", false, 528, "Netherlands", "528" },
                    { 188, "KN", "KNA", false, 659, "Saint Kitts and Nevis", "659" },
                    { 189, "LC", "LCA", false, 662, "Saint Lucia", "662" },
                    { 190, "MF", "MAF", false, 663, "Saint Martin (French part)", "663" },
                    { 223, "TG", "TGO", false, 768, "Togo", "768" },
                    { 224, "TK", "TKL", false, 772, "Tokelau", "772" },
                    { 225, "TO", "TON", false, 0, "Tonga", "" },
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
                    { 237, "US", "USA", false, 840, "United States of America", "840" },
                    { 238, "UY", "URY", false, 858, "Uruguay", "858" },
                    { 239, "UZ", "UZB", false, 860, "Uzbekistan", "860" },
                    { 240, "VU", "VUT", false, 548, "Vanuatu", "548" },
                    { 241, "VE", "VEN", false, 862, "Venezuela (Bolivarian Republic of)", "862" },
                    { 242, "VN", "VNM", false, 704, "Viet Nam", "704" },
                    { 243, "VG", "VGB", false, 92, "Virgin Islands (British)", "92" }
                });

            migrationBuilder.InsertData(
                table: "NationLookup",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 244, "VI", "VIR", false, 850, "Virgin Islands (U.S.)", "850" },
                    { 245, "WF", "WLF", false, 876, "Wallis and Futuna", "876" },
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
                    { 200, "SL", "SLE", false, 0, "Sierra Leone", "" },
                    { 201, "SG", "SGP", false, 702, "Singapore", "702" },
                    { 202, "SX", "SXM", false, 534, "Sint Maarten (Dutch part)", "534" },
                    { 203, "SK", "SVK", false, 703, "Slovakia", "703" },
                    { 128, "LY", "LBY", false, 434, "Libya", "434" },
                    { 204, "SI", "SVN", false, 705, "Slovenia", "705" },
                    { 206, "SO", "SOM", false, 706, "Somalia", "706" },
                    { 207, "ZA", "ZAF", false, 710, "South Africa", "710" },
                    { 208, "GS", "SGS", false, 239, "South Georgia and the South Sandwich Islands", "239" },
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
                    { 127, "LR", "LBR", false, 430, "Liberia", "430" },
                    { 126, "LS", "LSO", false, 426, "Lesotho", "426" },
                    { 62, "DJ", "DJI", false, 262, "Djibouti", "262" }
                });

            migrationBuilder.InsertData(
                table: "NationLookup",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 35, "BG", "BGR", false, 100, "Bulgaria", "100" },
                    { 36, "BF", "BFA", false, 854, "Burkina Faso", "854" },
                    { 37, "BI", "BDI", false, 108, "Burundi", "108" },
                    { 38, "CV", "CPV", false, 132, "Cabo Verde", "132" },
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
                    { 50, "KM", "COM", false, 0, "Comoros", "" },
                    { 51, "CD", "COD", false, 180, "Congo (the Democratic Republic of the)", "180" },
                    { 52, "CG", "COG", false, 178, "Congo", "178" },
                    { 53, "CK", "COK", false, 184, "Cook Islands", "184" },
                    { 54, "CR", "CRI", false, 188, "Costa Rica", "188" },
                    { 55, "HR", "HRV", false, 191, "Croatia", "191" },
                    { 56, "CU", "CUB", false, 192, "Cuba", "192" },
                    { 57, "CW", "CUW", false, 531, "Curaçao", "531" },
                    { 58, "CY", "CYP", false, 196, "Cyprus", "196" },
                    { 59, "CZ", "CZE", false, 203, "Czechia", "203" },
                    { 60, "CI", "CIV", false, 384, "Côte d'Ivoire", "384" },
                    { 61, "DK", "DNK", false, 208, "Denmark", "208" },
                    { 34, "BN", "BRN", false, 96, "Brunei Darussalam", "96" },
                    { 125, "LB", "LBN", false, 0, "Lebanon", "" },
                    { 33, "IO", "IOT", false, 86, "British Indian Ocean Territory", "86" },
                    { 31, "BV", "BVT", false, 74, "Bouvet Island", "74" },
                    { 4, "AS", "ASM", false, 16, "American Samoa", "16" },
                    { 5, "AD", "AND", false, 20, "Andorra", "20" },
                    { 6, "AO", "AGO", false, 24, "Angola", "24" },
                    { 7, "AI", "AIA", false, 660, "Anguilla", "660" },
                    { 8, "AQ", "ATA", false, 10, "Antarctica", "10" },
                    { 9, "AG", "ATG", false, 28, "Antigua and Barbuda", "28" },
                    { 10, "AR", "ARG", false, 32, "Argentina", "32" },
                    { 11, "AM", "ARM", false, 51, "Armenia", "51" },
                    { 12, "AW", "ABW", false, 533, "Aruba", "533" },
                    { 13, "AU", "AUS", false, 36, "Australia", "36" },
                    { 14, "AT", "AUT", false, 40, "Austria", "40" }
                });

            migrationBuilder.InsertData(
                table: "NationLookup",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 15, "AZ", "AZE", false, 31, "Azerbaijan", "31" },
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
                    { 29, "BA", "BIH", false, 70, "Bosnia and Herzegovina", "70" },
                    { 30, "BW", "BWA", false, 72, "Botswana", "72" },
                    { 32, "BR", "BRA", false, 76, "Brazil", "76" },
                    { 63, "DM", "DMA", false, 212, "Dominica", "212" },
                    { 64, "DO", "DOM", false, 214, "Dominican Republic", "214" },
                    { 65, "EC", "ECU", false, 218, "Ecuador", "218" },
                    { 98, "HM", "HMD", false, 334, "Heard Island and McDonald Islands", "334" },
                    { 99, "VA", "VAT", false, 336, "Holy See", "336" },
                    { 100, "HN", "HND", false, 0, "Honduras", "" },
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
                    { 117, "KE", "KEN", false, 404, "Kenya", "404" },
                    { 118, "KI", "KIR", false, 296, "Kiribati", "296" },
                    { 119, "KP", "PRK", false, 408, "Korea (the Democratic People's Republic of)", "408" }
                });

            migrationBuilder.InsertData(
                table: "NationLookup",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 120, "KR", "KOR", false, 410, "Korea (the Republic of)", "410" },
                    { 121, "KW", "KWT", false, 414, "Kuwait", "414" },
                    { 122, "KG", "KGZ", false, 417, "Kyrgyzstan", "417" },
                    { 123, "LA", "LAO", false, 418, "Lao People's Democratic Republic", "418" },
                    { 124, "LV", "LVA", false, 428, "Latvia", "428" },
                    { 97, "HT", "HTI", false, 332, "Haiti", "332" },
                    { 96, "GY", "GUY", false, 328, "Guyana", "328" },
                    { 95, "GW", "GNB", false, 624, "Guinea-Bissau", "624" },
                    { 94, "GN", "GIN", false, 324, "Guinea", "324" },
                    { 66, "EG", "EGY", false, 818, "Egypt", "818" },
                    { 67, "SV", "SLV", false, 222, "El Salvador", "222" },
                    { 68, "GQ", "GNQ", false, 226, "Equatorial Guinea", "226" },
                    { 69, "ER", "ERI", false, 232, "Eritrea", "232" },
                    { 70, "EE", "EST", false, 233, "Estonia", "233" },
                    { 71, "SZ", "SWZ", false, 748, "Eswatini", "748" },
                    { 72, "ET", "ETH", false, 231, "Ethiopia", "231" },
                    { 73, "FK", "FLK", false, 238, "Falkland Islands [Malvinas]", "238" },
                    { 74, "FO", "FRO", false, 234, "Faroe Islands", "234" },
                    { 75, "FJ", "FJI", false, 0, "Fiji", "" },
                    { 76, "FI", "FIN", false, 246, "Finland", "246" },
                    { 77, "FR", "FRA", false, 250, "France", "250" },
                    { 78, "GF", "GUF", false, 254, "French Guiana", "254" },
                    { 3, "DZ", "DZA", false, 12, "Algeria", "12" },
                    { 79, "PF", "PYF", false, 258, "French Polynesia", "258" },
                    { 81, "GA", "GAB", false, 266, "Gabon", "266" },
                    { 82, "GM", "GMB", false, 270, "Gambia", "270" },
                    { 83, "GE", "GEO", false, 268, "Georgia", "268" },
                    { 84, "DE", "DEU", false, 276, "Germany", "276" },
                    { 85, "GH", "GHA", false, 288, "Ghana", "288" },
                    { 86, "GI", "GIB", false, 292, "Gibraltar", "292" },
                    { 87, "GR", "GRC", false, 300, "Greece", "300" },
                    { 88, "GL", "GRL", false, 304, "Greenland", "304" },
                    { 89, "GD", "GRD", false, 308, "Grenada", "308" },
                    { 90, "GP", "GLP", false, 312, "Guadeloupe", "312" },
                    { 91, "GU", "GUM", false, 316, "Guam", "316" },
                    { 92, "GT", "GTM", false, 320, "Guatemala", "320" },
                    { 93, "GG", "GGY", false, 831, "Guernsey", "831" },
                    { 80, "TF", "ATF", false, 260, "French Southern Territories", "260" },
                    { 2, "AL", "ALB", false, 8, "Albania", "8" }
                });

            migrationBuilder.InsertData(
                table: "PositionCategoryLookup",
                columns: new[] { "Id", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 2, false, 2, "Midfield", "2" },
                    { 1, false, 1, "Offense", "1" },
                    { 3, false, 3, "Defense", "3" }
                });

            migrationBuilder.InsertData(
                table: "PositionLookup",
                columns: new[] { "Id", "Abbreviation", "IsDisabled", "PositionCategoryId", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 1, "G", false, 1, 1, "Goalie", "G" },
                    { 17, "RF", false, 3, 7, "Right Forward", "RF" },
                    { 16, "RW", false, 3, 7, "Right Wing", "RW" },
                    { 15, "RF", false, 3, 7, "Right Forward", "RF" },
                    { 14, "RW", false, 3, 7, "Right Wing", "RW" },
                    { 12, "LF", false, 3, 6, "Left Forward", "LF" },
                    { 11, "LW", false, 3, 6, "Left Wing", "LW" },
                    { 13, "RM", false, 2, 7, "Right Midfielder", "RM" },
                    { 18, "ST", false, 3, 8, "Striker", "ST" },
                    { 10, "LM", false, 2, 6, "Left Midfielder", "LM" },
                    { 8, "CDM", false, 2, 5, "Center Defensive Midfielder", "CDM" },
                    { 7, "CM", false, 2, 5, "Center Midfielder", "CM" },
                    { 6, "CB", false, 1, 4, "Center Back", "CB" },
                    { 5, "LWB", false, 1, 3, "Left Wing Back", "LWB" },
                    { 4, "LB", false, 1, 3, "Left FullBack", "LB" },
                    { 3, "RWB", false, 1, 2, "Right Wing Back", "RWB" },
                    { 2, "RB", false, 1, 2, "Right FullBack", "RB" },
                    { 9, "CAM", false, 2, 5, "Center Attacking Midfielder", "CAM" },
                    { 19, "CF", false, 3, 8, "Center Forward", "CF" }
                });

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
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_Parent_AddressId",
                table: "Parent",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Parent_PhoneId",
                table: "Parent",
                column: "PhoneId",
                unique: true,
                filter: "[PhoneId] IS NOT NULL");

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
                name: "IX_Player_NationId",
                table: "Player",
                column: "NationId",
                unique: true,
                filter: "[NationId] IS NOT NULL");

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
                name: "IX_PlayerTeam_TeamId",
                table: "PlayerTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionLookup_PositionCategoryId",
                table: "PositionLookup",
                column: "PositionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_LeagueId",
                table: "Team",
                column: "LeagueId");
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
                name: "Image");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "PlayerParent");

            migrationBuilder.DropTable(
                name: "PlayerPosition");

            migrationBuilder.DropTable(
                name: "PlayerTeam");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Parent");

            migrationBuilder.DropTable(
                name: "PositionLookup");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "PositionCategoryLookup");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "NationLookup");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "PlayerAttributes");

            migrationBuilder.DropTable(
                name: "League");
        }
    }
}

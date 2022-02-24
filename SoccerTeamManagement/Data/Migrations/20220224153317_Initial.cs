﻿using System;
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
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
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
                    Foot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeakFootRating = table.Column<int>(type: "int", nullable: false),
                    FlareRating = table.Column<int>(type: "int", nullable: false),
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
                table: "Address",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "Country", "State", "ZipCode" },
                values: new object[,]
                {
                    { 901, "1600 Pennsylvania Avenue NW", null, "Washington", "United States", "DC", "20500" },
                    { 912, "416 Sid Snyder Avenue SW", null, "Olympia", "United States", "Washington", "98504" },
                    { 910, "501 N. 3rd Street", null, "Harrisburg", "United States", "Pennsylvania", "17120" },
                    { 909, "350 State Street", null, "Salt Lake City", "United States", "Utah", "84103" },
                    { 908, "2300 N Lincoln Blvd", null, "Oklahoma City", "United States", "Oklahoma", "73105" },
                    { 907, "1100 Congress Avenue", null, "Austin", "United States", "Texas", "78701" },
                    { 911, "200 E. Colfax Ave", null, "Denver", "United States", "Colorado", "80203" },
                    { 905, "4059 Mt. Lee Drive", null, "Hollywood", "United States", "California", "90068" },
                    { 904, "221 B Baker Street", null, "London", "England", "", "" },
                    { 903, "350 Fifth Avenue", null, "New York", "United States", "New York", "10118" },
                    { 902, "11 Wall Street", null, "New York", "United States", "New York", "10118" },
                    { 906, "400 S. Monroe Street", null, "Tallahassee", "United States", "Florida", "32399" }
                });

            migrationBuilder.InsertData(
                table: "Club",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 902, "Test Club 2" },
                    { 23, "Portland Timbers" },
                    { 24, "Real Salt Lake" },
                    { 25, "San Jose Earthquakes" },
                    { 26, "Seattle Sounders" },
                    { 27, "Toronto FC" },
                    { 28, "Vancouver Whitecaps" },
                    { 901, "Test Club 1" },
                    { 903, "Test Club 3" },
                    { 909, "Test Club 9" },
                    { 905, "Test Club 5" },
                    { 906, "Test Club 6" },
                    { 907, "Test Club 7" },
                    { 908, "Test Club 8" },
                    { 22, "Philadelphia Union" },
                    { 910, "Test Club 10" },
                    { 911, "Test Club 11" },
                    { 912, "Test Club 12" },
                    { 904, "Test Club 4" },
                    { 21, "Orlando City" },
                    { 19, "New York Red Bulls" },
                    { 5, "FC Cincinnati" },
                    { 1, "Atlanta United" },
                    { 2, "Austin FC" },
                    { 3, "Charlotte FC" },
                    { 4, "Chicago Fire FC" },
                    { 20, "New York City FC" },
                    { 6, "Colorado Rapids" },
                    { 7, "Columbus Crew" },
                    { 9, "FC Dallas" }
                });

            migrationBuilder.InsertData(
                table: "Club",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "D.C. United" },
                    { 11, "Sporting Kansas City" },
                    { 12, "LA Galaxy" },
                    { 13, "Los Angeles Football Club" },
                    { 14, "Inter Miami CF" },
                    { 15, "Minnesota United" },
                    { 16, "CF Montreal" },
                    { 17, "Nashville SC" },
                    { 18, "New England Revolution" },
                    { 10, "Houston Dynamo FC" }
                });

            migrationBuilder.InsertData(
                table: "League",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 907, "Test League 7" },
                    { 904, "Test League 4" },
                    { 905, "Test League 5" },
                    { 908, "Test League 8" },
                    { 903, "Test League 3" },
                    { 910, "Test League 10" },
                    { 911, "Test League 11" },
                    { 912, "Test League 12" },
                    { 909, "Test League 9" },
                    { 902, "Test League 2" },
                    { 906, "Test League 6" },
                    { 9, "Local League" },
                    { 8, "Serie A" },
                    { 7, "Eredivisie" },
                    { 6, "Ligue 1" },
                    { 5, "Bundesliga" },
                    { 4, "Serie A" },
                    { 3, "La Liga" },
                    { 2, "Premier League" },
                    { 1, "Major League Soccer" },
                    { 901, "Test League 1" }
                });

            migrationBuilder.InsertData(
                table: "NationLookup",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 170, "PW", "PLW", false, 585, "Palau", "585" },
                    { 169, "PK", "PAK", false, 586, "Pakistan", "586" },
                    { 168, "OM", "OMN", false, 512, "Oman", "512" },
                    { 167, "NO", "NOR", false, 578, "Norway", "578" },
                    { 166, "MP", "MNP", false, 580, "Northern Mariana Islands", "580" },
                    { 161, "NE", "NER", false, 562, "Niger", "562" },
                    { 164, "NF", "NFK", false, 574, "Norfolk Island", "574" },
                    { 163, "NU", "NIU", false, 570, "Niue", "570" },
                    { 162, "NG", "NGA", false, 566, "Nigeria", "566" },
                    { 171, "PS", "PSE", false, 275, "Palestine, State of", "275" },
                    { 160, "NI", "NIC", false, 558, "Nicaragua", "558" }
                });

            migrationBuilder.InsertData(
                table: "NationLookup",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 165, "MK", "MKD", false, 807, "North Macedonia", "807" },
                    { 172, "PA", "PAN", false, 591, "Panama", "591" },
                    { 176, "PH", "PHL", false, 608, "Philippines", "608" },
                    { 174, "PY", "PRY", false, 600, "Paraguay", "600" },
                    { 175, "PE", "PER", false, 0, "Peru", "" },
                    { 159, "NZ", "NZL", false, 554, "New Zealand", "554" },
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
                    { 173, "PG", "PNG", false, 598, "Papua New Guinea", "598" },
                    { 158, "NC", "NCL", false, 540, "New Caledonia", "540" },
                    { 153, "MM", "MMR", false, 104, "Myanmar", "104" },
                    { 156, "NP", "NPL", false, 524, "Nepal", "524" },
                    { 187, "SH", "SHN", false, 654, "Saint Helena, Ascension and Tristan da Cunha", "654" },
                    { 128, "LY", "LBY", false, 434, "Libya", "434" },
                    { 129, "LI", "LIE", false, 438, "Liechtenstein", "438" },
                    { 130, "LT", "LTU", false, 440, "Lithuania", "440" },
                    { 131, "LU", "LUX", false, 442, "Luxembourg", "442" },
                    { 132, "MO", "MAC", false, 446, "Macao", "446" },
                    { 133, "MG", "MDG", false, 450, "Madagascar", "450" },
                    { 134, "MW", "MWI", false, 454, "Malawi", "454" },
                    { 135, "MY", "MYS", false, 458, "Malaysia", "458" },
                    { 136, "MV", "MDV", false, 462, "Maldives", "462" },
                    { 137, "ML", "MLI", false, 466, "Mali", "466" },
                    { 138, "MT", "MLT", false, 470, "Malta", "470" },
                    { 139, "MH", "MHL", false, 584, "Marshall Islands", "584" },
                    { 157, "NL", "NLD", false, 528, "Netherlands", "528" },
                    { 140, "MQ", "MTQ", false, 474, "Martinique", "474" },
                    { 142, "MU", "MUS", false, 480, "Mauritius", "480" },
                    { 143, "YT", "MYT", false, 175, "Mayotte", "175" },
                    { 144, "MX", "MEX", false, 484, "Mexico", "484" },
                    { 145, "FM", "FSM", false, 583, "Micronesia (Federated States of)", "583" },
                    { 146, "MD", "MDA", false, 498, "Moldova (the Republic of)", "498" },
                    { 147, "MC", "MCO", false, 492, "Monaco", "492" },
                    { 148, "MN", "MNG", false, 496, "Mongolia", "496" }
                });

            migrationBuilder.InsertData(
                table: "NationLookup",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 149, "ME", "MNE", false, 499, "Montenegro", "499" },
                    { 150, "MS", "MSR", false, 0, "Montserrat", "" },
                    { 151, "MA", "MAR", false, 504, "Morocco", "504" },
                    { 152, "MZ", "MOZ", false, 508, "Mozambique", "508" },
                    { 154, "NA", "NAM", false, 516, "Namibia", "516" },
                    { 155, "NR", "NRU", false, 520, "Nauru", "520" },
                    { 141, "MR", "MRT", false, 478, "Mauritania", "478" },
                    { 188, "KN", "KNA", false, 659, "Saint Kitts and Nevis", "659" },
                    { 224, "TK", "TKL", false, 772, "Tokelau", "772" },
                    { 190, "MF", "MAF", false, 663, "Saint Martin (French part)", "663" },
                    { 223, "TG", "TGO", false, 768, "Togo", "768" },
                    { 127, "LR", "LBR", false, 430, "Liberia", "430" },
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
                    { 237, "US", "USA", false, 1, "United States of America", "840" },
                    { 238, "UY", "URY", false, 858, "Uruguay", "858" },
                    { 239, "UZ", "UZB", false, 860, "Uzbekistan", "860" },
                    { 240, "VU", "VUT", false, 548, "Vanuatu", "548" },
                    { 241, "VE", "VEN", false, 862, "Venezuela (Bolivarian Republic of)", "862" },
                    { 242, "VN", "VNM", false, 704, "Viet Nam", "704" },
                    { 243, "VG", "VGB", false, 92, "Virgin Islands (British)", "92" },
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
                    { 191, "PM", "SPM", false, 666, "Saint Pierre and Miquelon", "666" }
                });

            migrationBuilder.InsertData(
                table: "NationLookup",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
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
                    { 189, "LC", "LCA", false, 662, "Saint Lucia", "662" },
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
                    { 126, "LS", "LSO", false, 426, "Lesotho", "426" },
                    { 102, "HU", "HUN", false, 348, "Hungary", "348" },
                    { 124, "LV", "LVA", false, 428, "Latvia", "428" },
                    { 33, "IO", "IOT", false, 86, "British Indian Ocean Territory", "86" },
                    { 34, "BN", "BRN", false, 96, "Brunei Darussalam", "96" },
                    { 35, "BG", "BGR", false, 100, "Bulgaria", "100" },
                    { 36, "BF", "BFA", false, 854, "Burkina Faso", "854" },
                    { 37, "BI", "BDI", false, 108, "Burundi", "108" },
                    { 38, "CV", "CPV", false, 132, "Cabo Verde", "132" },
                    { 39, "KH", "KHM", false, 116, "Cambodia", "116" },
                    { 40, "CM", "CMR", false, 120, "Cameroon", "120" },
                    { 41, "CA", "CAN", false, 124, "Canada", "124" },
                    { 42, "KY", "CYM", false, 136, "Cayman Islands", "136" },
                    { 43, "CF", "CAF", false, 140, "Central African Republic", "140" }
                });

            migrationBuilder.InsertData(
                table: "NationLookup",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 44, "TD", "TCD", false, 148, "Chad", "148" },
                    { 45, "CL", "CHL", false, 152, "Chile", "152" },
                    { 46, "CN", "CHN", false, 156, "China", "156" },
                    { 47, "CX", "CXR", false, 162, "Christmas Island", "162" },
                    { 48, "CC", "CCK", false, 166, "Cocos (Keeling) Islands", "166" },
                    { 125, "LB", "LBN", false, 0, "Lebanon", "" },
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
                    { 13, "AU", "AUS", false, 36, "Australia", "36" },
                    { 60, "CI", "CIV", false, 384, "Côte d'Ivoire", "384" },
                    { 14, "AT", "AUT", false, 40, "Austria", "40" },
                    { 16, "BS", "BHS", false, 44, "Bahamas", "44" },
                    { 17, "BH", "BHR", false, 48, "Bahrain", "48" },
                    { 18, "BD", "BGD", false, 50, "Bangladesh", "50" },
                    { 19, "BB", "BRB", false, 52, "Barbados", "52" },
                    { 20, "BY", "BLR", false, 112, "Belarus", "112" },
                    { 21, "BE", "BEL", false, 56, "Belgium", "56" },
                    { 22, "BZ", "BLZ", false, 84, "Belize", "84" }
                });

            migrationBuilder.InsertData(
                table: "NationLookup",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 23, "BJ", "BEN", false, 204, "Benin", "204" },
                    { 24, "BM", "BMU", false, 60, "Bermuda", "60" },
                    { 25, "AX", "ALA", false, 248, "Åland Islands", "248" },
                    { 26, "BT", "BTN", false, 64, "Bhutan", "64" },
                    { 27, "BO", "BOL", false, 68, "Bolivia (Plurinational State of)", "68" },
                    { 28, "BQ", "BES", false, 535, "Bonaire, Sint Eustatius and Saba", "535" },
                    { 15, "AZ", "AZE", false, 31, "Azerbaijan", "31" },
                    { 61, "DK", "DNK", false, 208, "Denmark", "208" },
                    { 49, "CO", "COL", false, 170, "Colombia", "170" },
                    { 63, "DM", "DMA", false, 212, "Dominica", "212" },
                    { 96, "GY", "GUY", false, 328, "Guyana", "328" },
                    { 97, "HT", "HTI", false, 332, "Haiti", "332" },
                    { 98, "HM", "HMD", false, 334, "Heard Island and McDonald Islands", "334" },
                    { 99, "VA", "VAT", false, 336, "Holy See", "336" },
                    { 100, "HN", "HND", false, 0, "Honduras", "" },
                    { 101, "HK", "HKG", false, 344, "Hong Kong", "344" },
                    { 103, "IS", "ISL", false, 352, "Iceland", "352" },
                    { 104, "IN", "IND", false, 356, "India", "356" },
                    { 105, "ID", "IDN", false, 360, "Indonesia", "360" },
                    { 106, "IR", "IRN", false, 364, "Iran (Islamic Republic of)", "364" },
                    { 62, "DJ", "DJI", false, 262, "Djibouti", "262" },
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
                    { 119, "KP", "PRK", false, 408, "Korea (the Democratic People's Republic of)", "408" },
                    { 120, "KR", "KOR", false, 410, "Korea (the Republic of)", "410" },
                    { 121, "KW", "KWT", false, 414, "Kuwait", "414" },
                    { 122, "KG", "KGZ", false, 417, "Kyrgyzstan", "417" },
                    { 123, "LA", "LAO", false, 418, "Lao People's Democratic Republic", "418" },
                    { 95, "GW", "GNB", false, 624, "Guinea-Bissau", "624" },
                    { 94, "GN", "GIN", false, 324, "Guinea", "324" },
                    { 107, "IQ", "IRQ", false, 368, "Iraq", "368" },
                    { 92, "GT", "GTM", false, 320, "Guatemala", "320" },
                    { 64, "DO", "DOM", false, 214, "Dominican Republic", "214" }
                });

            migrationBuilder.InsertData(
                table: "NationLookup",
                columns: new[] { "Id", "Alpha2Code", "Alpha3Code", "IsDisabled", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 93, "GG", "GGY", false, 831, "Guernsey", "831" },
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
                    { 65, "EC", "ECU", false, 218, "Ecuador", "218" },
                    { 79, "PF", "PYF", false, 258, "French Polynesia", "258" },
                    { 91, "GU", "GUM", false, 316, "Guam", "316" },
                    { 90, "GP", "GLP", false, 312, "Guadeloupe", "312" },
                    { 89, "GD", "GRD", false, 308, "Grenada", "308" },
                    { 88, "GL", "GRL", false, 304, "Greenland", "304" },
                    { 86, "GI", "GIB", false, 292, "Gibraltar", "292" },
                    { 85, "GH", "GHA", false, 288, "Ghana", "288" },
                    { 87, "GR", "GRC", false, 300, "Greece", "300" },
                    { 84, "DE", "DEU", false, 276, "Germany", "276" },
                    { 83, "GE", "GEO", false, 268, "Georgia", "268" },
                    { 82, "GM", "GMB", false, 270, "Gambia", "270" },
                    { 81, "GA", "GAB", false, 266, "Gabon", "266" },
                    { 80, "TF", "ATF", false, 260, "French Southern Territories", "260" },
                    { 78, "GF", "GUF", false, 254, "French Guiana", "254" }
                });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "Id", "AreaCode", "CountryCode", "Extension", "Number", "PhoneType" },
                values: new object[,]
                {
                    { 908, "123", "1", null, "9028880", "Cell" },
                    { 912, "234", "1", null, "9028880", "Cell" },
                    { 911, "", "49", null, "9028880", "Cell" },
                    { 910, "789", "1", null, "9028880", "Home" },
                    { 909, "456", "1", null, "9028880", "Cell" },
                    { 913, "837", "1", null, "9028880", "Cell" },
                    { 907, "719", "1", null, "9028880", "Work" },
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
                values: new object[] { 912, 96, 96, 96, 96, 96, 96, 96, 96, 96, 96, 96, 96, 96, 0, 96, 96, 96, 96, 96, 96, 96, 96, 96, 912, 96, 96, 96, 96, 96, 96, 96, 96, 96, 96, 96 });

            migrationBuilder.InsertData(
                table: "PlayerAttributes",
                columns: new[] { "Id", "Acceleration", "Aggression", "Agility", "Balance", "BallControl", "Composure", "Crossing", "Curve", "DefensiveAwareness", "Diving", "Dribbling", "Finishing", "FreeKickAccuracy", "GoaliePositioning", "Handling", "HeadingAccuracy", "Interceptions", "Jumping", "Kicking", "LongPassing", "LongShots", "OffensivePositioning", "Penalties", "PlayerId", "Reactions", "Reflexes", "ShortPassing", "ShotPower", "SlidingTackle", "SprintSpeed", "Stamina", "StandingTackle", "Strength", "Vision", "Volleys" },
                values: new object[,]
                {
                    { 911, 94, 94, 94, 94, 94, 94, 94, 94, 94, 94, 94, 94, 94, 0, 94, 94, 94, 94, 94, 94, 94, 94, 94, 911, 94, 94, 94, 94, 94, 94, 94, 94, 94, 94, 94 },
                    { 910, 92, 92, 92, 92, 92, 92, 92, 92, 92, 92, 92, 92, 92, 0, 92, 92, 92, 92, 92, 92, 92, 92, 92, 910, 92, 92, 92, 92, 92, 92, 92, 92, 92, 92, 92 },
                    { 909, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 0, 90, 90, 90, 90, 90, 90, 90, 90, 90, 909, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90, 90 },
                    { 908, 52, 52, 52, 52, 52, 52, 52, 52, 52, 52, 52, 52, 52, 0, 52, 52, 52, 52, 52, 52, 52, 52, 52, 908, 52, 52, 52, 52, 52, 52, 52, 52, 52, 52, 52 },
                    { 907, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 0, 50, 50, 50, 50, 50, 50, 50, 50, 50, 907, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50, 50 },
                    { 905, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 0, 60, 60, 60, 60, 60, 60, 60, 60, 60, 902, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60 },
                    { 904, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 0, 72, 72, 72, 72, 72, 72, 72, 72, 72, 902, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72, 72 },
                    { 903, 70, 70, 70, 70, 70, 70, 70, 70, 70, 70, 70, 70, 70, 0, 70, 70, 70, 70, 70, 70, 70, 70, 70, 902, 70, 70, 70, 70, 70, 70, 70, 70, 70, 70, 70 },
                    { 902, 82, 82, 82, 82, 82, 82, 82, 82, 82, 82, 82, 82, 82, 0, 82, 82, 82, 82, 82, 82, 82, 82, 82, 902, 82, 82, 82, 82, 82, 82, 82, 82, 82, 82, 82 },
                    { 901, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 0, 80, 80, 80, 80, 80, 80, 80, 80, 80, 901, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80 },
                    { 906, 62, 62, 62, 62, 62, 62, 62, 62, 62, 62, 62, 62, 62, 0, 62, 62, 62, 62, 62, 62, 62, 62, 62, 906, 62, 62, 62, 62, 62, 62, 62, 62, 62, 62, 62 }
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
                table: "Parent",
                columns: new[] { "Id", "AddressId", "FirstName", "IsAdult", "LastName", "NickName", "PhoneId" },
                values: new object[,]
                {
                    { 911, 911, "TestParentFirst11", true, "TestParentLast11", "TestParent 11", 911 },
                    { 912, 912, "TestParentFirst12", true, "TestParentLast12", "TestParent 12", 912 },
                    { 910, 910, "TestParentFirst10", true, "TestParentLast10", "TestParent 10", 910 },
                    { 909, 909, "TestParentFirst9", true, "TestParentLast9", "TestParent 9", 909 },
                    { 907, 907, "TestParentFirst7", true, "TestParentLast7", "TestParent 7", 907 },
                    { 906, 906, "TestParentFirst6", true, "TestParentLast6", "TestParent 6", 906 },
                    { 908, 908, "TestParentFirst8", true, "TestParentLast8", "TestParent 8", 908 },
                    { 904, 904, "TestParentFirst4", true, "TestParentLast4", "TestParent 4", 904 },
                    { 903, 903, "TestParentFirst3", true, "TestParentLast3", "TestParent 3", 903 },
                    { 902, 902, "TestParentFirst2", true, "TestParentLast2", "TestParent 2", 902 },
                    { 901, 901, "TestParentFirst1", true, "TestParentLast1", "TestParent 1", 901 },
                    { 905, 905, "TestParentFirst5", true, "TestParentLast5", "TestParent 5", 905 }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Id", "AddressId", "AttributesId", "FirstName", "FlareRating", "Foot", "Height", "IsAdult", "LastName", "NationId", "NickName", "PhoneId", "WeakFootRating", "Weight" },
                values: new object[,]
                {
                    { 912, 912, 912, "Bob", 2, "Left", 59, false, "Smith", 210, "BoSmith", 912, 2, 180 },
                    { 909, 909, 909, "Tony", 3, "Left", 72, true, "Stark", 84, "Iron Man", 909, 1, 200 },
                    { 910, 910, 910, "Thor", 5, "Right", 73, false, "Odinson", 10, "Thor", 910, 2, 160 },
                    { 911, 911, 911, "Steve", 3, "Right", 74, false, "Rodgers", 235, "Captain America", 911, 1, 170 },
                    { 905, 905, 905, "Diana", 3, "Right", 68, true, "Prince", 237, "Wonder Woman", 905, 1, 155 },
                    { 907, 907, 907, "Natasha", 4, "Right", 70, false, "Romanoff", 237, "Black Widow", 907, 1, 210 },
                    { 903, 903, 903, "Bruce", 3, "Left", 66, false, "Wayne", 41, "Batman", 903, 1, 175 },
                    { 902, 902, 902, "Peter", 3, "Right", 65, false, "Parker", 32, "Spiderman", 902, 4, 185 },
                    { 901, 901, 901, "Clark", 2, "Right", 64, false, "Kent", 10, "Superman", 901, 1, 210 },
                    { 908, 908, 908, "Bruce", 3, "Right", 71, false, "Banner", 77, "Hulk", 908, 4, 190 },
                    { 904, 904, 904, "Jack", 1, "Right", 67, false, "Reacher", 49, "Reacher", 904, 5, 165 },
                    { 906, 906, 906, "Oliver", 3, "Left", 69, true, "Queen", 237, "Green Arrow", 906, 3, 195 }
                });

            migrationBuilder.InsertData(
                table: "PositionLookup",
                columns: new[] { "Id", "Abbreviation", "IsDisabled", "PositionCategoryId", "SortOrder", "Text", "Value" },
                values: new object[,]
                {
                    { 19, "CF", false, 3, 8, "Center Forward", "CF" },
                    { 1, "G", false, 1, 1, "Goalie", "G" },
                    { 17, "RF", false, 3, 7, "Right Forward", "RF" },
                    { 16, "RW", false, 3, 7, "Right Wing", "RW" },
                    { 15, "RF", false, 3, 7, "Right Forward", "RF" },
                    { 14, "RW", false, 3, 7, "Right Wing", "RW" },
                    { 12, "LF", false, 3, 6, "Left Forward", "LF" },
                    { 11, "LW", false, 3, 6, "Left Wing", "LW" },
                    { 10, "LM", false, 2, 6, "Left Midfielder", "LM" },
                    { 13, "RM", false, 2, 7, "Right Midfielder", "RM" },
                    { 8, "CDM", false, 2, 5, "Center Defensive Midfielder", "CDM" },
                    { 7, "CM", false, 2, 5, "Center Midfielder", "CM" },
                    { 6, "CB", false, 1, 4, "Center Back", "CB" },
                    { 5, "LWB", false, 1, 3, "Left Wing Back", "LWB" },
                    { 4, "LB", false, 1, 3, "Left FullBack", "LB" },
                    { 3, "RWB", false, 1, 2, "Right Wing Back", "RWB" },
                    { 2, "RB", false, 1, 2, "Right FullBack", "RB" },
                    { 9, "CAM", false, 2, 5, "Center Attacking Midfielder", "CAM" }
                });

            migrationBuilder.InsertData(
                table: "PositionLookup",
                columns: new[] { "Id", "Abbreviation", "IsDisabled", "PositionCategoryId", "SortOrder", "Text", "Value" },
                values: new object[] { 18, "ST", false, 3, 8, "Striker", "ST" });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "ClubId", "Name" },
                values: new object[,]
                {
                    { 910, 910, "Test Team 10" },
                    { 912, 912, "Test Team 12" },
                    { 911, 911, "Test Team 11" },
                    { 924, 910, "Test Team 24" },
                    { 923, 909, "Test Team 23" },
                    { 922, 908, "Test Team 22" },
                    { 21, 21, "Orlando City" },
                    { 20, 20, "New York City FC" },
                    { 19, 19, "New York Red Bulls" },
                    { 18, 18, "New England Revolution" },
                    { 17, 17, "Nashville SC" },
                    { 16, 16, "CF Montreal" },
                    { 15, 15, "Minnesota United" },
                    { 14, 14, "Inter Miami CF" },
                    { 13, 13, "Los Angeles Football Team" },
                    { 22, 22, "Philadelphia Union" },
                    { 12, 12, "LA Galaxy" },
                    { 10, 10, "Houston Dynamo FC" },
                    { 9, 9, "FC Dallas" },
                    { 8, 8, "D.C. United" },
                    { 7, 7, "Columbus Crew" },
                    { 6, 6, "Colorado Rapids" },
                    { 5, 5, "FC Cincinnati" },
                    { 4, 4, "Chicago Fire FC" },
                    { 3, 3, "Charlotte FC" },
                    { 2, 2, "Austin FC" },
                    { 11, 11, "Sporting Kansas City" },
                    { 909, 909, "Test Team 9" },
                    { 23, 23, "Portland Timbers" },
                    { 25, 25, "San Jose Earthquakes" },
                    { 908, 908, "Test Team 8" },
                    { 921, 907, "Test Team 21" },
                    { 907, 907, "Test Team 7" },
                    { 920, 906, "Test Team 20" },
                    { 906, 906, "Test Team 6" },
                    { 919, 905, "Test Team 19" },
                    { 905, 905, "Test Team 5" },
                    { 918, 904, "Test Team 18" },
                    { 904, 904, "Test Team 4" },
                    { 24, 24, "Real Salt Lake" },
                    { 917, 903, "Test Team 17" }
                });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "Id", "ClubId", "Name" },
                values: new object[,]
                {
                    { 916, 902, "Test Team 16" },
                    { 902, 902, "Test Team 2" },
                    { 915, 901, "Test Team 15" },
                    { 914, 901, "Test Team 14" },
                    { 913, 901, "Test Team 13" },
                    { 901, 901, "Test Team 1" },
                    { 28, 28, "Vancouver Whitecaps" },
                    { 27, 27, "Toronto FC" },
                    { 26, 26, "Seattle Sounders" },
                    { 903, 903, "Test Team 3" },
                    { 1, 1, "Atlanta United" }
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
                    { 906, 905, false },
                    { 1, 28, true },
                    { 902, 906, true },
                    { 902, 907, true },
                    { 907, 907, false },
                    { 902, 908, true },
                    { 907, 908, false },
                    { 903, 909, true },
                    { 908, 909, false },
                    { 908, 910, false },
                    { 903, 911, true },
                    { 909, 911, false },
                    { 909, 912, false },
                    { 906, 906, false },
                    { 1, 27, true },
                    { 903, 910, true },
                    { 1, 25, true },
                    { 1, 2, true },
                    { 1, 3, true },
                    { 1, 4, true },
                    { 1, 5, true },
                    { 1, 6, true },
                    { 1, 7, true },
                    { 1, 8, true },
                    { 1, 10, true },
                    { 1, 11, true },
                    { 1, 12, true },
                    { 1, 13, true },
                    { 1, 9, true },
                    { 1, 15, true },
                    { 1, 24, true },
                    { 1, 23, true }
                });

            migrationBuilder.InsertData(
                table: "LeagueTeam",
                columns: new[] { "LeagueId", "TeamId", "IsPrimary" },
                values: new object[,]
                {
                    { 1, 14, true },
                    { 1, 21, true },
                    { 1, 20, true },
                    { 1, 22, true },
                    { 1, 18, true },
                    { 1, 17, true },
                    { 1, 16, true },
                    { 1, 19, true },
                    { 1, 26, true }
                });

            migrationBuilder.InsertData(
                table: "PlayerParent",
                columns: new[] { "ParentId", "PlayerId" },
                values: new object[,]
                {
                    { 911, 912 },
                    { 903, 905 },
                    { 910, 911 },
                    { 908, 910 },
                    { 907, 909 },
                    { 904, 908 },
                    { 904, 907 },
                    { 903, 906 },
                    { 902, 904 },
                    { 902, 903 },
                    { 901, 902 },
                    { 901, 901 },
                    { 912, 901 }
                });

            migrationBuilder.InsertData(
                table: "PlayerPosition",
                columns: new[] { "PlayerId", "PositionId", "IsPrimary" },
                values: new object[,]
                {
                    { 909, 19, false },
                    { 901, 2, false },
                    { 901, 1, true },
                    { 903, 5, true },
                    { 905, 19, false },
                    { 904, 6, true },
                    { 908, 13, true },
                    { 911, 13, true },
                    { 906, 11, true },
                    { 909, 11, true },
                    { 907, 12, true },
                    { 910, 12, true },
                    { 912, 14, true },
                    { 912, 15, false },
                    { 905, 18, true },
                    { 901, 3, false },
                    { 902, 4, true }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayer",
                columns: new[] { "PlayerId", "TeamId", "DepartedTeam", "JoinedTeam" },
                values: new object[,]
                {
                    { 912, 904, new DateTimeOffset(new DateTime(2022, 2, 24, 10, 33, 16, 965, DateTimeKind.Unspecified).AddTicks(4186), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 911, 903, new DateTimeOffset(new DateTime(2022, 2, 24, 10, 33, 16, 965, DateTimeKind.Unspecified).AddTicks(4182), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 910, 903, new DateTimeOffset(new DateTime(2022, 2, 24, 10, 33, 16, 965, DateTimeKind.Unspecified).AddTicks(4177), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "TeamPlayer",
                columns: new[] { "PlayerId", "TeamId", "DepartedTeam", "JoinedTeam" },
                values: new object[,]
                {
                    { 909, 903, new DateTimeOffset(new DateTime(2022, 2, 24, 10, 33, 16, 965, DateTimeKind.Unspecified).AddTicks(4172), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 901, 901, new DateTimeOffset(new DateTime(2022, 2, 24, 10, 33, 16, 962, DateTimeKind.Unspecified).AddTicks(4665), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 908, 903, new DateTimeOffset(new DateTime(2022, 2, 24, 10, 33, 16, 965, DateTimeKind.Unspecified).AddTicks(4168), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 901, 905, new DateTimeOffset(new DateTime(2022, 2, 24, 10, 33, 16, 965, DateTimeKind.Unspecified).AddTicks(4190), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 907, 902, new DateTimeOffset(new DateTime(2022, 2, 24, 10, 33, 16, 965, DateTimeKind.Unspecified).AddTicks(4165), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 906, 902, new DateTimeOffset(new DateTime(2022, 2, 24, 10, 33, 16, 965, DateTimeKind.Unspecified).AddTicks(4160), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 902, 901, new DateTimeOffset(new DateTime(2022, 2, 24, 10, 33, 16, 965, DateTimeKind.Unspecified).AddTicks(4044), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 905, 902, new DateTimeOffset(new DateTime(2022, 2, 24, 10, 33, 16, 965, DateTimeKind.Unspecified).AddTicks(4152), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 903, 901, new DateTimeOffset(new DateTime(2022, 2, 24, 10, 33, 16, 965, DateTimeKind.Unspecified).AddTicks(4134), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 904, 901, new DateTimeOffset(new DateTime(2022, 2, 24, 10, 33, 16, 965, DateTimeKind.Unspecified).AddTicks(4148), new TimeSpan(0, -5, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
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
                name: "IX_LeagueTeam_TeamId",
                table: "LeagueTeam",
                column: "TeamId");

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
                column: "NationId");

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
                name: "IX_PositionLookup_PositionCategoryId",
                table: "PositionLookup",
                column: "PositionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_ClubId",
                table: "Team",
                column: "ClubId");

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
                name: "Image");

            migrationBuilder.DropTable(
                name: "LeagueTeam");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "PlayerParent");

            migrationBuilder.DropTable(
                name: "PlayerPosition");

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
                name: "Club");
        }
    }
}
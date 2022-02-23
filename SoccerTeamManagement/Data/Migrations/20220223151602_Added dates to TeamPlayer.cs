using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerTeamManagement.Data.Migrations
{
    public partial class AddeddatestoTeamPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DepartedTeam",
                table: "PlayerTeam",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "JoinedTeam",
                table: "PlayerTeam",
                type: "datetimeoffset",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartedTeam",
                table: "PlayerTeam");

            migrationBuilder.DropColumn(
                name: "JoinedTeam",
                table: "PlayerTeam");
        }
    }
}

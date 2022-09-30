using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNFSocProgCompSys.Migrations
{
    public partial class CompetitionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    CompetitionID = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompetitionName = table.Column<string>(type: "TEXT", nullable: false),
                    CompetitionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompetitionStartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompetitionEndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompetitionLocation = table.Column<string>(type: "TEXT", nullable: false),
                    CompetitionDescription = table.Column<string>(type: "TEXT", nullable: true),
                    CompetitionMaxTeamSize = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.CompetitionID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competitions");
        }
    }
}

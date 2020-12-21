using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace market.Migrations
{
    public partial class AddChild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    GenderType = table.Column<int>(type: "INTEGER", nullable: false),
                    Virginity = table.Column<bool>(type: "INTEGER", nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    Race = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nationality = table.Column<string>(type: "TEXT", nullable: true),
                    SkinTone = table.Column<int>(type: "INTEGER", nullable: false),
                    EyeColor = table.Column<int>(type: "INTEGER", nullable: false),
                    HairColor = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Children");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace market.Migrations
{
    public partial class RemoveAgeFromChild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Children");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Children",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}

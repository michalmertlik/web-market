using Microsoft.EntityFrameworkCore.Migrations;

namespace market.Migrations
{
    public partial class ChangeGenderChild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenderType",
                table: "Children",
                newName: "Gender");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Children",
                newName: "GenderType");
        }
    }
}

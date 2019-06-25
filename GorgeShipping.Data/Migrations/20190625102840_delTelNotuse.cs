using Microsoft.EntityFrameworkCore.Migrations;

namespace GorgeShipping.Data.Migrations
{
    public partial class delTelNotuse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelNo",
                table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TelNo",
                table: "Addresses",
                nullable: true);
        }
    }
}

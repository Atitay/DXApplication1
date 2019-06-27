using Microsoft.EntityFrameworkCore.Migrations;

namespace GorgeShipping.Data.Migrations
{
    public partial class addTelDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "TelephoneNumbers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "TelephoneNumbers");
        }
    }
}

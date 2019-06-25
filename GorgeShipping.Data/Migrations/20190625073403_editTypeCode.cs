using Microsoft.EntityFrameworkCore.Migrations;

namespace GorgeShipping.Data.Migrations
{
    public partial class editTypeCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

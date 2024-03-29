﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace GorgeShipping.Data.Migrations
{
    public partial class addNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Addresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Addresses");
        }
    }
}

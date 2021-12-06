using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Login.Migrations
{
    public partial class Salt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priv",
                table: "usertable");

            migrationBuilder.AddColumn<string>(
                name: "Nick",
                table: "usertable",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "usertable",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "salt",
                table: "usertable",
                type: "varbinary(4000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nick",
                table: "usertable");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "usertable");

            migrationBuilder.DropColumn(
                name: "salt",
                table: "usertable");

            migrationBuilder.AddColumn<int>(
                name: "Priv",
                table: "usertable",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

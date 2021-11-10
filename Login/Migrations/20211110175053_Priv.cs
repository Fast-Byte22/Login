using Microsoft.EntityFrameworkCore.Migrations;

namespace Login.Migrations
{
    public partial class Priv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priv",
                table: "usertable",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priv",
                table: "usertable");
        }
    }
}

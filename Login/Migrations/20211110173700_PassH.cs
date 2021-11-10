using Microsoft.EntityFrameworkCore.Migrations;

namespace Login.Migrations
{
    public partial class PassH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PassHash",
                table: "usertable",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassHash",
                table: "usertable");
        }
    }
}

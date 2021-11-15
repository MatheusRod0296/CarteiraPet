using Microsoft.EntityFrameworkCore.Migrations;

namespace CarteiraPet.Infra.Identity.Data.Migrations
{
    public partial class AddNameForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FriendlyName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FriendlyName",
                table: "AspNetUsers");
        }
    }
}

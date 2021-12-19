using Microsoft.EntityFrameworkCore.Migrations;

namespace CarteiraPet.Infra.Domain.Migrations
{
    public partial class photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Pet");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Pet",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Pet");

            migrationBuilder.AddColumn<decimal>(
                name: "Age",
                table: "Pet",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

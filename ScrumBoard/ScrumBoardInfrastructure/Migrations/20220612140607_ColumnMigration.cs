using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumBoardInfrastructure.Migrations
{
    public partial class ColumnMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "BoardColumns",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "BoardColumns");
        }
    }
}

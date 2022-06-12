using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrumBoardInfrastructure.Migrations
{
    public partial class IdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardCards",
                table: "BoardCards");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Boards",
                newName: "BoardId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BoardColumns",
                newName: "ColumnId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BoardCards",
                newName: "ColumnId");

            migrationBuilder.AlterColumn<int>(
                name: "ColumnId",
                table: "BoardCards",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "BoardCards",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardCards",
                table: "BoardCards",
                column: "CardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardCards",
                table: "BoardCards");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "BoardCards");

            migrationBuilder.RenameColumn(
                name: "BoardId",
                table: "Boards",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ColumnId",
                table: "BoardColumns",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ColumnId",
                table: "BoardCards",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BoardCards",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardCards",
                table: "BoardCards",
                column: "Id");
        }
    }
}

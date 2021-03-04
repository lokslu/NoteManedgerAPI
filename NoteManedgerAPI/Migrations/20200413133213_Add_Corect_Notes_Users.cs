using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteManedgerAPI.Migrations
{
    public partial class Add_Corect_Notes_Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "Notes",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "color",
                table: "Notes",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "body",
                table: "Notes",
                newName: "Body");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Notes",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "UsetId",
                table: "Notes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "UsetId",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Notes",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Notes",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Notes",
                newName: "body");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Notes",
                newName: "id");
        }
    }
}

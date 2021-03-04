using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteManedgerAPI.Migrations
{
    public partial class fixtype_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsetId",
                table: "Notes",
                newName: "usetId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Notes",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Notes",
                newName: "orderId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "usetId",
                table: "Notes",
                newName: "UsetId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Notes",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "Notes",
                newName: "OrderId");

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
        }
    }
}

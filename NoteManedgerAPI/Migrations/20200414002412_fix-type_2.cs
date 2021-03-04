using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteManedgerAPI.Migrations
{
    public partial class fixtype_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Orderid",
                table: "Notes",
                newName: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Notes",
                newName: "Orderid");
        }
    }
}

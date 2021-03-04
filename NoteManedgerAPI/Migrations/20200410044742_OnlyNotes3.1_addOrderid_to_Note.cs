using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteManedgerAPI.Migrations
{
    public partial class OnlyNotes31_addOrderid_to_Note : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Orderid",
                table: "Notes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Orderid",
                table: "Notes");
        }
    }
}

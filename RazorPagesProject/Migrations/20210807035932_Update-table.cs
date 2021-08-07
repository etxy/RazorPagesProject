using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesProject.Migrations
{
    public partial class Updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingServiceOption_ServiceOption_ServiceOptionsId",
                table: "BookingServiceOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOption",
                table: "ServiceOption");

            migrationBuilder.RenameTable(
                name: "ServiceOption",
                newName: "ServiceOptions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOptions",
                table: "ServiceOptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingServiceOption_ServiceOptions_ServiceOptionsId",
                table: "BookingServiceOption",
                column: "ServiceOptionsId",
                principalTable: "ServiceOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingServiceOption_ServiceOptions_ServiceOptionsId",
                table: "BookingServiceOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOptions",
                table: "ServiceOptions");

            migrationBuilder.RenameTable(
                name: "ServiceOptions",
                newName: "ServiceOption");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOption",
                table: "ServiceOption",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingServiceOption_ServiceOption_ServiceOptionsId",
                table: "BookingServiceOption",
                column: "ServiceOptionsId",
                principalTable: "ServiceOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

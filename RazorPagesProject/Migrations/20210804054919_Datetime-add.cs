using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesProject.Migrations
{
    public partial class Datetimeadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReservationDateTime",
                table: "Booking",
                newName: "CheckOutDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckInDateTime",
                table: "Booking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckInDateTime",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "CheckOutDateTime",
                table: "Booking",
                newName: "ReservationDateTime");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesProject.Migrations
{
    public partial class ServiceOptionTablecreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOption_Booking_BookingID",
                table: "ServiceOption");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOption_BookingID",
                table: "ServiceOption");

            migrationBuilder.DropColumn(
                name: "BookingID",
                table: "ServiceOption");

            migrationBuilder.CreateTable(
                name: "BookingServiceOption",
                columns: table => new
                {
                    BookingsID = table.Column<int>(type: "int", nullable: false),
                    ServiceOptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingServiceOption", x => new { x.BookingsID, x.ServiceOptionsId });
                    table.ForeignKey(
                        name: "FK_BookingServiceOption_Booking_BookingsID",
                        column: x => x.BookingsID,
                        principalTable: "Booking",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingServiceOption_ServiceOption_ServiceOptionsId",
                        column: x => x.ServiceOptionsId,
                        principalTable: "ServiceOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingServiceOption_ServiceOptionsId",
                table: "BookingServiceOption",
                column: "ServiceOptionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingServiceOption");

            migrationBuilder.AddColumn<int>(
                name: "BookingID",
                table: "ServiceOption",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOption_BookingID",
                table: "ServiceOption",
                column: "BookingID");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOption_Booking_BookingID",
                table: "ServiceOption",
                column: "BookingID",
                principalTable: "Booking",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesProject.Migrations
{
    public partial class Initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumOfDays",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumOfDays",
                table: "Booking");
        }
    }
}

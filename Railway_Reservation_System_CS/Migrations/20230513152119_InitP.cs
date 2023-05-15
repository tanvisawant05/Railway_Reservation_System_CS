using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Railway_Reservation_System_CS.Migrations
{
    /// <inheritdoc />
    public partial class InitP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Passengers",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Passengers",
                newName: "Age");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Passengers",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Passengers",
                newName: "age");
        }
    }
}

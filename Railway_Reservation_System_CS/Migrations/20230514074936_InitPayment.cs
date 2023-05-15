using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Railway_Reservation_System_CS.Migrations
{
    /// <inheritdoc />
    public partial class InitPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Reservations_ReservationId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_ReservationId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Passengers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Passengers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "PassengerReservation",
                columns: table => new
                {
                    PassengerId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerReservation", x => new { x.PassengerId, x.ReservationId });
                    table.ForeignKey(
                        name: "FK_PassengerReservation_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "PassengerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassengerReservation_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassengerReservation_ReservationId",
                table: "PassengerReservation",
                column: "ReservationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassengerReservation");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Passengers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Passengers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_ReservationId",
                table: "Passengers",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Reservations_ReservationId",
                table: "Passengers",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId");
        }
    }
}

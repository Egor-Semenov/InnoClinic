using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DbUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppointmentStatuses",
                columns: new[] { "StatusId", "Status" },
                values: new object[] { 3, "Pending" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "ServiceCost", "ServiceName" },
                values: new object[] { 101, 100.0, "PediatricCheckup" });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "SpecializationId", "SpecializationName" },
                values: new object[] { 1, "Pediatrics" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppointmentStatuses",
                keyColumn: "StatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "SpecializationId",
                keyValue: 1);
        }
    }
}

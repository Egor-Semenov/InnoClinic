using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Receptionists_IsDeleted",
                table: "Receptionists");

            migrationBuilder.DropIndex(
                name: "IX_Patients_IsDeleted",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_IsDeleted",
                table: "Appointments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Receptionists_IsDeleted",
                table: "Receptionists",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IsDeleted",
                table: "Patients",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_IsDeleted",
                table: "Appointments",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");
        }
    }
}

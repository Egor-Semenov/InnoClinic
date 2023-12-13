using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOfficesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Office",
                table: "Appointments",
                newName: "OfficeId");

            migrationBuilder.CreateTable(
                name: "OfficeStatus",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeStatus", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    PhotoFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.OfficeId);
                    table.ForeignKey(
                        name: "FK_Office_OfficeStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "OfficeStatus",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OfficeStatus",
                columns: new[] { "StatusId", "Status" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Inactive" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receptionists_OfficeId",
                table: "Receptionists",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_OfficeId",
                table: "Doctors",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_OfficeId",
                table: "Appointments",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_StatusId",
                table: "Office",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Office_OfficeId",
                table: "Appointments",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Office_OfficeId",
                table: "Doctors",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receptionists_Office_OfficeId",
                table: "Receptionists",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Office_OfficeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Office_OfficeId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Receptionists_Office_OfficeId",
                table: "Receptionists");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "OfficeStatus");

            migrationBuilder.DropIndex(
                name: "IX_Receptionists_OfficeId",
                table: "Receptionists");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_OfficeId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_OfficeId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "OfficeId",
                table: "Appointments",
                newName: "Office");
        }
    }
}

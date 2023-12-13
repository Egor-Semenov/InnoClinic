using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOfficesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Office_OfficeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Office_OfficeId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Office_OfficeStatus_StatusId",
                table: "Office");

            migrationBuilder.DropForeignKey(
                name: "FK_Receptionists_Office_OfficeId",
                table: "Receptionists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfficeStatus",
                table: "OfficeStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Office",
                table: "Office");

            migrationBuilder.RenameTable(
                name: "OfficeStatus",
                newName: "OfficeStatuses");

            migrationBuilder.RenameTable(
                name: "Office",
                newName: "Offices");

            migrationBuilder.RenameIndex(
                name: "IX_Office_StatusId",
                table: "Offices",
                newName: "IX_Offices_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfficeStatuses",
                table: "OfficeStatuses",
                column: "StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offices",
                table: "Offices",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Offices_OfficeId",
                table: "Appointments",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Offices_OfficeId",
                table: "Doctors",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_OfficeStatuses_StatusId",
                table: "Offices",
                column: "StatusId",
                principalTable: "OfficeStatuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receptionists_Offices_OfficeId",
                table: "Receptionists",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Offices_OfficeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Offices_OfficeId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_OfficeStatuses_StatusId",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_Receptionists_Offices_OfficeId",
                table: "Receptionists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfficeStatuses",
                table: "OfficeStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offices",
                table: "Offices");

            migrationBuilder.RenameTable(
                name: "OfficeStatuses",
                newName: "OfficeStatus");

            migrationBuilder.RenameTable(
                name: "Offices",
                newName: "Office");

            migrationBuilder.RenameIndex(
                name: "IX_Offices_StatusId",
                table: "Office",
                newName: "IX_Office_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfficeStatus",
                table: "OfficeStatus",
                column: "StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Office",
                table: "Office",
                column: "OfficeId");

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
                name: "FK_Office_OfficeStatus_StatusId",
                table: "Office",
                column: "StatusId",
                principalTable: "OfficeStatus",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receptionists_Office_OfficeId",
                table: "Receptionists",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

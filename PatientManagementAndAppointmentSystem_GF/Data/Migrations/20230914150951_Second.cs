using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientManagementAndAppointmentSystem_GF.Data.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_MedicalHistory_MedicalHistoryId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_MedicalHistoryId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryId",
                table: "Appointment");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Patient",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Patient",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "MedicalHistory",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Appointment",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "MedicalHistory");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Patient",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Patient",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Appointment",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<long>(
                name: "MedicalHistoryId",
                table: "Appointment",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_MedicalHistoryId",
                table: "Appointment",
                column: "MedicalHistoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_MedicalHistory_MedicalHistoryId",
                table: "Appointment",
                column: "MedicalHistoryId",
                principalTable: "MedicalHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

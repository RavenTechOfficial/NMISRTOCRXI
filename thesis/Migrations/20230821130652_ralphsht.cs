using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class ralphsht : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "applicationtype",
                table: "MTVquizzes");

            migrationBuilder.AddColumn<int>(
                name: "applicationtype",
                table: "MTVApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "birthdate",
                table: "Helpers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "birthdate",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "gender",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "applicationtype",
                table: "MTVApplications");

            migrationBuilder.DropColumn(
                name: "birthdate",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "birthdate",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "Drivers");

            migrationBuilder.AddColumn<int>(
                name: "applicationtype",
                table: "MTVquizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

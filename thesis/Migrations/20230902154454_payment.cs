using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_MTVApplications_MTVApplicationId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_MTVApplicationId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "MTVApplicationId",
                table: "Payments");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SOA",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "SOA",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "MTVApplicationId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MTVApplicationId",
                table: "Payments",
                column: "MTVApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_MTVApplications_MTVApplicationId",
                table: "Payments",
                column: "MTVApplicationId",
                principalTable: "MTVApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meatInspectionReports_receivings_ReceivingId",
                table: "meatInspectionReports");

            migrationBuilder.DropIndex(
                name: "IX_meatInspectionReports_ReceivingId",
                table: "meatInspectionReports");

            migrationBuilder.DropColumn(
                name: "ReceivingId",
                table: "meatInspectionReports");

            migrationBuilder.AddColumn<int>(
                name: "MeatInspectionReportId",
                table: "receivings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "meatDealers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_receivings_MeatInspectionReportId",
                table: "receivings",
                column: "MeatInspectionReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_receivings_meatInspectionReports_MeatInspectionReportId",
                table: "receivings",
                column: "MeatInspectionReportId",
                principalTable: "meatInspectionReports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_receivings_meatInspectionReports_MeatInspectionReportId",
                table: "receivings");

            migrationBuilder.DropIndex(
                name: "IX_receivings_MeatInspectionReportId",
                table: "receivings");

            migrationBuilder.DropColumn(
                name: "MeatInspectionReportId",
                table: "receivings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "meatDealers");

            migrationBuilder.AddColumn<int>(
                name: "ReceivingId",
                table: "meatInspectionReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_meatInspectionReports_ReceivingId",
                table: "meatInspectionReports",
                column: "ReceivingId");

            migrationBuilder.AddForeignKey(
                name: "FK_meatInspectionReports_receivings_ReceivingId",
                table: "meatInspectionReports",
                column: "ReceivingId",
                principalTable: "receivings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

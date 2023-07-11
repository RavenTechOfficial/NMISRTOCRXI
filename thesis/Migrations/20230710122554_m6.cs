using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class m6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Antemortems_MeatEstablishments_MeatEstablishmentReportId",
                table: "Antemortems");

            migrationBuilder.RenameColumn(
                name: "MeatEstablishmentReportId",
                table: "Antemortems",
                newName: "MeatInspectionReportId");

            migrationBuilder.RenameIndex(
                name: "IX_Antemortems_MeatEstablishmentReportId",
                table: "Antemortems",
                newName: "IX_Antemortems_MeatInspectionReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Antemortems_MeatInspectionReports_MeatInspectionReportId",
                table: "Antemortems",
                column: "MeatInspectionReportId",
                principalTable: "MeatInspectionReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Antemortems_MeatInspectionReports_MeatInspectionReportId",
                table: "Antemortems");

            migrationBuilder.RenameColumn(
                name: "MeatInspectionReportId",
                table: "Antemortems",
                newName: "MeatEstablishmentReportId");

            migrationBuilder.RenameIndex(
                name: "IX_Antemortems_MeatInspectionReportId",
                table: "Antemortems",
                newName: "IX_Antemortems_MeatEstablishmentReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Antemortems_MeatEstablishments_MeatEstablishmentReportId",
                table: "Antemortems",
                column: "MeatEstablishmentReportId",
                principalTable: "MeatEstablishments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class m5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Antemortems_MeatEstablishments_MeatEstablishmentId",
                table: "Antemortems");

            migrationBuilder.RenameColumn(
                name: "MeatEstablishmentId",
                table: "Antemortems",
                newName: "MeatEstablishmentReportId");

            migrationBuilder.RenameIndex(
                name: "IX_Antemortems_MeatEstablishmentId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Antemortems_MeatEstablishments_MeatEstablishmentReportId",
                table: "Antemortems");

            migrationBuilder.RenameColumn(
                name: "MeatEstablishmentReportId",
                table: "Antemortems",
                newName: "MeatEstablishmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Antemortems_MeatEstablishmentReportId",
                table: "Antemortems",
                newName: "IX_Antemortems_MeatEstablishmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Antemortems_MeatEstablishments_MeatEstablishmentId",
                table: "Antemortems",
                column: "MeatEstablishmentId",
                principalTable: "MeatEstablishments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

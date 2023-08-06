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
                name: "FK_ConductOfInspections_Antemortems_AntemortemId",
                table: "ConductOfInspections");

            migrationBuilder.DropTable(
                name: "Antemortems");

            migrationBuilder.RenameColumn(
                name: "AntemortemId",
                table: "ConductOfInspections",
                newName: "MeatInspectionReportId");

            migrationBuilder.RenameIndex(
                name: "IX_ConductOfInspections_AntemortemId",
                table: "ConductOfInspections",
                newName: "IX_ConductOfInspections_MeatInspectionReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConductOfInspections_MeatInspectionReports_MeatInspectionReportId",
                table: "ConductOfInspections",
                column: "MeatInspectionReportId",
                principalTable: "MeatInspectionReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConductOfInspections_MeatInspectionReports_MeatInspectionReportId",
                table: "ConductOfInspections");

            migrationBuilder.RenameColumn(
                name: "MeatInspectionReportId",
                table: "ConductOfInspections",
                newName: "AntemortemId");

            migrationBuilder.RenameIndex(
                name: "IX_ConductOfInspections_MeatInspectionReportId",
                table: "ConductOfInspections",
                newName: "IX_ConductOfInspections_AntemortemId");

            migrationBuilder.CreateTable(
                name: "Antemortems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeatInspectionReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antemortems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Antemortems_MeatInspectionReports_MeatInspectionReportId",
                        column: x => x.MeatInspectionReportId,
                        principalTable: "MeatInspectionReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Antemortems_MeatInspectionReportId",
                table: "Antemortems",
                column: "MeatInspectionReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConductOfInspections_Antemortems_AntemortemId",
                table: "ConductOfInspections",
                column: "AntemortemId",
                principalTable: "Antemortems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

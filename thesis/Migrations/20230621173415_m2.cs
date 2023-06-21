using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_postmortemReports_receivings_ReceivingId",
                table: "postmortemReports");

            migrationBuilder.DropTable(
                name: "postmortemInspections");

            migrationBuilder.DropIndex(
                name: "IX_postmortemReports_ReceivingId",
                table: "postmortemReports");

            migrationBuilder.DropColumn(
                name: "ReceivingId",
                table: "postmortemReports");

            migrationBuilder.CreateTable(
                name: "receivingPostmortemReports",
                columns: table => new
                {
                    ReceivingId = table.Column<int>(type: "int", nullable: false),
                    PostmortemReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receivingPostmortemReports", x => new { x.ReceivingId, x.PostmortemReportId });
                    table.ForeignKey(
                        name: "FK_receivingPostmortemReports_postmortemReports_PostmortemReportId",
                        column: x => x.PostmortemReportId,
                        principalTable: "postmortemReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receivingPostmortemReports_receivings_ReceivingId",
                        column: x => x.ReceivingId,
                        principalTable: "receivings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_receivingPostmortemReports_PostmortemReportId",
                table: "receivingPostmortemReports",
                column: "PostmortemReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "receivingPostmortemReports");

            migrationBuilder.AddColumn<int>(
                name: "ReceivingId",
                table: "postmortemReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "postmortemInspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostmortemReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postmortemInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_postmortemInspections_postmortemReports_PostmortemReportId",
                        column: x => x.PostmortemReportId,
                        principalTable: "postmortemReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_postmortemReports_ReceivingId",
                table: "postmortemReports",
                column: "ReceivingId");

            migrationBuilder.CreateIndex(
                name: "IX_postmortemInspections_PostmortemReportId",
                table: "postmortemInspections",
                column: "PostmortemReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_postmortemReports_receivings_ReceivingId",
                table: "postmortemReports",
                column: "ReceivingId",
                principalTable: "receivings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

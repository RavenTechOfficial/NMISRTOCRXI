using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class m9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeatInspectionReports_ReceivingReports_ReceivingReportId",
                table: "MeatInspectionReports");

            migrationBuilder.AlterColumn<int>(
                name: "ReceivingReportId",
                table: "MeatInspectionReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MeatInspectionReports_ReceivingReports_ReceivingReportId",
                table: "MeatInspectionReports",
                column: "ReceivingReportId",
                principalTable: "ReceivingReports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeatInspectionReports_ReceivingReports_ReceivingReportId",
                table: "MeatInspectionReports");

            migrationBuilder.AlterColumn<int>(
                name: "ReceivingReportId",
                table: "MeatInspectionReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MeatInspectionReports_ReceivingReports_ReceivingReportId",
                table: "MeatInspectionReports",
                column: "ReceivingReportId",
                principalTable: "ReceivingReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

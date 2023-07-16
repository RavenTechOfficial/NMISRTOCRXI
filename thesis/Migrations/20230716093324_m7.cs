using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class m7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingReports_Receivings_ReceivingId",
                table: "ReceivingReports");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingReports_ReceivingId",
                table: "ReceivingReports");

            migrationBuilder.DropColumn(
                name: "ReceivingId",
                table: "ReceivingReports");

            migrationBuilder.AddColumn<string>(
                name: "AccountDetailsId",
                table: "ReceivingReports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LicenseStatus",
                table: "MeatEstablishment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingReports_AccountDetailsId",
                table: "ReceivingReports",
                column: "AccountDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingReports_AspNetUsers_AccountDetailsId",
                table: "ReceivingReports",
                column: "AccountDetailsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingReports_AspNetUsers_AccountDetailsId",
                table: "ReceivingReports");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingReports_AccountDetailsId",
                table: "ReceivingReports");

            migrationBuilder.DropColumn(
                name: "AccountDetailsId",
                table: "ReceivingReports");

            migrationBuilder.DropColumn(
                name: "LicenseStatus",
                table: "MeatEstablishment");

            migrationBuilder.AddColumn<int>(
                name: "ReceivingId",
                table: "ReceivingReports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingReports_ReceivingId",
                table: "ReceivingReports",
                column: "ReceivingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingReports_Receivings_ReceivingId",
                table: "ReceivingReports",
                column: "ReceivingId",
                principalTable: "Receivings",
                principalColumn: "Id");
        }
    }
}

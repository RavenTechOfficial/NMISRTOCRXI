using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class m12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingReports_AspNetUsers_AccountDetailsId",
                table: "ReceivingReports");

            migrationBuilder.AlterColumn<string>(
                name: "AccountDetailsId",
                table: "ReceivingReports",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AlterColumn<string>(
                name: "AccountDetailsId",
                table: "ReceivingReports",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingReports_AspNetUsers_AccountDetailsId",
                table: "ReceivingReports",
                column: "AccountDetailsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

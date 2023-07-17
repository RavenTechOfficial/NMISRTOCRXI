using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class m10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingReports_MeatDealers_MeatDealersId",
                table: "ReceivingReports");

            migrationBuilder.AlterColumn<int>(
                name: "MeatDealersId",
                table: "ReceivingReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingReports_MeatDealers_MeatDealersId",
                table: "ReceivingReports",
                column: "MeatDealersId",
                principalTable: "MeatDealers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingReports_MeatDealers_MeatDealersId",
                table: "ReceivingReports");

            migrationBuilder.AlterColumn<int>(
                name: "MeatDealersId",
                table: "ReceivingReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingReports_MeatDealers_MeatDealersId",
                table: "ReceivingReports",
                column: "MeatDealersId",
                principalTable: "MeatDealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

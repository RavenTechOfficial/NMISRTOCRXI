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
                name: "FK_AccountRoles_MeatEstablishments_MeatEstablishmentId",
                table: "AccountRoles");

            migrationBuilder.DropIndex(
                name: "IX_AccountRoles_MeatEstablishmentId",
                table: "AccountRoles");

            migrationBuilder.DropColumn(
                name: "MeatEstablishmentId",
                table: "AccountRoles");

            migrationBuilder.AddColumn<int>(
                name: "MeatEstablishmentId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Roles",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MeatEstablishmentId",
                table: "AspNetUsers",
                column: "MeatEstablishmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MeatEstablishments_MeatEstablishmentId",
                table: "AspNetUsers",
                column: "MeatEstablishmentId",
                principalTable: "MeatEstablishments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MeatEstablishments_MeatEstablishmentId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MeatEstablishmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MeatEstablishmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "MeatEstablishmentId",
                table: "AccountRoles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountRoles_MeatEstablishmentId",
                table: "AccountRoles",
                column: "MeatEstablishmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRoles_MeatEstablishments_MeatEstablishmentId",
                table: "AccountRoles",
                column: "MeatEstablishmentId",
                principalTable: "MeatEstablishments",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class deleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MTVApplications_AccountRoles_AccountRolesId",
                table: "MTVApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_Receivings_AccountRoles_AccountRolesId",
                table: "Receivings");

            migrationBuilder.DropTable(
                name: "AccountRoles");

            migrationBuilder.DropIndex(
                name: "IX_Receivings_AccountRolesId",
                table: "Receivings");

            migrationBuilder.DropIndex(
                name: "IX_MTVApplications_AccountRolesId",
                table: "MTVApplications");

            migrationBuilder.DropColumn(
                name: "AccountRolesId",
                table: "Receivings");

            migrationBuilder.DropColumn(
                name: "AccountRolesId",
                table: "MTVApplications");

            migrationBuilder.AddColumn<string>(
                name: "AccountDetailsId",
                table: "Receivings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountDetailsId",
                table: "MTVApplications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Receivings_AccountDetailsId",
                table: "Receivings",
                column: "AccountDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MTVApplications_AccountDetailsId",
                table: "MTVApplications",
                column: "AccountDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MTVApplications_AspNetUsers_AccountDetailsId",
                table: "MTVApplications",
                column: "AccountDetailsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receivings_AspNetUsers_AccountDetailsId",
                table: "Receivings",
                column: "AccountDetailsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MTVApplications_AspNetUsers_AccountDetailsId",
                table: "MTVApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_Receivings_AspNetUsers_AccountDetailsId",
                table: "Receivings");

            migrationBuilder.DropIndex(
                name: "IX_Receivings_AccountDetailsId",
                table: "Receivings");

            migrationBuilder.DropIndex(
                name: "IX_MTVApplications_AccountDetailsId",
                table: "MTVApplications");

            migrationBuilder.DropColumn(
                name: "AccountDetailsId",
                table: "Receivings");

            migrationBuilder.DropColumn(
                name: "AccountDetailsId",
                table: "MTVApplications");

            migrationBuilder.AddColumn<int>(
                name: "AccountRolesId",
                table: "Receivings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountRolesId",
                table: "MTVApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AccountRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountDetailsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Roles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountRoles_AspNetUsers_AccountDetailsId",
                        column: x => x.AccountDetailsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receivings_AccountRolesId",
                table: "Receivings",
                column: "AccountRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_MTVApplications_AccountRolesId",
                table: "MTVApplications",
                column: "AccountRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRoles_AccountDetailsId",
                table: "AccountRoles",
                column: "AccountDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MTVApplications_AccountRoles_AccountRolesId",
                table: "MTVApplications",
                column: "AccountRolesId",
                principalTable: "AccountRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receivings_AccountRoles_AccountRolesId",
                table: "Receivings",
                column: "AccountRolesId",
                principalTable: "AccountRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

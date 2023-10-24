using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class schecklist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_checklists_MTVquizzes_MTVquizId",
                table: "checklists");

            migrationBuilder.DropIndex(
                name: "IX_checklists_MTVquizId",
                table: "checklists");

            migrationBuilder.DropColumn(
                name: "MTVquizId",
                table: "checklists");

            migrationBuilder.DropColumn(
                name: "passorfail",
                table: "checklists");

            migrationBuilder.AddColumn<string>(
                name: "estserved",
                table: "checklists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "inspectdate",
                table: "checklists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "inspectorname",
                table: "checklists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "inspecttime",
                table: "checklists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "operatorname",
                table: "checklists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "plateno",
                table: "checklists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "checklists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estserved",
                table: "checklists");

            migrationBuilder.DropColumn(
                name: "inspectdate",
                table: "checklists");

            migrationBuilder.DropColumn(
                name: "inspectorname",
                table: "checklists");

            migrationBuilder.DropColumn(
                name: "inspecttime",
                table: "checklists");

            migrationBuilder.DropColumn(
                name: "operatorname",
                table: "checklists");

            migrationBuilder.DropColumn(
                name: "plateno",
                table: "checklists");

            migrationBuilder.DropColumn(
                name: "status",
                table: "checklists");

            migrationBuilder.AddColumn<int>(
                name: "MTVquizId",
                table: "checklists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "passorfail",
                table: "checklists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_checklists_MTVquizId",
                table: "checklists",
                column: "MTVquizId");

            migrationBuilder.AddForeignKey(
                name: "FK_checklists_MTVquizzes_MTVquizId",
                table: "checklists",
                column: "MTVquizId",
                principalTable: "MTVquizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class m6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Postmortems");

            migrationBuilder.AddColumn<string>(
                name: "Image1",
                table: "Postmortems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Postmortems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Postmortems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image1",
                table: "Postmortems");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Postmortems");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Postmortems");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Postmortems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

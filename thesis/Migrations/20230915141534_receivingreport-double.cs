using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class receivingreportdouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "LiveWeight",
                table: "ReceivingReports",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LiveWeight",
                table: "ReceivingReports",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class mdawmd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CertificateStatus",
                table: "SummaryAndDistributionOfMICs",
                newName: "MICIssued");

            migrationBuilder.AddColumn<int>(
                name: "MICCancelled",
                table: "SummaryAndDistributionOfMICs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MICCancelled",
                table: "SummaryAndDistributionOfMICs");

            migrationBuilder.RenameColumn(
                name: "MICIssued",
                table: "SummaryAndDistributionOfMICs",
                newName: "CertificateStatus");
        }
    }
}

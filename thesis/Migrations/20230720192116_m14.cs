using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class m14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MTVApplications_AspNetUsers_AccountDetailsId",
                table: "MTVApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_MTVApplications_MTVDetails_MTVDetailsId",
                table: "MTVApplications");

            migrationBuilder.DropIndex(
                name: "IX_MTVApplications_AccountDetailsId",
                table: "MTVApplications");

            migrationBuilder.DropIndex(
                name: "IX_MTVApplications_MTVDetailsId",
                table: "MTVApplications");

            migrationBuilder.DropColumn(
                name: "AccountDetailsId",
                table: "MTVApplications");

            migrationBuilder.DropColumn(
                name: "EstablishmentType",
                table: "MTVApplications");

            migrationBuilder.DropColumn(
                name: "MTVDetailsId",
                table: "MTVApplications");

            migrationBuilder.RenameColumn(
                name: "VehicleDestination",
                table: "MTVApplications",
                newName: "TelNo");

            migrationBuilder.RenameColumn(
                name: "Seminar",
                table: "MTVApplications",
                newName: "OwnerMname");

            migrationBuilder.RenameColumn(
                name: "Quiz",
                table: "MTVApplications",
                newName: "OwnerLname");

            migrationBuilder.RenameColumn(
                name: "HelperName",
                table: "MTVApplications",
                newName: "OwnerFname");

            migrationBuilder.RenameColumn(
                name: "DriverName",
                table: "MTVApplications",
                newName: "FaxNo");

            migrationBuilder.RenameColumn(
                name: "DriverLicense",
                table: "MTVApplications",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "MTVApplications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "MTVApplications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HelperId",
                table: "MTVApplications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "MTVApplications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VehicleInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleMaker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlateNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LTOCR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LTOOR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Est = table.Column<int>(type: "int", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MTVApplications_DriverId",
                table: "MTVApplications",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_MTVApplications_HelperId",
                table: "MTVApplications",
                column: "HelperId");

            migrationBuilder.CreateIndex(
                name: "IX_MTVApplications_VehicleId",
                table: "MTVApplications",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MTVApplications_Drivers_DriverId",
                table: "MTVApplications",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MTVApplications_Helpers_HelperId",
                table: "MTVApplications",
                column: "HelperId",
                principalTable: "Helpers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MTVApplications_VehicleInfos_VehicleId",
                table: "MTVApplications",
                column: "VehicleId",
                principalTable: "VehicleInfos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MTVApplications_Drivers_DriverId",
                table: "MTVApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_MTVApplications_Helpers_HelperId",
                table: "MTVApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_MTVApplications_VehicleInfos_VehicleId",
                table: "MTVApplications");

            migrationBuilder.DropTable(
                name: "VehicleInfos");

            migrationBuilder.DropIndex(
                name: "IX_MTVApplications_DriverId",
                table: "MTVApplications");

            migrationBuilder.DropIndex(
                name: "IX_MTVApplications_HelperId",
                table: "MTVApplications");

            migrationBuilder.DropIndex(
                name: "IX_MTVApplications_VehicleId",
                table: "MTVApplications");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "MTVApplications");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "MTVApplications");

            migrationBuilder.DropColumn(
                name: "HelperId",
                table: "MTVApplications");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "MTVApplications");

            migrationBuilder.RenameColumn(
                name: "TelNo",
                table: "MTVApplications",
                newName: "VehicleDestination");

            migrationBuilder.RenameColumn(
                name: "OwnerMname",
                table: "MTVApplications",
                newName: "Seminar");

            migrationBuilder.RenameColumn(
                name: "OwnerLname",
                table: "MTVApplications",
                newName: "Quiz");

            migrationBuilder.RenameColumn(
                name: "OwnerFname",
                table: "MTVApplications",
                newName: "HelperName");

            migrationBuilder.RenameColumn(
                name: "FaxNo",
                table: "MTVApplications",
                newName: "DriverName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "MTVApplications",
                newName: "DriverLicense");

            migrationBuilder.AddColumn<string>(
                name: "AccountDetailsId",
                table: "MTVApplications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EstablishmentType",
                table: "MTVApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MTVDetailsId",
                table: "MTVApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MTVApplications_AccountDetailsId",
                table: "MTVApplications",
                column: "AccountDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MTVApplications_MTVDetailsId",
                table: "MTVApplications",
                column: "MTVDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MTVApplications_AspNetUsers_AccountDetailsId",
                table: "MTVApplications",
                column: "AccountDetailsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MTVApplications_MTVDetails_MTVDetailsId",
                table: "MTVApplications",
                column: "MTVDetailsId",
                principalTable: "MTVDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class karlo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MTVDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlNo = table.Column<int>(type: "int", nullable: false),
                    ApplicantType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisteredOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaxNumber = table.Column<int>(type: "int", nullable: false),
                    VehicleMaker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlateNo = table.Column<int>(type: "int", nullable: false),
                    LTOOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LTOCR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTVDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MTVApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverLicense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HelperName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seminar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quiz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstablishmentType = table.Column<int>(type: "int", nullable: false),
                    VehicleDestination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MTVDetailsId = table.Column<int>(type: "int", nullable: false),
                    AccountRolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTVApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MTVApplications_AccountRoles_AccountRolesId",
                        column: x => x.AccountRolesId,
                        principalTable: "AccountRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MTVApplications_MTVDetails_MTVDetailsId",
                        column: x => x.MTVDetailsId,
                        principalTable: "MTVDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MTVInspection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MTVApplicationId = table.Column<int>(type: "int", nullable: false),
                    Enclosed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insulated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempControlled = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlasticCurtains = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectlyInstalled = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTVInspection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MTVInspection_MTVApplications_MTVApplicationId",
                        column: x => x.MTVApplicationId,
                        principalTable: "MTVApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentReceipt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MTVApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_MTVApplications_MTVApplicationId",
                        column: x => x.MTVApplicationId,
                        principalTable: "MTVApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisapprovedApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MTVInspectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisapprovedApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisapprovedApplications_MTVInspection_MTVInspectionId",
                        column: x => x.MTVInspectionId,
                        principalTable: "MTVInspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MTVApplicationResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MTVInspectionId = table.Column<int>(type: "int", nullable: false),
                    Received = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Processed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTVApplicationResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MTVApplicationResults_MTVInspection_MTVInspectionId",
                        column: x => x.MTVInspectionId,
                        principalTable: "MTVInspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisapprovedApplications_MTVInspectionId",
                table: "DisapprovedApplications",
                column: "MTVInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MTVApplicationResults_MTVInspectionId",
                table: "MTVApplicationResults",
                column: "MTVInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MTVApplications_AccountRolesId",
                table: "MTVApplications",
                column: "AccountRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_MTVApplications_MTVDetailsId",
                table: "MTVApplications",
                column: "MTVDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MTVInspection_MTVApplicationId",
                table: "MTVInspection",
                column: "MTVApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MTVApplicationId",
                table: "Payments",
                column: "MTVApplicationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisapprovedApplications");

            migrationBuilder.DropTable(
                name: "MTVApplicationResults");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "MTVInspection");

            migrationBuilder.DropTable(
                name: "MTVApplications");

            migrationBuilder.DropTable(
                name: "MTVDetails");
        }
    }
}

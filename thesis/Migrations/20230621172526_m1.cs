using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "conductOfInspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfHeads = table.Column<int>(type: "int", nullable: false),
                    WeightInKg = table.Column<int>(type: "int", nullable: false),
                    Cause = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conductOfInspections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "meatInspectionCertUtilizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kind = table.Column<int>(type: "int", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VolumeInKg = table.Column<int>(type: "int", nullable: false),
                    NoOfMICIssued = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meatInspectionCertUtilizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "meatInspectionSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kind = table.Column<int>(type: "int", nullable: false),
                    TotalInspectedInKg = table.Column<int>(type: "int", nullable: false),
                    CondemnedInKg = table.Column<int>(type: "int", nullable: false),
                    Cause = table.Column<int>(type: "int", nullable: false),
                    PassedInKg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meatInspectionSummaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "passedForSlaughters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfHeads = table.Column<int>(type: "int", nullable: false),
                    WeightInKg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passedForSlaughters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "serviceTransactionDescriptionReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfHeads = table.Column<int>(type: "int", nullable: false),
                    AmFees = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VolumeInKg = table.Column<int>(type: "int", nullable: false),
                    PMFees = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LGUShare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NMISShare = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceTransactionDescriptionReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "summaryAndDistributionOfMICs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfHeads = table.Column<int>(type: "int", nullable: false),
                    WeightInKg = table.Column<int>(type: "int", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeatInspectionCertificateStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_summaryAndDistributionOfMICs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "totalNoFitForHumanConsumptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Species = table.Column<int>(type: "int", nullable: false),
                    NoOfAnimals = table.Column<int>(type: "int", nullable: false),
                    DressedWeightInKg = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_totalNoFitForHumanConsumptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meatEstablishmentRepresentatives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountDetailsId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meatEstablishmentRepresentatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_meatEstablishmentRepresentatives_AspNetUsers_AccountDetailsId",
                        column: x => x.AccountDetailsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "antemortemInspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConductOfInspectionId = table.Column<int>(type: "int", nullable: false),
                    PassedForSlaughterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_antemortemInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_antemortemInspections_conductOfInspections_ConductOfInspectionId",
                        column: x => x.ConductOfInspectionId,
                        principalTable: "conductOfInspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_antemortemInspections_passedForSlaughters_PassedForSlaughterId",
                        column: x => x.PassedForSlaughterId,
                        principalTable: "passedForSlaughters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meatEstablishments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    establishmentType = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    licenseToOperateNumber = table.Column<int>(type: "int", nullable: false),
                    MeatEstablishmentRepresentativeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meatEstablishments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_meatEstablishments_meatEstablishmentRepresentatives_MeatEstablishmentRepresentativeId",
                        column: x => x.MeatEstablishmentRepresentativeId,
                        principalTable: "meatEstablishmentRepresentatives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inspectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountDetailsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MeatEstablishmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inspectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inspectors_AspNetUsers_AccountDetailsId",
                        column: x => x.AccountDetailsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_inspectors_meatEstablishments_MeatEstablishmentId",
                        column: x => x.MeatEstablishmentId,
                        principalTable: "meatEstablishments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meatDealers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeatEstablishmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meatDealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_meatDealers_meatEstablishments_MeatEstablishmentId",
                        column: x => x.MeatEstablishmentId,
                        principalTable: "meatEstablishments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receivings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receivings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_receivings_inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "secondaryMeatEstablishmentReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeatInspectionSummaryId = table.Column<int>(type: "int", nullable: false),
                    MeatInspectionCertUtilizationId = table.Column<int>(type: "int", nullable: false),
                    InspectorId = table.Column<int>(type: "int", nullable: false),
                    NotedByPOSMSHead = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_secondaryMeatEstablishmentReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_secondaryMeatEstablishmentReports_inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_secondaryMeatEstablishmentReports_meatInspectionCertUtilizations_MeatInspectionCertUtilizationId",
                        column: x => x.MeatInspectionCertUtilizationId,
                        principalTable: "meatInspectionCertUtilizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_secondaryMeatEstablishmentReports_meatInspectionSummaries_MeatInspectionSummaryId",
                        column: x => x.MeatInspectionSummaryId,
                        principalTable: "meatInspectionSummaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "serviceTransactionDescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Species = table.Column<int>(type: "int", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    InspectorId = table.Column<int>(type: "int", nullable: false),
                    VerifiedByPOSMSHead = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NMISRTD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceTransactionDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_serviceTransactionDescription_inspectors_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "inspectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_serviceTransactionDescription_serviceTransactionDescriptionReports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "serviceTransactionDescriptionReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receivingReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipmentBatchCode = table.Column<int>(type: "int", nullable: false),
                    SpeciesTypeOfFoodAnimals = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfHeads = table.Column<int>(type: "int", nullable: false),
                    LiveWeighInKg = table.Column<int>(type: "int", nullable: false),
                    MeatDealerId = table.Column<int>(type: "int", nullable: false),
                    OriginOfFoodAnimals = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingDocuments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoldingPenNo = table.Column<int>(type: "int", nullable: false),
                    ReceivedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receivingReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_receivingReports_meatDealers_MeatDealerId",
                        column: x => x.MeatDealerId,
                        principalTable: "meatDealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meatInspectionReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceivingId = table.Column<int>(type: "int", nullable: false),
                    TotalNoFitForHumanConsumptionId = table.Column<int>(type: "int", nullable: false),
                    SummaryAndDistributionOfMICId = table.Column<int>(type: "int", nullable: false),
                    VerifiedByPOSMSHead = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meatInspectionReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_meatInspectionReports_receivings_ReceivingId",
                        column: x => x.ReceivingId,
                        principalTable: "receivings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_meatInspectionReports_summaryAndDistributionOfMICs_SummaryAndDistributionOfMICId",
                        column: x => x.SummaryAndDistributionOfMICId,
                        principalTable: "summaryAndDistributionOfMICs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_meatInspectionReports_totalNoFitForHumanConsumptions_TotalNoFitForHumanConsumptionId",
                        column: x => x.TotalNoFitForHumanConsumptionId,
                        principalTable: "totalNoFitForHumanConsumptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "postmortemReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivingId = table.Column<int>(type: "int", nullable: false),
                    AnimalPart = table.Column<int>(type: "int", nullable: false),
                    Cause = table.Column<int>(type: "int", nullable: false),
                    WeightInKg = table.Column<int>(type: "int", nullable: false),
                    NoOfHeads = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postmortemReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_postmortemReports_receivings_ReceivingId",
                        column: x => x.ReceivingId,
                        principalTable: "receivings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receivingConductOfInspections",
                columns: table => new
                {
                    ConductOfInspectionId = table.Column<int>(type: "int", nullable: false),
                    ReceivingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receivingConductOfInspections", x => new { x.ReceivingId, x.ConductOfInspectionId });
                    table.ForeignKey(
                        name: "FK_receivingConductOfInspections_conductOfInspections_ConductOfInspectionId",
                        column: x => x.ConductOfInspectionId,
                        principalTable: "conductOfInspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receivingConductOfInspections_receivings_ReceivingId",
                        column: x => x.ReceivingId,
                        principalTable: "receivings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receivingPassedForSlaughters",
                columns: table => new
                {
                    PassedForSlaughterId = table.Column<int>(type: "int", nullable: false),
                    ReceivingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receivingPassedForSlaughters", x => new { x.ReceivingId, x.PassedForSlaughterId });
                    table.ForeignKey(
                        name: "FK_receivingPassedForSlaughters_passedForSlaughters_PassedForSlaughterId",
                        column: x => x.PassedForSlaughterId,
                        principalTable: "passedForSlaughters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receivingPassedForSlaughters_receivings_ReceivingId",
                        column: x => x.ReceivingId,
                        principalTable: "receivings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "postmortemInspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostmortemReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postmortemInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_postmortemInspections_postmortemReports_PostmortemReportId",
                        column: x => x.PostmortemReportId,
                        principalTable: "postmortemReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_antemortemInspections_ConductOfInspectionId",
                table: "antemortemInspections",
                column: "ConductOfInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_antemortemInspections_PassedForSlaughterId",
                table: "antemortemInspections",
                column: "PassedForSlaughterId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_inspectors_AccountDetailsId",
                table: "inspectors",
                column: "AccountDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_inspectors_MeatEstablishmentId",
                table: "inspectors",
                column: "MeatEstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_meatDealers_MeatEstablishmentId",
                table: "meatDealers",
                column: "MeatEstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_meatEstablishmentRepresentatives_AccountDetailsId",
                table: "meatEstablishmentRepresentatives",
                column: "AccountDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_meatEstablishments_MeatEstablishmentRepresentativeId",
                table: "meatEstablishments",
                column: "MeatEstablishmentRepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_meatInspectionReports_ReceivingId",
                table: "meatInspectionReports",
                column: "ReceivingId");

            migrationBuilder.CreateIndex(
                name: "IX_meatInspectionReports_SummaryAndDistributionOfMICId",
                table: "meatInspectionReports",
                column: "SummaryAndDistributionOfMICId");

            migrationBuilder.CreateIndex(
                name: "IX_meatInspectionReports_TotalNoFitForHumanConsumptionId",
                table: "meatInspectionReports",
                column: "TotalNoFitForHumanConsumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_postmortemInspections_PostmortemReportId",
                table: "postmortemInspections",
                column: "PostmortemReportId");

            migrationBuilder.CreateIndex(
                name: "IX_postmortemReports_ReceivingId",
                table: "postmortemReports",
                column: "ReceivingId");

            migrationBuilder.CreateIndex(
                name: "IX_receivingConductOfInspections_ConductOfInspectionId",
                table: "receivingConductOfInspections",
                column: "ConductOfInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_receivingPassedForSlaughters_PassedForSlaughterId",
                table: "receivingPassedForSlaughters",
                column: "PassedForSlaughterId");

            migrationBuilder.CreateIndex(
                name: "IX_receivingReports_MeatDealerId",
                table: "receivingReports",
                column: "MeatDealerId");

            migrationBuilder.CreateIndex(
                name: "IX_receivings_InspectorId",
                table: "receivings",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_secondaryMeatEstablishmentReports_InspectorId",
                table: "secondaryMeatEstablishmentReports",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_secondaryMeatEstablishmentReports_MeatInspectionCertUtilizationId",
                table: "secondaryMeatEstablishmentReports",
                column: "MeatInspectionCertUtilizationId");

            migrationBuilder.CreateIndex(
                name: "IX_secondaryMeatEstablishmentReports_MeatInspectionSummaryId",
                table: "secondaryMeatEstablishmentReports",
                column: "MeatInspectionSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_serviceTransactionDescription_InspectorId",
                table: "serviceTransactionDescription",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_serviceTransactionDescription_ReportId",
                table: "serviceTransactionDescription",
                column: "ReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "antemortemInspections");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "meatInspectionReports");

            migrationBuilder.DropTable(
                name: "postmortemInspections");

            migrationBuilder.DropTable(
                name: "receivingConductOfInspections");

            migrationBuilder.DropTable(
                name: "receivingPassedForSlaughters");

            migrationBuilder.DropTable(
                name: "receivingReports");

            migrationBuilder.DropTable(
                name: "secondaryMeatEstablishmentReports");

            migrationBuilder.DropTable(
                name: "serviceTransactionDescription");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "summaryAndDistributionOfMICs");

            migrationBuilder.DropTable(
                name: "totalNoFitForHumanConsumptions");

            migrationBuilder.DropTable(
                name: "postmortemReports");

            migrationBuilder.DropTable(
                name: "conductOfInspections");

            migrationBuilder.DropTable(
                name: "passedForSlaughters");

            migrationBuilder.DropTable(
                name: "meatDealers");

            migrationBuilder.DropTable(
                name: "meatInspectionCertUtilizations");

            migrationBuilder.DropTable(
                name: "meatInspectionSummaries");

            migrationBuilder.DropTable(
                name: "serviceTransactionDescriptionReports");

            migrationBuilder.DropTable(
                name: "receivings");

            migrationBuilder.DropTable(
                name: "inspectors");

            migrationBuilder.DropTable(
                name: "meatEstablishments");

            migrationBuilder.DropTable(
                name: "meatEstablishmentRepresentatives");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

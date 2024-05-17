using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                name: "CheckLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    operatorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estserved = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    plateno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inspectorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inspectdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inspecttime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverFname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverMname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverLname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseFront = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseBack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedBacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HighlySatisfied = table.Column<int>(type: "int", nullable: false),
                    Satisfied = table.Column<int>(type: "int", nullable: false),
                    Neutral = table.Column<int>(type: "int", nullable: false),
                    Dissatisfied = table.Column<int>(type: "int", nullable: false),
                    HighlyDissatisfied = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Helpers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HelperFname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HelperMname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HelperLname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helpers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogPurpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeatEstablishment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseToOperateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseStatus = table.Column<int>(type: "int", nullable: true),
                    Long = table.Column<double>(type: "float", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeatEstablishment", x => x.Id);
                });

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
                name: "PostArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conclusion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    References = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostArticles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QrCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QrCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Species = table.Column<int>(type: "int", nullable: true),
                    LiveWeight = table.Column<int>(type: "int", nullable: true),
                    MeatDealer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Issue = table.Column<int>(type: "int", nullable: false),
                    NoOfHeads = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Cause = table.Column<int>(type: "int", nullable: false),
                    NoOfHeadsPassed = table.Column<int>(type: "int", nullable: false),
                    WeightPassed = table.Column<double>(type: "float", nullable: false),
                    AnimalPart = table.Column<int>(type: "int", nullable: false),
                    PostmortemCause = table.Column<int>(type: "int", nullable: false),
                    PostmortemWeight = table.Column<int>(type: "int", nullable: false),
                    PostmortemNoOfHeads = table.Column<int>(type: "int", nullable: false),
                    FitforConSpecies = table.Column<int>(type: "int", nullable: false),
                    FitforConNoOfHeads = table.Column<int>(type: "int", nullable: false),
                    DressedWeight = table.Column<int>(type: "int", nullable: false),
                    DestinationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateStatus = table.Column<int>(type: "int", nullable: false),
                    uid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                });

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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Roles = table.Column<int>(type: "int", nullable: true),
                    sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeatEstablishmentId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_MeatEstablishment_MeatEstablishmentId",
                        column: x => x.MeatEstablishmentId,
                        principalTable: "MeatEstablishment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeatDealers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeatEstablishmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeatDealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeatDealers_MeatEstablishment_MeatEstablishmentId",
                        column: x => x.MeatEstablishmentId,
                        principalTable: "MeatEstablishment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MTVApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    applicationtype = table.Column<int>(type: "int", nullable: false),
                    AccreditionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerFname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerMname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerLname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaxNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    HelperId = table.Column<int>(type: "int", nullable: true),
                    DriverId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTVApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MTVApplications_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MTVApplications_Helpers_HelperId",
                        column: x => x.HelperId,
                        principalTable: "Helpers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MTVApplications_VehicleInfos_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleInfos",
                        principalColumn: "Id");
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Receivings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountDetailsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receivings_AspNetUsers_AccountDetailsId",
                        column: x => x.AccountDetailsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceivingReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatchCode = table.Column<int>(type: "int", nullable: false),
                    Species = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    NoOfHeads = table.Column<int>(type: "int", nullable: false),
                    LiveWeight = table.Column<double>(type: "float", nullable: false),
                    MeatDealersId = table.Column<int>(type: "int", nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingDoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoldingPenNo = table.Column<int>(type: "int", nullable: false),
                    ReceivingBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountDetailsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InspectionStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivingReports_AspNetUsers_AccountDetailsId",
                        column: x => x.AccountDetailsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReceivingReports_MeatDealers_MeatDealersId",
                        column: x => x.MeatDealersId,
                        principalTable: "MeatDealers",
                        principalColumn: "Id");
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
                name: "MTVquizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MTVApplicationId = table.Column<int>(type: "int", nullable: false),
                    passorfail = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTVquizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MTVquizzes_MTVApplications_MTVApplicationId",
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
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SOA = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "MeatInspectionReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerifiedByPOSMSHead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivingReportId = table.Column<int>(type: "int", nullable: true),
                    AccountDetailsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeatInspectionReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeatInspectionReports_AspNetUsers_AccountDetailsId",
                        column: x => x.AccountDetailsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MeatInspectionReports_ReceivingReports_ReceivingReportId",
                        column: x => x.ReceivingReportId,
                        principalTable: "ReceivingReports",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "ConductOfInspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Issue = table.Column<int>(type: "int", nullable: false),
                    NoOfHeads = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Cause = table.Column<int>(type: "int", nullable: false),
                    MeatInspectionReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConductOfInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConductOfInspections_MeatInspectionReports_MeatInspectionReportId",
                        column: x => x.MeatInspectionReportId,
                        principalTable: "MeatInspectionReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassedForSlaughters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfHeads = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    ConductOfInspectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassedForSlaughters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassedForSlaughters_ConductOfInspections_ConductOfInspectionId",
                        column: x => x.ConductOfInspectionId,
                        principalTable: "ConductOfInspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Postmortems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassedForSlaughterId = table.Column<int>(type: "int", nullable: false),
                    AnimalPart = table.Column<int>(type: "int", nullable: false),
                    Cause = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    NoOfHeads = table.Column<int>(type: "int", nullable: false),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postmortems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Postmortems_PassedForSlaughters_PassedForSlaughterId",
                        column: x => x.PassedForSlaughterId,
                        principalTable: "PassedForSlaughters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TotalNoFitForHumanConsumptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Species = table.Column<int>(type: "int", nullable: false),
                    NoOfHeads = table.Column<int>(type: "int", nullable: false),
                    DressedWeight = table.Column<double>(type: "float", nullable: false),
                    PostmortemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalNoFitForHumanConsumptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TotalNoFitForHumanConsumptions_Postmortems_PostmortemId",
                        column: x => x.PostmortemId,
                        principalTable: "Postmortems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SummaryAndDistributionOfMICs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalNoFitForHumanConsumptionId = table.Column<int>(type: "int", nullable: false),
                    DestinationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MICIssued = table.Column<int>(type: "int", nullable: false),
                    MICCancelled = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryAndDistributionOfMICs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummaryAndDistributionOfMICs_TotalNoFitForHumanConsumptions_TotalNoFitForHumanConsumptionId",
                        column: x => x.TotalNoFitForHumanConsumptionId,
                        principalTable: "TotalNoFitForHumanConsumptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18624e89-0312-4d39-8e7a-0e9701fff257", null, "MeatEstablishmentRepresentative", "MEATESTABLISHMENTREPRESENTATIVE" },
                    { "8ff06b4e-ed7c-4ace-9956-d88366b7f786", null, "InspectorAdministrator", "INSPECTORADMIN" },
                    { "a0ba380e-aa40-4351-96f9-735e087ce21f", null, "MTVAdministrator", "MTVADMIN" },
                    { "a9e34847-ce14-43cd-9e2e-b2b38eae70a1", null, "MtvInspector", "MTVINSPECTOR" },
                    { "bf8bce35-2ce9-4cbe-b7ad-5090d976f49f", null, "User", "USER" },
                    { "dddf7db0-ddaf-447b-8d94-64f294b55e87", null, "MeatInspector", "MEATINSPECTOR" },
                    { "df6864e8-c680-4df8-8bcc-990ac0d318bf", null, "SuperAdministrator", "SUPERADMIN" },
                    { "efdf3dd1-18a5-4cbc-9310-3ce07f75bfc6", null, "MtvUsers", "MTVUSERS" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "MeatEstablishmentId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Roles", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "birthdate", "contactNo", "firstName", "image", "lastName", "middleName", "sex" },
                values: new object[,]
                {
                    { "26924353-da23-4429-ab55-446a56c9f5b9", 0, "ee3aeec6-4b92-4d4f-b982-e85840199fe7", "mtv@admin.com", true, false, null, null, "MTV@ADMIN.COM", "MTVRADMIN", "AQAAAAIAAYagAAAAEEXFF/Fb/ZmQ5nIKCw9MYtvB9T2OQNmfrob33PrbAaXa/hLX8cOQThyvMSYTE3PJmQ==", null, false, null, "", false, "mtvadmin", null, null, null, null, null, null, null, null },
                    { "2b81fc12-d568-4be5-9ae6-8de0ce5eff94", 0, "70123a97-3e85-4100-93f4-922ec0f9e3d2", "mtv@user.com", true, false, null, null, "MTV@USER.COM", "MTVUSER", "AQAAAAIAAYagAAAAECxGb4Cpvbc6+4OlwoU9nebHplsfpmE6EZUirJ7QWGLSLD3q+Z7Tu0ON5vlDdRnelQ==", null, false, null, "", false, "mtvuser", null, null, null, null, null, null, null, null },
                    { "30c71afd-3c9c-4508-85e6-e04ebc764893", 0, "28ae9d21-a197-4734-83e1-a0a36ad80843", "user@user.com", true, false, null, null, "USER@USER.COM", "USER", "AQAAAAIAAYagAAAAEDe+3C3DBexdq25PK96atODZ3bYl99zyqA8paC5h/v5UHKEsStY497F31V258rBbzw==", null, false, null, "", false, "user", null, null, null, null, null, null, null, null },
                    { "9ef16119-f9fa-4b54-9d9b-5417e5462c37", 0, "d95fff77-a681-459f-a6ee-a3d92e3d1331", "mtv@admin.com", true, false, null, null, "INSPECTOR@ADMIN.COM", "INSPECTORADMIN", "AQAAAAIAAYagAAAAEICh5fhQ91EmtVSPXJmfCuAGvwNrzWoG6QbFLCJArVCnBS4gz7lxx7ZbxOxs6p3Q5Q==", null, false, null, "", false, "inspectoradmin", null, null, null, null, null, null, null, null },
                    { "b305908f-7e27-4356-a112-2778fbf621d2", 0, "ebab2d45-288a-4ce8-a299-1daab27d69e4", "meat@inspector.com", true, false, null, null, "MEAT@INSPECTOR.COM", "MEATINSPECTOR", "AQAAAAIAAYagAAAAEKsXOCIXgO7ked17C6EbZ1yQeKkTkmNXFexpilp8mRGVsHvWyPU5pxsoLD4Xg4OXXA==", null, false, null, "", false, "meatinspector", null, null, null, null, null, null, null, null },
                    { "cce24038-224f-4626-98aa-2a4df54a5c35", 0, "64971b23-0ad5-4eee-b5c2-267df9f079d8", "mtv@inspector.com", true, false, null, null, "MTV@INSPECTOR.COM", "MTVINSPECTOR", "AQAAAAIAAYagAAAAEO12cJ+0lgQ6nGvqgyyCrPqExosPpga/fM+uekrQbg1mc9luWPh6VmXyuFAGgLI0bw==", null, false, null, "", false, "mtvinspector", null, null, null, null, null, null, null, null },
                    { "daff8249-afac-40a5-85c3-ad726961b3aa", 0, "ec9f92de-aca0-4750-be14-2f4de4153c9f", "meat@rep.com", true, false, null, null, "MEAT@REP.COM", "MEATREP", "AQAAAAIAAYagAAAAEBIDqBK68gxzAFiMnUeZ/tJyBxBvh821vtZQ1dZm/zQ9otYpBxQ6RoBzUesL3PlhAg==", null, false, null, "", false, "meatrep", null, null, null, null, null, null, null, null },
                    { "f66739a0-476f-47e5-a7fd-3a84047af089", 0, "fd27ff06-ffea-410f-82ca-087cf50f6f8a", "super@admin.com", true, false, null, null, "SUPER@ADMIN.COM", "SUPERADMIN", "AQAAAAIAAYagAAAAEAApWY/IO/f7XJG5ov4F94XyIYdupZzpNGHqM+jlweekFtOs5hAAUtKLge7BDKn5Zw==", null, false, null, "", false, "superadmin", null, null, null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a0ba380e-aa40-4351-96f9-735e087ce21f", "26924353-da23-4429-ab55-446a56c9f5b9" },
                    { "efdf3dd1-18a5-4cbc-9310-3ce07f75bfc6", "2b81fc12-d568-4be5-9ae6-8de0ce5eff94" },
                    { "bf8bce35-2ce9-4cbe-b7ad-5090d976f49f", "30c71afd-3c9c-4508-85e6-e04ebc764893" },
                    { "8ff06b4e-ed7c-4ace-9956-d88366b7f786", "9ef16119-f9fa-4b54-9d9b-5417e5462c37" },
                    { "dddf7db0-ddaf-447b-8d94-64f294b55e87", "b305908f-7e27-4356-a112-2778fbf621d2" },
                    { "a9e34847-ce14-43cd-9e2e-b2b38eae70a1", "cce24038-224f-4626-98aa-2a4df54a5c35" },
                    { "18624e89-0312-4d39-8e7a-0e9701fff257", "daff8249-afac-40a5-85c3-ad726961b3aa" },
                    { "df6864e8-c680-4df8-8bcc-990ac0d318bf", "f66739a0-476f-47e5-a7fd-3a84047af089" }
                });

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
                name: "IX_AspNetUsers_MeatEstablishmentId",
                table: "AspNetUsers",
                column: "MeatEstablishmentId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ConductOfInspections_MeatInspectionReportId",
                table: "ConductOfInspections",
                column: "MeatInspectionReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DisapprovedApplications_MTVInspectionId",
                table: "DisapprovedApplications",
                column: "MTVInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MeatDealers_MeatEstablishmentId",
                table: "MeatDealers",
                column: "MeatEstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MeatInspectionReports_AccountDetailsId",
                table: "MeatInspectionReports",
                column: "AccountDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MeatInspectionReports_ReceivingReportId",
                table: "MeatInspectionReports",
                column: "ReceivingReportId");

            migrationBuilder.CreateIndex(
                name: "IX_MTVApplicationResults_MTVInspectionId",
                table: "MTVApplicationResults",
                column: "MTVInspectionId");

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

            migrationBuilder.CreateIndex(
                name: "IX_MTVInspection_MTVApplicationId",
                table: "MTVInspection",
                column: "MTVApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MTVquizzes_MTVApplicationId",
                table: "MTVquizzes",
                column: "MTVApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_PassedForSlaughters_ConductOfInspectionId",
                table: "PassedForSlaughters",
                column: "ConductOfInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MTVApplicationId",
                table: "Payments",
                column: "MTVApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Postmortems_PassedForSlaughterId",
                table: "Postmortems",
                column: "PassedForSlaughterId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingReports_AccountDetailsId",
                table: "ReceivingReports",
                column: "AccountDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingReports_MeatDealersId",
                table: "ReceivingReports",
                column: "MeatDealersId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivings_AccountDetailsId",
                table: "Receivings",
                column: "AccountDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryAndDistributionOfMICs_TotalNoFitForHumanConsumptionId",
                table: "SummaryAndDistributionOfMICs",
                column: "TotalNoFitForHumanConsumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalNoFitForHumanConsumptions_PostmortemId",
                table: "TotalNoFitForHumanConsumptions",
                column: "PostmortemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "CheckLists");

            migrationBuilder.DropTable(
                name: "DisapprovedApplications");

            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "LogTransactions");

            migrationBuilder.DropTable(
                name: "MTVApplicationResults");

            migrationBuilder.DropTable(
                name: "MTVDetails");

            migrationBuilder.DropTable(
                name: "MTVquizzes");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PostArticles");

            migrationBuilder.DropTable(
                name: "QrCodes");

            migrationBuilder.DropTable(
                name: "Receivings");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "SummaryAndDistributionOfMICs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "MTVInspection");

            migrationBuilder.DropTable(
                name: "TotalNoFitForHumanConsumptions");

            migrationBuilder.DropTable(
                name: "MTVApplications");

            migrationBuilder.DropTable(
                name: "Postmortems");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Helpers");

            migrationBuilder.DropTable(
                name: "VehicleInfos");

            migrationBuilder.DropTable(
                name: "PassedForSlaughters");

            migrationBuilder.DropTable(
                name: "ConductOfInspections");

            migrationBuilder.DropTable(
                name: "MeatInspectionReports");

            migrationBuilder.DropTable(
                name: "ReceivingReports");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MeatDealers");

            migrationBuilder.DropTable(
                name: "MeatEstablishment");
        }
    }
}

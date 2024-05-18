using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccountDetailsMeatDealersMeatEstablishmentsIDtoGUID : Migration
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeatEstablishmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeatEstablishmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    MeatDealersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    { "04d8e8e2-d7ee-4520-b877-c725072d94ec", null, "SuperAdministrator", "SUPERADMIN" },
                    { "0dac8dc3-f119-4fee-9834-3ff9d3287b59", null, "MTVAdministrator", "MTVADMIN" },
                    { "539bb59f-c3b2-4abc-b917-a77eeb32f840", null, "MeatInspector", "MEATINSPECTOR" },
                    { "797dcc59-cbd5-4ded-b457-bdbebd6bb8dd", null, "User", "USER" },
                    { "821456fc-93cd-4175-ac2c-893b1e3869f6", null, "MtvInspector", "MTVINSPECTOR" },
                    { "9de5f368-d024-43d5-bbb1-b229c6089ed4", null, "InspectorAdministrator", "INSPECTORADMIN" },
                    { "c489a85a-e6b7-4c78-8c56-3e56b921e272", null, "MtvUsers", "MTVUSERS" },
                    { "fe89ea6b-87c6-47d3-b436-302e80b40990", null, "MeatEstablishmentRepresentative", "MEATESTABLISHMENTREPRESENTATIVE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "MeatEstablishmentId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "birthdate", "contactNo", "firstName", "image", "lastName", "middleName", "sex" },
                values: new object[,]
                {
                    { "4e441fb6-60da-4990-9336-77dfc32126d9", 0, "7f5d0158-581f-47ac-a82e-7ccd0f306950", "mtv@user.com", true, false, null, null, "MTV@USER.COM", "MTVUSER", "AQAAAAIAAYagAAAAEBa2WHpsJsZygtT1FzfZqJbrj/wvkEsVzTSTUzwX/XgK+Mt6qOAXYBy8BNMvZehFKg==", null, false, "", false, "mtvuser", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null },
                    { "56d669d2-dca4-4f8b-bf17-421daf7d5c18", 0, "ad6b9239-e01d-4a4c-af23-77ae415bedf2", "super@admin.com", true, false, null, null, "SUPER@ADMIN.COM", "SUPERADMIN", "AQAAAAIAAYagAAAAEKyfa2ZVmOcFRjIpV8M9SPBHvBOmaglb3CWbTeHBb9QAVeBfnToal6L5+4/1cIGUcw==", null, false, "", false, "superadmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null },
                    { "67a6201a-b480-4cab-8e38-3a8bec08811c", 0, "65430640-f721-494c-a62d-0a559de96685", "meat@inspector.com", true, false, null, null, "MEAT@INSPECTOR.COM", "MEATINSPECTOR", "AQAAAAIAAYagAAAAEALGhwIHdFVheEwzNKl86LTs/ulbLBeHyRtGteMowHQ0WjZS86LoG7yLGKXivZstag==", null, false, "", false, "meatinspector", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null },
                    { "91f28271-7976-4a7f-ac8f-bb1f927f8734", 0, "f134e581-7497-43a0-b612-65234aae6f35", "mtv@admin.com", true, false, null, null, "MTV@ADMIN.COM", "MTVRADMIN", "AQAAAAIAAYagAAAAEPf1RRSL2lHyjIUWyv3E2kEnUpnUE/HQGdHKnh+rF9Uz67TXbtoOjPMRzeYczhmxJw==", null, false, "", false, "mtvadmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null },
                    { "942929e4-a6c0-4314-a9eb-4a2f7a68efa0", 0, "f545a3c5-af88-47a7-ae1c-c387ef066078", "mtv@inspector.com", true, false, null, null, "MTV@INSPECTOR.COM", "MTVINSPECTOR", "AQAAAAIAAYagAAAAECBlPMmzfaSk5t9o6Ee+xoxmM8Bj9Vo/XtbdasYgLuKOahckBmK8exWV5VOuEfh09Q==", null, false, "", false, "mtvinspector", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null },
                    { "a95a65f1-99b6-4490-822f-b448f8f0b288", 0, "5f61b9e2-d7a3-43ad-8d17-cb1c756bd711", "meat@rep.com", true, false, null, null, "MEAT@REP.COM", "MEATREP", "AQAAAAIAAYagAAAAEObrYW2Mz2DeetU/OT7UiPqk26bZprAuqgZiJ3jDBpJr3kvgMYKzxqX+3cpZH1prcw==", null, false, "", false, "meatrep", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null },
                    { "c639668b-1fe3-4a14-80b8-e0e6cb61f1c8", 0, "99866736-b681-42d9-85e3-d1ac366c8e3c", "user@user.com", true, false, null, null, "USER@USER.COM", "USER", "AQAAAAIAAYagAAAAEAWlviQ9fUhoB1djzy89AKKR78ChFD6M1jNwznbqMoQMxYosn6L2Ke+Cbtm+yn8nuA==", null, false, "", false, "user", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null },
                    { "f5026bb4-e4e6-44d3-8a57-b2a3f25d0a90", 0, "1cd21b91-2b48-43b8-a5b4-c02aa99e8807", "mtv@admin.com", true, false, null, null, "INSPECTOR@ADMIN.COM", "INSPECTORADMIN", "AQAAAAIAAYagAAAAECfW34atkK3pvlGEm7CkpG2mEsy7IMY24Y18RFRn2xwOC8v6YfLvbLyUrFdrG3Dj2g==", null, false, "", false, "inspectoradmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c489a85a-e6b7-4c78-8c56-3e56b921e272", "4e441fb6-60da-4990-9336-77dfc32126d9" },
                    { "04d8e8e2-d7ee-4520-b877-c725072d94ec", "56d669d2-dca4-4f8b-bf17-421daf7d5c18" },
                    { "539bb59f-c3b2-4abc-b917-a77eeb32f840", "67a6201a-b480-4cab-8e38-3a8bec08811c" },
                    { "0dac8dc3-f119-4fee-9834-3ff9d3287b59", "91f28271-7976-4a7f-ac8f-bb1f927f8734" },
                    { "821456fc-93cd-4175-ac2c-893b1e3869f6", "942929e4-a6c0-4314-a9eb-4a2f7a68efa0" },
                    { "fe89ea6b-87c6-47d3-b436-302e80b40990", "a95a65f1-99b6-4490-822f-b448f8f0b288" },
                    { "797dcc59-cbd5-4ded-b457-bdbebd6bb8dd", "c639668b-1fe3-4a14-80b8-e0e6cb61f1c8" },
                    { "9de5f368-d024-43d5-bbb1-b229c6089ed4", "f5026bb4-e4e6-44d3-8a57-b2a3f25d0a90" }
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

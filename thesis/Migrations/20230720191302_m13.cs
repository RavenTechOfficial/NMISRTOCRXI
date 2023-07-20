using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class m13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    TelNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Helpers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HelperFname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HelperMname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HelperLname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helpers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MTVquizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MTVApplicationId = table.Column<int>(type: "int", nullable: false),
                    passorfail = table.Column<int>(type: "int", nullable: false),
                    applicationtype = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    plateNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "checklists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MTVquizId = table.Column<int>(type: "int", nullable: false),
                    passorfail = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checklists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_checklists_MTVquizzes_MTVquizId",
                        column: x => x.MTVquizId,
                        principalTable: "MTVquizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_checklists_MTVquizId",
                table: "checklists",
                column: "MTVquizId");

            migrationBuilder.CreateIndex(
                name: "IX_MTVquizzes_MTVApplicationId",
                table: "MTVquizzes",
                column: "MTVApplicationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "checklists");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Helpers");

            migrationBuilder.DropTable(
                name: "MTVquizzes");
        }
    }
}

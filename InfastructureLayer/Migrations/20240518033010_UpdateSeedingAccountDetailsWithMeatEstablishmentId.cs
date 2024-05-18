using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InfastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedingAccountDetailsWithMeatEstablishmentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c489a85a-e6b7-4c78-8c56-3e56b921e272", "4e441fb6-60da-4990-9336-77dfc32126d9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04d8e8e2-d7ee-4520-b877-c725072d94ec", "56d669d2-dca4-4f8b-bf17-421daf7d5c18" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "539bb59f-c3b2-4abc-b917-a77eeb32f840", "67a6201a-b480-4cab-8e38-3a8bec08811c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0dac8dc3-f119-4fee-9834-3ff9d3287b59", "91f28271-7976-4a7f-ac8f-bb1f927f8734" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "821456fc-93cd-4175-ac2c-893b1e3869f6", "942929e4-a6c0-4314-a9eb-4a2f7a68efa0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fe89ea6b-87c6-47d3-b436-302e80b40990", "a95a65f1-99b6-4490-822f-b448f8f0b288" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "797dcc59-cbd5-4ded-b457-bdbebd6bb8dd", "c639668b-1fe3-4a14-80b8-e0e6cb61f1c8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9de5f368-d024-43d5-bbb1-b229c6089ed4", "f5026bb4-e4e6-44d3-8a57-b2a3f25d0a90" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04d8e8e2-d7ee-4520-b877-c725072d94ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dac8dc3-f119-4fee-9834-3ff9d3287b59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "539bb59f-c3b2-4abc-b917-a77eeb32f840");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "797dcc59-cbd5-4ded-b457-bdbebd6bb8dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "821456fc-93cd-4175-ac2c-893b1e3869f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9de5f368-d024-43d5-bbb1-b229c6089ed4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c489a85a-e6b7-4c78-8c56-3e56b921e272");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe89ea6b-87c6-47d3-b436-302e80b40990");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e441fb6-60da-4990-9336-77dfc32126d9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "56d669d2-dca4-4f8b-bf17-421daf7d5c18");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "67a6201a-b480-4cab-8e38-3a8bec08811c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91f28271-7976-4a7f-ac8f-bb1f927f8734");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "942929e4-a6c0-4314-a9eb-4a2f7a68efa0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a95a65f1-99b6-4490-822f-b448f8f0b288");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c639668b-1fe3-4a14-80b8-e0e6cb61f1c8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f5026bb4-e4e6-44d3-8a57-b2a3f25d0a90");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "115ef19f-ba67-4fb5-9640-b91a9c1e94bc", null, "MeatEstablishmentRepresentative", "MEATESTABLISHMENTREPRESENTATIVE" },
                    { "64f39e6f-e876-4299-a553-2ca52f2ad18a", null, "MtvUsers", "MTVUSERS" },
                    { "74eb8943-aeab-48e8-9b7d-6a50a5854d66", null, "SuperAdministrator", "SUPERADMIN" },
                    { "883ad528-c9a8-403c-9f18-7bffc64acc61", null, "User", "USER" },
                    { "a5202a8b-d580-4aa9-900e-9db890a9cc96", null, "MtvInspector", "MTVINSPECTOR" },
                    { "c45abf96-27b1-40cc-bd5a-1e0e896aea57", null, "InspectorAdministrator", "INSPECTORADMIN" },
                    { "df668694-110f-4440-b790-9fb8f0c71327", null, "MTVAdministrator", "MTVADMIN" },
                    { "f53efde5-ecd8-44f8-9be7-4f0632ae5c59", null, "MeatInspector", "MEATINSPECTOR" }
                });

            migrationBuilder.InsertData(
                table: "MeatEstablishment",
                columns: new[] { "Id", "Address", "Lat", "LicenseStatus", "LicenseToOperateNumber", "Long", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("0f32cd34-8346-461c-8a1c-3273f4f4d098"), null, 0.0, 0, "71c04653-66a2-4bb9-8dda-87198b7d800b", 0.0, "Meat Establishment 1", 0 },
                    { new Guid("bab844f5-991c-4ecd-bd2e-d1f407c17036"), null, 0.0, 0, "025f2b38-8ade-4e81-b787-2ce564f2fd29", 0.0, "Meat Establishment 4", 1 },
                    { new Guid("d21b287d-8e00-4bfb-beea-5cea7b419546"), null, 0.0, 0, "1bac1e15-ce58-4896-8651-b3b4324eb57b", 0.0, "Meat Establishment 2", 3 },
                    { new Guid("eba443da-7bed-4469-99b1-cd15394c4e26"), null, 0.0, 1, "23a46c9c-ab84-4cdc-931f-d52983e1c52b", 0.0, "Meat Establishment 3", 2 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "MeatEstablishmentId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "address", "birthdate", "contactNo", "firstName", "image", "lastName", "middleName", "sex" },
                values: new object[,]
                {
                    { "16d52f03-c3bc-4657-8bce-6a8e90376885", 0, "63aa6c4f-52e8-41a7-ac67-ec220d3a7b33", "mtv@admin.com", true, false, null, new Guid("eba443da-7bed-4469-99b1-cd15394c4e26"), "MTV@ADMIN.COM", "MTVRADMIN", "AQAAAAIAAYagAAAAEOWvwy3+iHaI2DORmspoLb3qbOy2OqzSYYbgnsAxjbnm0mRijMdWMNXmIysvjb1eJQ==", null, false, "", false, "mtvadmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null },
                    { "396a3331-817b-486d-997c-b455be314795", 0, "0041d2d8-d7fe-460c-ad07-9d61c77c3a62", "mtv@admin.com", true, false, null, new Guid("d21b287d-8e00-4bfb-beea-5cea7b419546"), "INSPECTOR@ADMIN.COM", "INSPECTORADMIN", "AQAAAAIAAYagAAAAEPAzv5cHV3lbkCld8Se9qD5xEwYBaqK1jt7Hh4xV5nLdJdpaKb+4oZeZ9sT2Dq3bRw==", null, false, "", false, "inspectoradmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null },
                    { "40391f3e-b54c-4c84-bf11-31f435273605", 0, "05be979a-90cd-452a-acf8-012aee7bef5b", "super@admin.com", true, false, null, new Guid("0f32cd34-8346-461c-8a1c-3273f4f4d098"), "SUPER@ADMIN.COM", "SUPERADMIN", "AQAAAAIAAYagAAAAEHFIrbrSm9g6kQJDLS2W5jRIxiKlfd3yPNrXhNZacA0sHXVXLsRyHHqRoqOnirktXQ==", null, false, "", false, "superadmin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null },
                    { "489322fc-9ee4-4540-98c6-4db112033c06", 0, "c90fd558-f828-43ae-95e3-65b300873c05", "mtv@user.com", true, false, null, new Guid("bab844f5-991c-4ecd-bd2e-d1f407c17036"), "MTV@USER.COM", "MTVUSER", "AQAAAAIAAYagAAAAEAB+jcEdqFRTzo9MzBworjxUb9oZP5PR4BnspY3TIqIlAd2qbVya2TB9szdizAq1dQ==", null, false, "", false, "mtvuser", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null },
                    { "81eab651-1155-4e57-8096-fa775110e0b3", 0, "d9d1d970-c496-4e9d-8e67-77afb3ead3bf", "user@user.com", true, false, null, new Guid("bab844f5-991c-4ecd-bd2e-d1f407c17036"), "USER@USER.COM", "USER", "AQAAAAIAAYagAAAAEHTTmmNYX+M5UT3s5fh1oH9LtbGf4gqgl5IR8EozlJWSnlc3FkmXbyvTGaG+3vcwBA==", null, false, "", false, "user", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null },
                    { "8b1a576f-2e46-426e-9475-e5e8ab15f43a", 0, "dff1729a-bd95-46bc-a542-2af787bd87e7", "mtv@inspector.com", true, false, null, new Guid("eba443da-7bed-4469-99b1-cd15394c4e26"), "MTV@INSPECTOR.COM", "MTVINSPECTOR", "AQAAAAIAAYagAAAAEOm+szFfn2Cg470PivD58doJNCpQPNH/lx2StLX7Nh4oyU+UeMmY7oQdYW7E3puttQ==", null, false, "", false, "mtvinspector", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null },
                    { "cd457db5-f2b0-4f29-a08e-7f2dbaae9f81", 0, "164380fc-a7fb-4b79-89ed-246d7beea53a", "meat@rep.com", true, false, null, new Guid("0f32cd34-8346-461c-8a1c-3273f4f4d098"), "MEAT@REP.COM", "MEATREP", "AQAAAAIAAYagAAAAEJG7fzCtkhPWaH6ujhXoYZwM8qH+buccMf8oeZdg7VuaYQhKcuXukkV0UPAfdQlPrA==", null, false, "", false, "meatrep", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null },
                    { "e7e77c05-4e01-4362-a6aa-af801894fa7a", 0, "5958e0ae-9976-49e7-87dc-e63782dbe847", "meat@inspector.com", true, false, null, new Guid("d21b287d-8e00-4bfb-beea-5cea7b419546"), "MEAT@INSPECTOR.COM", "MEATINSPECTOR", "AQAAAAIAAYagAAAAEJN3hu8pDDND+7FlLQRnCCQFS0+92FsnKG3jQCTuNbsc5T1k6sgqZKZ+9imZobAA3Q==", null, false, "", false, "meatinspector", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "MeatDealers",
                columns: new[] { "Id", "Address", "ContactNo", "FirstName", "LastName", "MeatEstablishmentId", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("203df488-a939-4b85-9f8e-1a7bff9af18c"), null, null, "Meat", "Dealer 1", new Guid("0f32cd34-8346-461c-8a1c-3273f4f4d098"), null },
                    { new Guid("3b6757a8-8280-42de-84dd-e5cd8d926284"), null, null, "Meat", "Dealer 2", new Guid("d21b287d-8e00-4bfb-beea-5cea7b419546"), null },
                    { new Guid("c597346a-bb69-4fee-ba30-f6d46a8b0e70"), null, null, "Meat", "Dealer 4", new Guid("bab844f5-991c-4ecd-bd2e-d1f407c17036"), null },
                    { new Guid("e5593a4e-e953-42d4-b7e2-378eb7a9c639"), null, null, "Meat", "Dealer 3", new Guid("eba443da-7bed-4469-99b1-cd15394c4e26"), null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "df668694-110f-4440-b790-9fb8f0c71327", "16d52f03-c3bc-4657-8bce-6a8e90376885" },
                    { "c45abf96-27b1-40cc-bd5a-1e0e896aea57", "396a3331-817b-486d-997c-b455be314795" },
                    { "74eb8943-aeab-48e8-9b7d-6a50a5854d66", "40391f3e-b54c-4c84-bf11-31f435273605" },
                    { "64f39e6f-e876-4299-a553-2ca52f2ad18a", "489322fc-9ee4-4540-98c6-4db112033c06" },
                    { "883ad528-c9a8-403c-9f18-7bffc64acc61", "81eab651-1155-4e57-8096-fa775110e0b3" },
                    { "a5202a8b-d580-4aa9-900e-9db890a9cc96", "8b1a576f-2e46-426e-9475-e5e8ab15f43a" },
                    { "115ef19f-ba67-4fb5-9640-b91a9c1e94bc", "cd457db5-f2b0-4f29-a08e-7f2dbaae9f81" },
                    { "f53efde5-ecd8-44f8-9be7-4f0632ae5c59", "e7e77c05-4e01-4362-a6aa-af801894fa7a" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "df668694-110f-4440-b790-9fb8f0c71327", "16d52f03-c3bc-4657-8bce-6a8e90376885" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c45abf96-27b1-40cc-bd5a-1e0e896aea57", "396a3331-817b-486d-997c-b455be314795" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "74eb8943-aeab-48e8-9b7d-6a50a5854d66", "40391f3e-b54c-4c84-bf11-31f435273605" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "64f39e6f-e876-4299-a553-2ca52f2ad18a", "489322fc-9ee4-4540-98c6-4db112033c06" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "883ad528-c9a8-403c-9f18-7bffc64acc61", "81eab651-1155-4e57-8096-fa775110e0b3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a5202a8b-d580-4aa9-900e-9db890a9cc96", "8b1a576f-2e46-426e-9475-e5e8ab15f43a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "115ef19f-ba67-4fb5-9640-b91a9c1e94bc", "cd457db5-f2b0-4f29-a08e-7f2dbaae9f81" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f53efde5-ecd8-44f8-9be7-4f0632ae5c59", "e7e77c05-4e01-4362-a6aa-af801894fa7a" });

            migrationBuilder.DeleteData(
                table: "MeatDealers",
                keyColumn: "Id",
                keyValue: new Guid("203df488-a939-4b85-9f8e-1a7bff9af18c"));

            migrationBuilder.DeleteData(
                table: "MeatDealers",
                keyColumn: "Id",
                keyValue: new Guid("3b6757a8-8280-42de-84dd-e5cd8d926284"));

            migrationBuilder.DeleteData(
                table: "MeatDealers",
                keyColumn: "Id",
                keyValue: new Guid("c597346a-bb69-4fee-ba30-f6d46a8b0e70"));

            migrationBuilder.DeleteData(
                table: "MeatDealers",
                keyColumn: "Id",
                keyValue: new Guid("e5593a4e-e953-42d4-b7e2-378eb7a9c639"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "115ef19f-ba67-4fb5-9640-b91a9c1e94bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64f39e6f-e876-4299-a553-2ca52f2ad18a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74eb8943-aeab-48e8-9b7d-6a50a5854d66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "883ad528-c9a8-403c-9f18-7bffc64acc61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5202a8b-d580-4aa9-900e-9db890a9cc96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c45abf96-27b1-40cc-bd5a-1e0e896aea57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df668694-110f-4440-b790-9fb8f0c71327");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f53efde5-ecd8-44f8-9be7-4f0632ae5c59");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16d52f03-c3bc-4657-8bce-6a8e90376885");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "396a3331-817b-486d-997c-b455be314795");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40391f3e-b54c-4c84-bf11-31f435273605");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "489322fc-9ee4-4540-98c6-4db112033c06");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81eab651-1155-4e57-8096-fa775110e0b3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b1a576f-2e46-426e-9475-e5e8ab15f43a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd457db5-f2b0-4f29-a08e-7f2dbaae9f81");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7e77c05-4e01-4362-a6aa-af801894fa7a");

            migrationBuilder.DeleteData(
                table: "MeatEstablishment",
                keyColumn: "Id",
                keyValue: new Guid("0f32cd34-8346-461c-8a1c-3273f4f4d098"));

            migrationBuilder.DeleteData(
                table: "MeatEstablishment",
                keyColumn: "Id",
                keyValue: new Guid("bab844f5-991c-4ecd-bd2e-d1f407c17036"));

            migrationBuilder.DeleteData(
                table: "MeatEstablishment",
                keyColumn: "Id",
                keyValue: new Guid("d21b287d-8e00-4bfb-beea-5cea7b419546"));

            migrationBuilder.DeleteData(
                table: "MeatEstablishment",
                keyColumn: "Id",
                keyValue: new Guid("eba443da-7bed-4469-99b1-cd15394c4e26"));

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
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        private string SuperAdminRoleId = Guid.NewGuid().ToString();
        private string InspectorAdminRoleId = Guid.NewGuid().ToString();
        private string MTVAdminRoleId = Guid.NewGuid().ToString();
        private string UserRoleId = Guid.NewGuid().ToString();
        private string MeatEstRepId = Guid.NewGuid().ToString();
        private string MeatInspectorId = Guid.NewGuid().ToString();
        private string MTVInspectorId = Guid.NewGuid().ToString();
        private string MTVUsersId = Guid.NewGuid().ToString();

        private string User1Id = "3646c7fa-3a20-4f9e-b0e0-542ac8941347"; //gerico team
        private string User2Id = "afc037a4-1a6f-4e42-9952-67d0cc121b23"; //mary team
        private string User3Id = "5ca9d0b5-fced-4687-9e7e-5579050584d6"; //karlo team
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);
        }
        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            //VALUES ('{SuperAdminRoleId}', 'SuperAdministrator', 'SUPERADMIN', null);");
            //migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            //VALUES ('{InspectorAdminRoleId}', 'InspectorAdministrator', 'INSPECTORADMIN', null);");
            //migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            //VALUES ('{MTVAdminRoleId}', 'MTVAdministrator', 'MTVADMIN', null);");
            //migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            //VALUES ('{UserRoleId}', 'User', 'USER', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{MeatEstRepId}', 'MeatEstablishmentRepresentative', 'MEATESTABLISHMENTREPRESENTATIVE', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{MeatInspectorId}', 'MeatInspector', 'MEATINSPECTOR', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{MTVInspectorId}', 'MtvInspector', 'MTVINSPECTOR', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{MTVUsersId}', 'MtvUsers', 'MTVUSERS', null);");
        }

        private void SeedUserRoles(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User1Id}', '{SuperAdminRoleId}');");

            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User2Id}', '{InspectorAdminRoleId}');");

            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User3Id}', '{MTVAdminRoleId}');");
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

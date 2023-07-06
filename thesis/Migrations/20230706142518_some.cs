using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class some : Migration
    {
        private string SuperAdminRoleId = Guid.NewGuid().ToString();
        private string InspectorAdminRoleId = Guid.NewGuid().ToString();
        private string MTVAdminRoleId = Guid.NewGuid().ToString();
        private string UserRoleId = Guid.NewGuid().ToString();

        private string User1Id = "1879a62f-717a-4c00-92e0-daaeec2efd8c"; //gerico team
        private string User2Id = "8bf64eb8-7d9d-4773-bb59-ccf1e5a43857"; //mary team
        private string User3Id = "e0a3bd77-c4bf-49bc-a4df-f70816102952"; //karlo team
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);

            SeedUserRoles(migrationBuilder);
        }
        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{SuperAdminRoleId}', 'SuperAdministrator', 'SUPERADMIN', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{InspectorAdminRoleId}', 'InspectorAdministrator', 'INSPECTORADMIN', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{MTVAdminRoleId}', 'MTVAdministrator', 'MTVADMIN', null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{UserRoleId}', 'User', 'USER', null);");
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

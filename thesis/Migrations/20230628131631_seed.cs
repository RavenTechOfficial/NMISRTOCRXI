using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        private string SuperAdminRoleId = Guid.NewGuid().ToString();
        private string InspectorAdminRoleId = Guid.NewGuid().ToString();
        private string MTVAdminRoleId = Guid.NewGuid().ToString();
        private string UserRoleId = Guid.NewGuid().ToString();

        private string User1Id = "55bdac6c-f6b3-4213-8acf-02eaae2f9328"; //gerico team
        private string User2Id = "4c4e9ea4-9367-4001-9c94-3b6c816538ad"; //mary team
        private string User3Id = "cc6f17ff-ee8b-4cda-8b2a-9dd2deb3fcb9"; //karlo team
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

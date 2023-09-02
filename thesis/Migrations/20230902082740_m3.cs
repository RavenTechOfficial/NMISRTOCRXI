using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
		private string SuperAdminRoleId = Guid.NewGuid().ToString();
		private string InspectorAdminRoleId = Guid.NewGuid().ToString();
		private string MTVAdminRoleId = Guid.NewGuid().ToString();
		private string UserRoleId = Guid.NewGuid().ToString();
		private string MeatEstRepId = Guid.NewGuid().ToString();
		private string MeatInspectorId = Guid.NewGuid().ToString();
		private string MTVInspectorId = Guid.NewGuid().ToString();
		private string MTVUsersId = Guid.NewGuid().ToString();
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
        {
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
			migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{MeatEstRepId}', 'MeatEstablishmentRepresentative', 'MEATESTABLISHMENTREPRESENTATIVE', null);");
			migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{MeatInspectorId}', 'MeatInspector', 'MEATINSPECTOR', null);");
			migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{MTVInspectorId}', 'MtvInspector', 'MTVINSPECTOR', null);");
			migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{MTVUsersId}', 'MtvUsers', 'MTVUSERS', null);");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

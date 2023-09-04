using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thesis.Migrations
{
	/// <inheritdoc />
	public partial class PostArticlep : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "PostArticles",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Introduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Conclusion = table.Column<string>(type: "nvarchar(max)", nullable: true),
					References = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PostArticles", x => x.Id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "PostArticles");
		}
	}
	}

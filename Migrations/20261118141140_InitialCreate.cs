using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechStack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GitHubUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "DisplayOrder", "GitHubUrl", "TechStack", "Title" },
                values: new object[,]
                {
                    { 1, "AI-assisted multi-warehouse inventory management system with a transactional stock engine, Admin-only access, and a live KPI dashboard.", 1, "https://github.com/Mukul-Choudhari/StockPilot", "ASP.NET Core MVC, EF Core, SQL Server, Chart.js, Gemini API, xUnit, Swagger", "StockPilot" },
                    { 2, "This single-page portfolio website, with project content loaded from a SQL Server database.", 2, "https://github.com/Mukul-Choudhari/Portfolio", "ASP.NET Core MVC, Razor, EF Core, SQL Server, Bootstrap, JavaScript", "Portfolio" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}

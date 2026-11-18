using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Data;

public class PortfolioDbContext : DbContext
{
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
        : base(options) { }

    public DbSet<Project> Projects => Set<Project>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = 1,
                Title = "StockPilot",
                Description = "AI-assisted multi-warehouse inventory management system with a transactional stock engine, Admin-only access, and a live KPI dashboard.",
                TechStack = "ASP.NET Core MVC, EF Core, SQL Server, Chart.js, Gemini API, xUnit, Swagger",
                GitHubUrl = "https://github.com/Mukul-Choudhari/StockPilot",
                DisplayOrder = 1
            },
            new Project
            {
                Id = 2,
                Title = "Portfolio",
                Description = "This single-page portfolio website, with project content loaded from a SQL Server database.",
                TechStack = "ASP.NET Core MVC, Razor, EF Core, SQL Server, Bootstrap, JavaScript",
                GitHubUrl = "https://github.com/Mukul-Choudhari/Portfolio",
                DisplayOrder = 2
            }
        );
    }
}
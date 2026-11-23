using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();

    [HttpGet]
    public IActionResult Projects()
    {
        var projects = new List<Project>
        {
            new Project
            {
                Id = 1,
                Title = "StockPilot",
                Description = "ASP.NET Core MVC & Web API inventory management system with EF Core, ASP.NET Core Identity role-based access, and Google Gemini AI integration.",
                TechStack = "ASP.NET Core, C#, EF Core, SQL Server, Identity, Gemini SDK",
                GitHubUrl = "https://github.com/Mukul-Choudhari/StockPilot",
                DemoUrl = "https://your-video-link-here", // e.g., YouTube or Google Drive share link
                DisplayOrder = 1
            },
            new Project
            {
                Id = 2,
                Title = "Portfolio",
                Description = "Personal developer portfolio built with ASP.NET Core MVC and deployed on Railway.",
                TechStack = "ASP.NET Core, C#, HTML, CSS, JavaScript",
                GitHubUrl = "https://github.com/Mukul-Choudhari/Portfolio",
                DemoUrl = null,
                DisplayOrder = 2
            }
        };

        return Json(projects);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers;

public class HomeController : Controller
{
    private readonly PortfolioDbContext _db;

    public HomeController(PortfolioDbContext db)
    {
        _db = db;
    }

    public IActionResult Index() => View();

    [HttpGet]
    public async Task<IActionResult> Projects()
    {
        var projects = await _db.Projects
            .AsNoTracking()
            .OrderBy(p => p.DisplayOrder)
            .ToListAsync();

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
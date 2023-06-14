using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebCalcServ.Models;

namespace WebCalcServ.Controllers;

public class GraphController : Controller
{
    private readonly ILogger<GraphController> _logger;

    public GraphController(ILogger<GraphController> logger)
    {
        _logger = logger;
    }

    public IActionResult Calculator()
    {
        return View();
    }

    public IActionResult Graph()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


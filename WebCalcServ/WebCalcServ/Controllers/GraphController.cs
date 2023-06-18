using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebCalcServ.Models;

namespace WebCalcServ.Controllers;

public class GraphController : Controller
{
    private Model _model;
    private readonly ILogger<GraphController> _logger;

    public GraphController(ILogger<GraphController> logger, Model myModel)
    {
        _logger = logger;
        _model = myModel;
    }

    public IActionResult Calculator()
    {
        return View();
    }

    public IActionResult Graph()
    {
        return View();
    }

    [HttpGet]
    [Route("Graph/Draw")]
    public IActionResult Draw()
    {
        double xMin, xMax;
        CalculateData data = new CalculateData();
        if (!(string.IsNullOrWhiteSpace(_model.RawString)) &&
            _model.RawString.Contains("x") &&
            double.TryParse(Request.Query["xMin"].ToString(), out xMin) &&
            double.TryParse(Request.Query["xMax"].ToString(), out xMax)) {
            data.coords = new List<Tuple<double,double>>();
            if (xMin > xMax) {
                double tmp = xMin;
                xMin = xMax;
                xMax = tmp;
            }
            _model.PrepareString();
            double step = Math.Abs(xMax - xMin) / 3000f;
            for (;xMin <= xMax; xMin += step) {
                data.coords.Add(new Tuple<double, double>(xMin, _model.Calculate(xMin)));
            }
        }
        return View("Graph", data);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


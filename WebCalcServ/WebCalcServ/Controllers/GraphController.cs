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

    public IActionResult About()
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
        data.RawLine = _model.RawString;
        if (!(string.IsNullOrWhiteSpace(_model.RawString)) &&
            _model.RawString.Contains("x") &&
            double.TryParse(Request.Query["xMin"].ToString(), out xMin) &&
            double.TryParse(Request.Query["xMax"].ToString(), out xMax)) {
            var listY = new List<double>();
            var listX = new List<double>();
            if (xMin > xMax) {
                double tmp = xMin;
                xMin = xMax;
                xMax = tmp;
            }
            _model.PrepareString();
            double step = Math.Abs(xMax - xMin) / 3000f;
            for (;xMin <= xMax; xMin += step) {
                listX.Add(xMin);
                listY.Add(_model.Calculate(xMin));
            }
            data.CoordinateX = listX.ToArray();
            data.CoordinateY = listY.ToArray();
        }
        return View("Graph", data);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


using System;
using System.Diagnostics;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using WebCalcServ.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebCalcServ.Controllers;

public class HomeController : Controller
{
    private Model _model;
    private readonly ILogger<HomeController> _logger;


    public HomeController(ILogger<HomeController> logger, Model myModel)
    {
        _logger = logger;
        _model = myModel;
    }
    
    public IActionResult Calculator()
    {
        return View();
    }

    [HttpGet]
    [Route("Home/Calculate")]
    public IActionResult Calculate()
    {
        CalculateData data = new CalculateData();
        _model.RawString = Request.Query["line"].ToString(); 
        string XValue = Request.Query["xVal"].ToString();
        data.RawLine = _model.RawString;
        if (_model.RawString.Contains("x"))
        {
            if (string.IsNullOrWhiteSpace(XValue))
            {
                return View("../Graph/Graph");
            }
            else
            {
                _model.RawString = _model.RawString.Replace("x", XValue);
            }
        }

        _model.PrepareString();
        data.Result = _model.Calculate().ToString();
        return View("Calculator", data);
    }

    public IActionResult Graph()
    {
        return View("../Graph/Graph");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


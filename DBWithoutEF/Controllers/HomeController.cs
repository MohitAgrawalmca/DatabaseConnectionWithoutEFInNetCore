using DBWithoutEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DBWithoutEF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration Configuration { get; } 
        public string connStr = String.Empty;
        public HomeController(IConfiguration configuration,ILogger<HomeController> logger)
        {
            Configuration = configuration;
            connStr = Configuration.GetConnectionString("sqlConn");
            _logger = logger;
        }

        public IActionResult Index()
        {
            da baseDataAccess = new da();
            baseDataAccess.getHotels(connStr);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


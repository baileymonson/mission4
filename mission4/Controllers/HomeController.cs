using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext blahContext { get; set; }
        
        //CONSTRUCTOR
        public HomeController(ILogger<HomeController> logger, MovieContext someName)
        {
            _logger = logger;
            blahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        // http get request for movies form
        [HttpGet]
        public IActionResult Movies()
        {
            return View();
        }
        
        // posting the responses from the form to the database
        [HttpPost]
        public IActionResult Movies (ApplicationResponse ar)
        {
            blahContext.Add(ar);
            blahContext.SaveChanges();
            return View("Confirm", ar);
        }
      
        public IActionResult FillOutApplication ()
        {
            return View("Movies");
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

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
        private MovieContext daContext { get; set; }
        
        //CONSTRUCTOR
        public HomeController(ILogger<HomeController> logger, MovieContext someName)
        {
            _logger = logger;
            daContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        // http get request for movies form
        [HttpGet]
        public IActionResult Movies()
        {

            ViewBag.Categories = daContext.Categories.ToList();

            //daContext.responses.ToList();
            return View();
        }
        
        // posting the responses from the form to the database
        [HttpPost]
        public IActionResult Movies (ApplicationResponse ar)
        {
            daContext.responses.Add(ar);
            daContext.SaveChanges();
            return View("Confirm", ar);
        }
      

        [HttpGet]
        public IActionResult MoviesList()
        {
            var applications = daContext.responses.ToList();

            return View(applications);
        }
        public IActionResult FillOutApplication ()
        {
            return View("Movies");
        }
        public IActionResult Privacy()
        {
            return View("Movies");
        }


        // edit page view action
        [HttpGet]
        public IActionResult Edit (int movieid)
        {

            ViewBag.Categories = daContext.Categories.ToList();

            var application = daContext.responses.Single(x => x.MovieId == movieid);

            return View("Movies", application);
        }
        
        [HttpPost]
        public IActionResult Edit (ApplicationResponse blah)
        {

            daContext.responses.Update(blah);
            daContext.SaveChanges();

            return RedirectToAction("MoviesList");
        }

        // delete page view action
        [HttpGet]
        public IActionResult Delete(int movieid)
        {

            var application = daContext.responses.Single(x => x.MovieId == movieid);

            return View(application);
        }
        // post for the delete view action
        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            daContext.responses.Remove(ar);
            daContext.SaveChanges();
            return RedirectToAction("MoviesList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

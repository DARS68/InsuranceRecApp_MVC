using Microsoft.AspNetCore.Mvc;
using pojisteni_FULL.Models;
using System.Diagnostics;

namespace pojisteni_FULL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult InsuredPerson()
        //{
        //    return View();
        //}

        //public IActionResult Insurance()
        //{
        //    return View();
        //}

        //public IActionResult Event()
        //{
        //    return View();
        //}

        //public IActionResult AboutApp()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
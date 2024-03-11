using FizzBuzzParse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FizzBuzzParse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string userInput)
        {
            //var FizzBuzz = new FizzBuzz(userInput);
            var fizzBuzzList = new FizzBuzzList(userInput);
            if(fizzBuzzList.notEmpty)
            {
                foreach (var f in fizzBuzzList.fizzBuzzes)
                {
                    f.InputCheck();
                    f.Parse();
                    f.PrintOutput();
                    ViewBag.Result += f.PrintOutput();
                }
            }
            else
            {
                ViewBag.Result += ("Invalid Item");
            }
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

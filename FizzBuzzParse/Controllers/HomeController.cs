using FizzBuzzParse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FizzBuzzParse.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string userInput)
        {
            //var FizzBuzz = new FizzBuzz(userInput);
            /*Take user input
             *Parse user input and split into elements on array
             *Go through each element and parse the input for FizzBuzz
             *  -If % 3, output Fizz
             *  -If % 5, output Buzz
             *  -If % 3 AND 5, output FizzBuzz
             *  -Otherwise output the division work
             *  -If invalid input (words, blank), output Invalid Item
             *Output results to view
             */
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

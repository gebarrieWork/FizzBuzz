using FizzBuzzParse.Models;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzParse.Controllers
{
    public class HomeControllerDefault : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


    }
}

using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzParse.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace WebApplication15.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Soka.WebUI.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}

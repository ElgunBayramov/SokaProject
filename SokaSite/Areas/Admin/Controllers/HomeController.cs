using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        [Authorize(Policy = "admin.home.index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

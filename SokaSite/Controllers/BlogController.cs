using Microsoft.AspNetCore.Mvc;
using Soka.Domain.Models.DataContexts;
using System.Linq;

namespace Soka.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly SokaDbContext db;

        public BlogController(SokaDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var data = db.BlogPosts.Where(bp => bp.DeletedDate == null).ToList();
            return View(data);
        }
        public IActionResult Details(int id)
        {
            var data = db.BlogPosts.FirstOrDefault(bp => bp.Id == id && bp.DeletedDate==null);
            return View(data);
        }
    }
}

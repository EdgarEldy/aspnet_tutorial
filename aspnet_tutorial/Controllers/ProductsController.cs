using System.Web.Mvc;
using aspnet_tutorial.Data;

namespace aspnet_tutorial.Controllers
{
    public class ProductsController : Controller
    {
        // Initialize DbContexts
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET
        public ActionResult Index()
        {
            return View();
        }
    }
}
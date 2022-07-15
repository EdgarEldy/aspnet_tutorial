using System.Web.Mvc;
using aspnet_tutorial.Data;

namespace aspnet_tutorial.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET
        public ActionResult Index()
        {
            return View();
        }
    }
}
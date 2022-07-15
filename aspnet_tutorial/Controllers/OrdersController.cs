using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using aspnet_tutorial.Data;

namespace aspnet_tutorial.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Orders with Customers and Products
        public async Task<ActionResult> Index()
        {
            var orders = _context.Orders.Include(o => o.Customer).Include(o => o.Product);
            return View(await orders.ToListAsync());
        }
    }
}
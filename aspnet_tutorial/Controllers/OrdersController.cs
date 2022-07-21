using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using aspnet_tutorial.Models;
using ApplicationDbContext = aspnet_tutorial.Data.ApplicationDbContext;

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

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "CategoryName");
            ViewBag.CustomerId = new SelectList(_context.Customers, "Id", "FirstName");
            return View();
        }
    }
}
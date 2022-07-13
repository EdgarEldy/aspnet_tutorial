using System.Data.Entity;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Mvc;
using aspnet_tutorial.Models;
using ApplicationDbContext = aspnet_tutorial.Data.ApplicationDbContext;

namespace aspnet_tutorial.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Customers
        public async Task<ActionResult> Index()
        {
            var customers = await _context.Customers.ToListAsync();
            return View(customers);
        }

        //GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(Include = "FirstName, LastName, Tel, Email, Address")] Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
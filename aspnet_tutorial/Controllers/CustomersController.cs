using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using aspnet_tutorial.Data;

namespace aspnet_tutorial.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Customers
        public async  Task<ActionResult> Index()
        {
            var customers = await _context.Customers.ToListAsync();
            return View(customers);
        }
    }
}
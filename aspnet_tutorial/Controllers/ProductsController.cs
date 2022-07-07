using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using aspnet_tutorial.Data;

namespace aspnet_tutorial.Controllers
{
    public class ProductsController : Controller
    {
        // Initialize DbContexts
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET Products
        public async Task<ActionResult> Index()
        {
            var products = _context.Products.Include(p => p.Category);
            return View(await products.ToListAsync());
        }
        
        //GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "CategoryName");
            return View();
        }
    }
}
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using aspnet_tutorial.Data;

namespace aspnet_tutorial.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // GET
        public async Task<ActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }
        
        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}
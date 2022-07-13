using System.Data.Entity;
using System.Net;
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
        public async Task<ActionResult> Create([Bind(Include = "Id, FirstName, LastName, Tel, Email, Address")] Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Customers/Edit/Id
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName, LastName, Tel, Email, Address")] Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        // GET: Customers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}
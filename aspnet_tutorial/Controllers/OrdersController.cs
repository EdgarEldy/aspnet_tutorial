using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using aspnet_tutorial.Models;
using AspNetDbContext = aspnet_tutorial.Data.AspNetDbContext;

namespace aspnet_tutorial.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AspNetDbContext _context = new AspNetDbContext();

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

        // Get products by category id using ajax
        public async Task<JsonResult> GetProducts(int id)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            var products = await _context.Products.Where(x => x.CategoryId == id).ToListAsync();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        // Get unit price by product id
        public async Task<JsonResult> GetUnitPrice(int productId)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            var product = await _context.Products.Where(p => p.Id == productId).FirstOrDefaultAsync();
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        //POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CustomerId,ProductId,Qty,Total")] Order order)
        {
            if (!ModelState.IsValid) return View(order);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //GET: Orders/Edit/Id
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Join Order model with Customer and Product models
            var order = await _context.Orders.Include(c => c.Customer)
                .Include(p => p.Product)
                .Where(x => x.Id == id)
                .FirstAsync();
            if (order == null)
            {
                return HttpNotFound();
            }

            ViewBag.CustomerId = new SelectList(_context.Customers, "Id", "FirstName", order.CustomerId);
            ViewData["Categories"] = await _context.Categories.ToListAsync();
            ViewBag.ProductId = new SelectList(_context.Products, "Id", "ProductName", order.ProductId);
            return View(order);
        }

        //POST: Orders/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CustomerId,ProductId,Qty,Total")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(order).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(_context.Customers, "Id", "FirstName", order.CustomerId);
            ViewData["Categories"] = await _context.Categories.ToListAsync();
            ViewBag.ProductId = new SelectList(_context.Products, "Id", "ProductName", order.ProductId);
            return View(order);
        }

        //GET: Orders/Delete/Id
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        //POST: Orders/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null) _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
using System.Web.Mvc;

namespace aspnet_tutorial.Controllers
{
    public class ProductsController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }
    }
}
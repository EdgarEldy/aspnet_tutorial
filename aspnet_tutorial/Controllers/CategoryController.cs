using System.Web.Mvc;

namespace aspnet_tutorial.Controllers
{
    public class CategoryController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Controllers
{
    public class ActivitesController : Controller
    {
        // GET: ActivitesController
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Achats));
        }

        public ActionResult Achats()
        {
            return View();
        }

        public ActionResult Retraits()
        {
            return View();
        }
    }
}
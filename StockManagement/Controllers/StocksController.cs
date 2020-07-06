using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Controllers
{
    public class StocksController : Controller
    {
        // GET: StockController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StockController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
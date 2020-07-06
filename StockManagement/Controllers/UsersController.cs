using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Controllers
{
    public class UsersController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StockManagement.Controllers
{
    public class TypeProduitController : Controller
    {
        private readonly ILogger<TypeProduitController> _logger;

        public TypeProduitController(ILogger<TypeProduitController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
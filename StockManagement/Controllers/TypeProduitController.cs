using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockManagement.Models;

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

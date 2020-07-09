using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockManagement.Services;
using StockManagement.Services.Refit.Contracts.Requests;
using StockManagement.Services.Refit.Contracts.Responses;

namespace StockManagement.Controllers
{
    public class StocksController : Controller
    {
        private readonly ILogger<StocksController> _logger;
        private readonly IStockService _stockService;

        public StocksController(ILogger<StocksController> logger, IStockService stockService)
        {
            _logger = logger;
            _stockService = stockService;
        }        

        // GET: StockController
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        // GET: StockController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            try
            {
                var result = await _stockService.GetProduitById(id);
                return View(result);
            }
            catch (Exception e)
            {                
                _logger.LogError(e.Message);
                throw;
            }
        }

        [Route("paginated")]
        [HttpGet]
        public async Task<PaginatedResponse<Produit>> GetPaginatedProduits([FromQuery] PagingParams pagination)
        {
            try
            {
                var result = await _stockService.GetPaginatedProduit(pagination);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
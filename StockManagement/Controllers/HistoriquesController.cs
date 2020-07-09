using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockManagement.Services;
using StockManagement.Services.Refit.Contracts.Requests;
using StockManagement.Services.Refit.Contracts.Responses;

namespace StockManagement.Controllers
{
    public class HistoriquesController : Controller
    {
        private readonly ILogger<HistoriquesController> _logger;
        private readonly IHistoriqueService _historiqueService;

        public HistoriquesController(ILogger<HistoriquesController> logger, IHistoriqueService historiqueService){
            _logger = logger;
            _historiqueService = historiqueService;
        }

        // GET: HistoriqueController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HistoriqueController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            try
            {
                var result = await _historiqueService.GetHistoriqueById(id);
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
        public async Task<PaginatedResponse<Historique>> GetPaginatedHistoriques([FromQuery] PagingParams pagination)
        {
            try
            {
                var result = await _historiqueService.GetPaginatedHistorique(pagination);
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
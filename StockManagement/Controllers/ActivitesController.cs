using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockManagement.Services;
using StockManagement.Services.Refit.Contracts.Requests;
using StockManagement.Services.Refit.Contracts.Responses;

namespace StockManagement.Controllers
{
    public class ActivitesController : Controller
    {
        private readonly ILogger<ActivitesController> _logger;
        private readonly IActiviteService _activiteService;

        public ActivitesController(IActiviteService activiteService, ILogger<ActivitesController> logger)
        {
            _activiteService = activiteService;
            _logger = logger;
        }

        // GET: ActivitesController
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Achats));
        }

        public ActionResult Achats()
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


        [Route("paginated_achats")]
        [HttpGet]
        public async Task<PaginatedResponse<Achat>> GetPaginatedAchats([FromQuery] PagingParams pagination)
        {
            try
            {
                var result = await _activiteService.GetPaginatedAchats(pagination);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public ActionResult Retraits()
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

        [Route("paginated_retraits")]
        [HttpGet]
        public async Task<PaginatedResponse<Retrait>> GetPaginatedRetraits([FromQuery] PagingParams pagination)
        {
            try
            {
                var result = await _activiteService.GetPaginatedRetraits(pagination);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAchat([Bind()]CreateAchat payload){
            try
            {
                if(!ModelState.IsValid)
                    return NotFound();
                
                await _activiteService.StoreAchat(payload);
                return RedirectToAction(nameof(Achats));
                
            }
            catch (Exception e)
            {                
                _logger.LogError(e.Message);
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRetrait([Bind()]CreateRetrait payload){
            try
            {
                if(!ModelState.IsValid)
                    return NotFound();
                
                await _activiteService.StoreRetrait(payload);
                return RedirectToAction(nameof(Retraits));
                
            }
            catch (Exception e)
            {                
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<ActionResult> DetailsAchat(Guid id){
            try
            {
                var result = await _activiteService.GetAchatById(id);
                return View(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<ActionResult> DetailsRetrait(Guid id){
            try
            {
                var result = await _activiteService.GetRetraitById(id);
                return View(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

    }
}
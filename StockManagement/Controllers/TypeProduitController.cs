using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockManagement.Services;
using StockManagement.Services.Refit.Contracts.Requests;
using StockManagement.Services.Refit.Contracts.Responses;

namespace StockManagement.Controllers
{
    public class TypeProduitController : Controller
    {
        private readonly ILogger<TypeProduitController> _logger;
        private readonly ITypeProduitService _typeProduitService;

        public TypeProduitController(ILogger<TypeProduitController> logger, ITypeProduitService typeProduitService)
        {
            _logger = logger;
            _typeProduitService = typeProduitService;
        }

        public IActionResult Index()
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

        [Route("paginated")]
        [HttpGet]
        public async Task<PaginatedResponse<TypeProduit>> GetPaginatedTypesProduit([FromQuery] PagingParams pagination)
        {
            try
            {
                var result = await _typeProduitService.GetPaginatedTypesProduit(pagination);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult CreateTypeProduit(){
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

        [HttpPost]
        public ActionResult CreateTypeProduit([Bind("Id", "Label")] CreateTypeProduit payload){
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id", "Label")]UpdateTypeProduit payload)
        {
            if (id != payload.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            try
            {
                await _typeProduitService.UpdateTypeProduit(id, payload);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<IActionResult> Details(Guid id){
            try
            {
                var result = await _typeProduitService.GetTypeProduitById(id);
                return View(result);
            }
            catch (Exception e)
            {                
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<IActionResult> Delete(Guid id){
            try
            {
                await _typeProduitService.DeleteTypeProduit(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {                
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
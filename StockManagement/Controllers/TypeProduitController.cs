using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StockManagement.Exceptions;
using StockManagement.Models;
using StockManagement.Services;
using StockManagement.Services.Refit.Contracts.Requests;
using System;
using System.Threading.Tasks;

namespace StockManagement.Controllers
{
    [Authorize]
    public class TypeProduitController : Controller
    {
        private readonly ILogger<TypeProduitController> _logger;
        private readonly ITypeProduitService _typeProduitService;

        public TypeProduitController(ILogger<TypeProduitController> logger, ITypeProduitService typeProduitService)
        {
            _logger = logger;
            _typeProduitService = typeProduitService;
        }

        [Authorize]
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

        [Route("TypeProduit/paginated")]
        [HttpGet]
        [Authorize]
        public async Task<string> GetPaginatedTypesProduit([FromQuery] DataTableParams pagination)
        {
            try
            {
                pagination.start += 1;                                

                var result = await _typeProduitService.GetPaginatedTypesProduit(pagination);

                return JsonConvert.SerializeObject(new
                {
                    pagination.draw,
                    recordsTotal = result.Paging.TotalItems,
                    data = result.Data,
                    recordsFiltered = result.Paging.TotalItems
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateTypeProduit()
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

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTypeProduit(CreateTypeProduit payload)
        {
            try
            {
                await _typeProduitService.CreateTypeProduit(payload);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        [Authorize]
        public async Task<ActionResult> UpdateTypeProduit(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return NotFound();

                var typeProduit = await _typeProduitService.GetTypeProduitById(id);

                if (typeProduit == null)
                    return NotFound();

                return View(typeProduit);
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e.Message);
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> UpdateTypeProduit(Guid id, UpdateTypeProduit payload)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(UpdateTypeProduit));

            try
            {
                await _typeProduitService.UpdateTypeProduit(id, payload);

                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e.Message);
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        [Authorize]
        public async Task<IActionResult> DetailsTypeProduit(Guid id)
        {
            try
            {
                var result = await _typeProduitService.GetTypeProduitById(id);

                return View(result);
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e.Message);
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _typeProduitService.DeleteTypeProduit(id);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e.Message);
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
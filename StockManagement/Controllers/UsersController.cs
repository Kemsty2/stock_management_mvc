using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockManagement.Services;
using StockManagement.Services.Refit.Contracts.Requests;
using StockManagement.Services.Refit.Contracts.Responses;

namespace StockManagement.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // GET
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
        public async Task<PaginatedResponse<User>> GetPaginatedUsers([FromQuery] PagingParams pagination)
        {
            try
            {
                var result = await _userService.GetPaginatedUsers(pagination);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public ActionResult CreateUser(){
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
        public async Task<IActionResult> CreateUser([Bind("Id", "Label")]CreateUser payload)
        {            
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            try
            {
                await _userService.CreateUser(payload);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public ActionResult EditUser(Guid id){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(Guid id, [Bind("Id", "Label")]UpdateUser payload)
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
                await _userService.UpdateUser(id, payload);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<ActionResult> DetailsUser(Guid id){
            try
            {
                var result = await _userService.GetUserById(id);
                return View(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<ActionResult> ToggleStatus(Guid id){
            try
            {
                await _userService.ToggleStatusUser(id);
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
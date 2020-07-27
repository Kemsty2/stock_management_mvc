using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using StockManagement.Models;
using StockManagement.Services;
using StockManagement.Services.Refit.Contracts.Requests;
using System;
using System.Threading.Tasks;

namespace StockManagement.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        public ILogger<UsersController> Logger;
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
            Logger = NullLogger<UsersController>.Instance;
        }

        // GET
        [Authorize(Roles = "Administrateur")]
        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                throw;
            }
        }

        [Route("Users/paginated")]
        [HttpPost]
        [Authorize(Roles = "Administrateur")]
        public async Task<string> GetPaginatedUsers([FromQuery] DataTableParams pagination)
        {
            try
            {
                pagination.start += 1;

                var result = await _userService.GetPaginatedUsers(pagination);

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
                Logger.LogError(e.Message);
                throw;
            }
        }

        public ActionResult CreateUser()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrateur")]
        public async Task<IActionResult> CreateUser(CreateUser payload)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _userService.CreateUser(payload);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                throw;
            }
        }

        [Authorize(Roles = "Administrateur")]
        public ActionResult EditUser(Guid id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrateur")]
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
                Logger.LogError(e.Message);
                throw;
            }
        }

        [Authorize(Roles = "Administrateur")]
        public async Task<ActionResult> DetailsUser(Guid id)
        {
            try
            {
                var result = await _userService.GetUserById(id);
                return View(result);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                throw;
            }
        }

        [Authorize(Roles = "Administrateur")]
        public async Task<ActionResult> ToggleStatus(Guid id)
        {
            try
            {
                await _userService.ToggleStatusUser(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                throw;
            }
        }
    }
}
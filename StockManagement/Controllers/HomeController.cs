using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockManagement.Models;
using StockManagement.Services;
using StockManagement.Services.Refit.Contracts.Requests;

namespace StockManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }        

        [Route("500")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("404")]
        public IActionResult NotFoundPage(){
            return View();
        }

        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUser payload){
            if(!ModelState.IsValid){
                return View();
            }
            try
            {
                var result = await _userService.AuthenticateUser(payload);

                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, result.UserInfo.Username)                   
                };
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {                
                return View();
            }
        }   
    }
}

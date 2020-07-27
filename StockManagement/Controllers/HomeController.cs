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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using StockManagement.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging.Abstractions;
using StockManagement.Services.Refit.Contracts.Requests;

namespace StockManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ILogger<HomeController> Logger;
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            Logger = NullLogger<HomeController>.Instance;
            _userService = userService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Route("500")]
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() 
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("404")]
        [AllowAnonymous]
        public IActionResult NotFoundPage()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto payload)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var result = await _userService.AuthenticateUser(new LoginUser()
                {
                    Email = payload.Email,
                    Password = payload.Password
                });

                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, result.Name),
                    new Claim("Token", result.Token)
                };

                claims.AddRange(result.Roles.Select(role => new Claim(ClaimTypes.Role, role.Label)));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties { IsPersistent = payload.RememberMe }
                );

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return View();
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                return RedirectToAction(nameof(Login));
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                throw;
            }
        }
    }
}

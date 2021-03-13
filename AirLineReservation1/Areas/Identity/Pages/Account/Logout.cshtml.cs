using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLineReservation1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AirLineReservation1.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        //private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly IAuthenticationServicee _authenticationService;

        public LogoutModel(IAuthenticationServicee authenticationService, ILogger<LogoutModel> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            //await _signInManager.SignOutAsync();
            await _authenticationService.Logout();
            _logger.LogInformation("User logged out.");

            if (returnUrl != null)
            {
                //TempData["LoginMsg"] = "Logged in successfully";
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}

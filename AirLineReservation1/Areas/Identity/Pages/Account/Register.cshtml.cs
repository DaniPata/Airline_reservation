using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AirLineReservation1.Models;
using AirLineReservation1.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;





namespace AirLineReservation1.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
       
        //private readonly IWebHostEnvironment _hostingEnvironment;


        private readonly IAuthenticationServicee _authenticationService;

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger, IAuthenticationServicee authenticationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _authenticationService = authenticationService;
          
            //_emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Username is required")]
            [DataType(DataType.Text)]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Birth Date")]
            public DateTime Birthday { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Gender")]
            public string Gender { get; set; }
        

            [Phone]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            //[Display(Name = "UserImage")]
            //public byte[] UserImage { get; set; }



        }



        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null /*HttpPostedFileBase ImageFile*/)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();


            //using (var ms = new MemoryStream())
            //{
            //    ImageFile.InputStream.CopyTo(ms);
            //    Input.UserImage = ms.ToArray();
            //}
            if (ModelState.IsValid)
            {

                //var user = new IdentityUser { UserName = Input.Username, Email = Input.Email, PhoneNumber = Input.PhoneNumber };
                //var result = await _userManager.CreateAsync(user, Input.Password);

                //string uniqueFileName = null;
                //if (Input.Photo != null)
                //{
                //  string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                //    uniqueFileName = Guid.NewGuid().ToString() + "_" + Input.Photo.FileName;
                //   string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //    Input.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                //}



                var user = _authenticationService.CreateUser(Input.Username, Input.Email, Input.PhoneNumber, Input.FirstName, Input.LastName, Input.Birthday,Input.Gender /*Input.Photo*/);
                var result = await _authenticationService.Register(user, Input.Password);
                //var user1Id = user.Id;


                

                if (result.Succeeded)
                {



                    _userManager.AddToRoleAsync(user, "User").Wait();
                    _logger.LogInformation("User created a new account with password.");
                    TempData["Success"] = "User " + Input.Username + " was registered successfully!";

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
           

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}

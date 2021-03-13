using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AirLineReservation1.Models;
using AirLineReservation1.Services;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using AirLineReservation1.Database;
using Microsoft.AspNetCore.Mvc.Filters;
using AirLineReservation1.DTO.Request;
using AirLineReservation1.ExtensionMethods;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;
namespace AirLineReservation1.Controllers
{
   

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private IContactService _contactService;


        public HomeController(ILogger<HomeController> logger,
            IUserService userService, IContactService contactService)
        {
            _logger = logger;
            _userService = userService;
            _contactService = contactService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            IEnumerable<User> users = _userService.GetAllUsers();

            return Ok(users);
        }




        [HttpPost]
        public async Task<IActionResult> SendContactMessage([FromBody] ContactRequest request)
        {
            //var dani = 1;
            Contact contact = request.ToContact();
             await _contactService.CreateContact(contact);

            return Ok();
        }

        [HttpGet("createUser")]
        public async Task<IActionResult> CreateUser([FromBody] User request)
        {
            _userService.CreateUser(request);

            return Ok();
        }

        [HttpGet("user/{userID}")]
        public async Task<IActionResult> GetUser(string userID)
        {
            User user = new User();
            user= _userService.GetUser(userID);

            return View(user);
        }

       

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult About()
        {
            return View();
        }

        public IActionResult TermsOfUse()
        {
            return View();
        }


        //[Authorize(Roles = "User")]
        //public IActionResult Flights()
        //{
        //    return View();
        //}
     
        [Authorize]
        public IActionResult PrivacyPolicy()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

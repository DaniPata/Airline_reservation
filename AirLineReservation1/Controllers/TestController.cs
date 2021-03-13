using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AirLineReservation1.Services;

namespace AirLineReservation1.Controllers
{
    public class TestController : Controller
    {
        private readonly IContactService _contactService;

        public TestController(IContactService contactService)
        {

            _contactService = contactService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AirLineReservation1.DTO.Request;
//using AirLineReservation1.ExtensionMethods;
//using AirLineReservation1.Models;
//using AirLineReservation1.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace AirLineReservation1.Controllers
//{
//    public class DefaultController : Controller
//    {
//        private  IContactService _contactService;
//        public DefaultController(IContactService contactService)
//        {
//            _contactService = contactService;
//        }
//        [HttpPost]
//        public async Task<IActionResult> SendContactMessage(ContactRequest request)
//        {
//            Contact contact = request.ToContact();
//            _contactService.CreateContact(contact);

//            return Ok();
//        }
//    }
//}

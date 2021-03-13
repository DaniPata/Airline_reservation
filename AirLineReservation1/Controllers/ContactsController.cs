using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirLineReservation1.Database;
using AirLineReservation1.Models;
using AirLineReservation1.Services;
using AirLineReservation1.DTO.Request;
using AirLineReservation1.ExtensionMethods;

namespace AirLineReservation1.Controllers
{
    public class ContactsController : Controller
    {
        private IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }


        public IActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactId,Subject,Message,UserId")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _contactService.CreateContact(contact);
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

    }
}

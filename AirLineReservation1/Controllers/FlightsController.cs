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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AirLineReservation1.Models.FlightModel;

namespace AirLineReservation1.Controllers

{

    public class FlightsController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IContactService _contactService;
        private readonly UserManager<User> _userManager;
        public FlightsController(IFlightService flightService, UserManager<User> userManager)
        {

            _flightService = flightService;
            _userManager = userManager;

        }

        public IActionResult Flights()
        {
            return View();
        }

        // GET: Flight
        public async Task<IActionResult> Index()
        {
            var flight = _flightService.GetAllFlights();
            return View(flight);
        }
        // GET: Flight/Details/5


        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _flightService.GetFlightById(id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        public ActionResult Search(string departure, string arrival, DateTime arrivalTime)
        {
            if (departure == null || arrival == null || arrivalTime == null)
            {
                var flights = _flightService.GetFlight();
                return View(new FlightViewModel { Flights = flights });
            }
            try
            {
                var flights = _flightService.GetFlightAccordingToFilters(departure, arrival, arrivalTime);

                return View(new FlightViewModel { Flights = flights });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }

        public IActionResult BookSeat(Guid id)
        {
            var buyVm = new BuyTicketViewModel()
            {
                FlightId = id,
                SeatNumber = -1
            };

            return View(buyVm);
        }

        [HttpPost]
        public IActionResult BookSeat([FromForm] BuyTicketViewModel Vm)
        {
            var userId = _userManager.GetUserId(User);
            // var personalTrip = historyTripsService.GetPersonalTripByUserId(userId);
          
            return RedirectToAction("BookSeat", "Flights");
        }




        //public async Task<IActionResult> GetFlight(string departure)
        //{
        //    Flight flight = new Flight();
        //    flight =  _flightService.GetFlight(departure);

        //    return View(flight);
        //}
        public async Task<IActionResult> GetAllFlights()
        {
            var flight = _flightService.GetAllFlights();
            return View(flight);
        }


        // GET: Flights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightId,Name,Aircraft,Date,Departure,DepartureTime,Arrival,ArrivalTime,Class,Capacity,Price,RemainSeats")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                await _flightService.CreateFlight(flight);
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _flightService.GetFlightById(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightId,Name,Aircraft,Date,Departure,DepartureTime,Arrival,ArrivalTime,Class,Capacity,Price,RemainSeats")] Flight flight)
        {
            if (id != flight.FlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _flightService.UpdateFlight(id, flight);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_flightService.FlightExists(flight.FlightId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Delete/5

        public async Task<IActionResult> Delete(int id)
        {
            Flight flight = await _flightService.GetFlightById(id);
            return View(flight);
        }

        // POST: Flight/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _flightService.DeleteFlight(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
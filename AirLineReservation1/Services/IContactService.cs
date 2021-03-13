using AirLineReservation1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Services
{
     public interface IContactService
    {
        public IEnumerable<Contact> GetAllContacts();
        public Task<Contact> GetContactById(int id);
        public Task<bool> UpdateContact(int id, Contact contact);
        public Task<bool> CreateContact(Contact contact);
        public Task<bool> DeleteContact(int id);
        public bool ContactExists(int id);
        //public Flight GetFlight(string departure);
    }
}

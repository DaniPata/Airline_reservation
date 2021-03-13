using AirLineReservation1.Models;
using AirLineReservation1.Repository;
using AirLineReservation1.RepositoryWrapperr;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Services
{
    public class ContactService: IContactService

    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<bool> CreateContact(Contact contact)
        {
            try
            {
                _contactRepository.Create(contact);
                await _contactRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        //public Flight GetFlight(string departure)
        //{
        //    IQueryable<Flight> flights = _contactRepository.FindByCondition(x => x.Departure == departure);
        //    Flight flight = new Flight();
        //    flight = flights.First();

        //    return flight;
        //}

        public async Task<bool> DeleteContact(int id)
        {
            try
            {
                var contact = await GetContactById(id);
                _contactRepository.Delete(contact);
                await _contactRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            IEnumerable<Contact> contacts = _contactRepository.FindAll();

            return contacts;
        }

        public Task<Contact> GetContactById(int id)
        {
            try
            {
                return _contactRepository.FindByCondition(contact => contact.ContactId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> UpdateContact(int id, Contact contact)
        {
            try
            {
                await GetContactById(id);
                _contactRepository.Update(contact);
                await _contactRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool ContactExists(int id)
        {
            return _contactRepository.FindByCondition(e => e.ContactId == id).Any();
        }


    }
}

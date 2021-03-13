using AirLineReservation1.DTO.Request;
using AirLineReservation1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.ExtensionMethods
{
    static public class ContactExtensionMethod
    {
        static public Contact ToContact(this ContactRequest contactRequest)
        {
            Contact contact = new Contact();

            contact.Subject = contactRequest.Subject;
            contact.Message = contactRequest.Message;
            contact.UserId = contactRequest.UserId;

            return contact;
        }
    }
}

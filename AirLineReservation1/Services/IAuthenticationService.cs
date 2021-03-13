using AirLineReservation1.Areas.Identity.Pages.Account;
using AirLineReservation1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Services
{
    public interface IAuthenticationServicee
    {
        public User CreateUser( string username, string email,string phonenumber, string firstname, string lastname, DateTime birthday, string gender /*IFormFile photo*/);
        public  Task<SignInResult> Login(string username, string password, bool rememberMe, bool lockoutOnFailure);
        public  Task<IdentityResult> Register(User user, string password);
        public  Task Logout();


    }
}

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
    public class AuthenticationServicee: IAuthenticationServicee

    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthenticationServicee(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public User CreateUser(string username,string email, string phonenumber, string firstname, string lastname, DateTime birthday, string gender)
        {
            return new User { UserName = username, Email = email, PhoneNumber = phonenumber, FirstName = firstname, LastName = lastname, Birthday=birthday, Gender=gender};
        }
        public async Task<IdentityResult> Register(User user,string password)
        {
            return  await _userManager.CreateAsync(user,password);
        }
       
        public async Task<SignInResult> Login(string username, string password, bool rememberMe, bool lockoutOnFailure)
        {
            return await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: false);
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

    }
}

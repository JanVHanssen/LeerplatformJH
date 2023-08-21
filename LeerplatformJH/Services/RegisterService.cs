using LeerplatformJH.Data;
using System;
using LeerplatformJH.Services.Interfaces;
using LeerplatformJH.Models;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace LeerplatformJH.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public string getNummer(string uNummer)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegisterUserAsync(string username, string email, string password)
        {
            var user = new IdentityUser
            {
                UserName = username,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);
            return result;
        }
    }
}







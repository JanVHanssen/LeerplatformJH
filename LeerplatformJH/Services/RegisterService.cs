using LeerplatformJH.Data;
using System;
using LeerplatformJH.Services.Interfaces;
using LeerplatformJH.Models;

namespace LeerplatformJH.Services
{
    public class RegisterService : IRegisterService
    {
        private ApplicationDbContext _context;
        public RegisterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string getNummer(string uNummer)
        {
            var nummer = from n in _context.gebruikers
                         where n.UNummer == uNummer
                         select n.ToString();
            return nummer.FirstOrDefault();
        }
    }
}

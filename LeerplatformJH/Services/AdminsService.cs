using LeerplatformJH.Data;
using LeerplatformJH.Models;
using LeerplatformJH.Services;
using LeerplatformJH.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeerPlatformJH.Services
{
    public class AdminsService : IAdminsService
    {

        private readonly ApplicationDbContext _context;

        public AdminsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Administrator CreateAdministrator(Administrator administrator)
        {
            _context.Add(administrator);
            _context.SaveChanges();
            return administrator;
        }

        public void DeleteAdministrator(Administrator administrator)
        {
            _context.Remove(administrator);
            _context.SaveChanges();
        }

        public Administrator EditAdministrator(Administrator administrator)
        {
            _context.Update(administrator);
            _context.SaveChanges();
            return administrator;
        }

        public IEnumerable<Administrator> GetAllAdmins()
        {
            var all = from a in _context.Administratoren
                      select a;
            return all;
        }

        public Administrator GetAdministrator(int? id)
        {
            var administrator = from a in _context.Administratoren
                          where a.AdministratorId.Equals(id)
                          select a;
            return administrator.FirstOrDefault();
        }
    }
}
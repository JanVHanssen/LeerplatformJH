using LeerplatformJH.Data;
using LeerplatformJH.Models;
using LeerplatformJH.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeerplatformJH.Services
{
    public class LesService : ILesService
    {
        private readonly ApplicationDbContext _context;

        public LesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Les CreateLes(Les les)
        {
            _context.Add(les);
            _context.SaveChanges();
            return les;
        }

        public void DeleteLes(Les les)
        {
            _context.Remove(les);
            _context.SaveChanges();
        }

        public Les EditLes(Les les)
        {
            _context.Update(les);
            _context.SaveChanges();
            return les;
        }

        public IEnumerable<Les> GetAllLes()
        {
            var all = _context.Lessen.Include(l => l.Lokaal)
                                     .Include(l => l.Docent); 
            return all;
        }

        public Les GetLes(int? id)
        {
            var les = from a in _context.Lessen
                                where a.LesId.Equals(id)
                                select a;
            return les.FirstOrDefault();
        }
    }
}


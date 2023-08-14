using LeerplatformJH.Data;
using LeerplatformJH.Models;
using LeerplatformJH.Services.Interfaces;

namespace LeerplatformJH.Services
{
    public class LokaalService : ILokaalService
    {
        private readonly ApplicationDbContext _context;

        public LokaalService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Lokaal CreateLokaal(Lokaal lokaal)
        {
            _context.Add(lokaal);
            _context.SaveChanges();
            return lokaal;
        }

        public void DeleteLokaal(Lokaal lokaal)
        {
            _context.Remove(lokaal);
            _context.SaveChanges();
        }

        public Lokaal EditLokaal(Lokaal lokaal)
        {
            _context.Update(lokaal);
            _context.SaveChanges();
            return lokaal;
        }

        public IEnumerable<Lokaal> GetAllLokalen()
        {
            var all = from a in _context.Lokalen
                      select a;
            return all;
        }

        public Lokaal GetLokaal(int? id)
        {
            var lokaal = from a in _context.Lokalen
                                where a.LokaalId.Equals(id)
                                select a;
            return lokaal.FirstOrDefault();
        }
    }
}


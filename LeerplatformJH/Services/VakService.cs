using LeerplatformJH.Data;
using LeerplatformJH.Models;
using LeerplatformJH.Services.Interfaces;

namespace LeerplatformJH.Services
{
    public class VakService : IVakService
    {
        private readonly ApplicationDbContext _context;

        public VakService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Vak CreateVak(Vak vak)
        {
            _context.Add(vak);
            _context.SaveChanges();
            return vak;
        }

        public void DeleteVak(Vak vak)
        {
            _context.Remove(vak);
            _context.SaveChanges();
        }

        public Vak EditVak(Vak vak)
        {
            _context.Update(vak);
            _context.SaveChanges();
            return vak;
        }

        public IEnumerable<Vak> GetAllVakken()
        {
            var all = from a in _context.Vakken
                      select a;
            return all;
        }

        public Vak GetVak(int? id)
        {
            var vak = from a in _context.Vakken
                                where a.VakId.Equals(id)
                                select a;
            return vak.FirstOrDefault();
        }
    }
}


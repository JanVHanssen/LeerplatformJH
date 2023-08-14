using LeerplatformJH.Data;
using LeerplatformJH.Models;
using LeerplatformJH.Services.Interfaces;

namespace LeerplatformJH.Services

{
    public class VakInschrijvingService : IVakInschrijvingService
    {
        private readonly ApplicationDbContext _context;

        public VakInschrijvingService(ApplicationDbContext context)
        {
            _context = context;
        }
        public VakInschrijving CreateVakInschrijving(VakInschrijving vakInschrijving)
        {
            _context.Add(vakInschrijving);
            _context.SaveChanges();
            return vakInschrijving;
        }

        public void DeleteVakInschrijving(VakInschrijving vakInschrijving)
        {
            _context.Remove(vakInschrijving);
            _context.SaveChanges();
        }

        public VakInschrijving EditVakInschrijving(VakInschrijving vakInschrijving)
        {
            _context.Update(vakInschrijving);
            _context.SaveChanges();
            return vakInschrijving;
        }

        public IEnumerable<VakInschrijving> GetAllVakInschrijvingen()
        {
            var all = from a in _context.VakInschrijvingen
                      select a;
            return all;
        }

        public VakInschrijving GetVakInschrijving(int? id)
        {
            var vakInschrijving = from a in _context.VakInschrijvingen
                                where a.VakInschrijvingId.Equals(id)
                                select a;
            return vakInschrijving.FirstOrDefault();
        }
    }
}


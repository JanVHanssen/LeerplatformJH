using LeerplatformJH.Data;
using LeerplatformJH.Models;
using LeerplatformJH.Services.Interfaces;

namespace LeerplatformJH.Services
{
    public class DocentService : IDocentService
    {
        private readonly ApplicationDbContext _context;

        public DocentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Docent CreateDocent(Docent docent)
        {
            _context.Add(docent);
            _context.SaveChanges();
            return docent;
        }

        public void DeleteDocent(Docent docent)
        {
            _context.Remove(docent);
            _context.SaveChanges();
        }

        public Docent EditDocent(Docent docent)
        {
            _context.Update(docent);
            _context.SaveChanges();
            return docent;
        }

        public IEnumerable<Docent> GetAllDocenten()
        {
            var all = from a in _context.Docenten
                      select a;
            return all;
        }

        public Docent GetDocent(int? id)
        {
            var docent = from a in _context.Docenten
                                where a.DocentId.Equals(id)
                                select a;
            return docent.FirstOrDefault();
        }
    }
}


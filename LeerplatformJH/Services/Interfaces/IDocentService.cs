using LeerplatformJH.Models;

namespace LeerplatformJH.Services.Interfaces
{
    public interface IDocentService
    {
        IEnumerable<Docent> GetAllDocenten();
        Docent GetDocent(int? id);
        Docent CreateDocent(Docent docent);
        Docent EditDocent(Docent docent);
        void DeleteDocent(Docent docent);
    }
}

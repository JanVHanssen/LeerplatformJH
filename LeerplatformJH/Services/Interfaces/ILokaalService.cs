using LeerplatformJH.Models;

namespace LeerplatformJH.Services.Interfaces
{
    public interface ILokaalService
    {
        IEnumerable<Lokaal> GetAllLokalen();
        Lokaal GetLokaal(int? id);
        Lokaal CreateLokaal(Lokaal lokaal);
        Lokaal EditLokaal(Lokaal lokaal);
        void DeleteLokaal(Lokaal lokaal);
    }
}

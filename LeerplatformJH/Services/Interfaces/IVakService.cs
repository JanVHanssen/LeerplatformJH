using LeerplatformJH.Models;

namespace LeerplatformJH.Services.Interfaces
{
    public interface IVakService
    {
        IEnumerable<Vak> GetAllVakken();
        Vak GetVak(int? id);
        Vak CreateVak(Vak vak);
        Vak EditVak(Vak vak);
        void DeleteVak(Vak vak);
    }
}

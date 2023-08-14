using LeerplatformJH.Models;

namespace LeerplatformJH.Services.Interfaces
{
    public interface IVakInschrijvingService
    {
        IEnumerable<VakInschrijving> GetAllVakInschrijvingen();
        VakInschrijving GetVakInschrijving(int? id);
        VakInschrijving CreateVakInschrijving(VakInschrijving vakInschrijving);
        VakInschrijving EditVakInschrijving(VakInschrijving vakInschrijving);
        void DeleteVakInschrijving(VakInschrijving vakInschrijving);
    }
}

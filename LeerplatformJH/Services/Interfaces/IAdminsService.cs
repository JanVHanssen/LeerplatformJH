using LeerplatformJH.Models;
using System.Linq;

namespace LeerplatformJH.Services.Interfaces
{
    public interface IAdminsService
    {
        IEnumerable<Administrator> GetAllAdmins();
        Administrator GetAdministrator(int? id);
        Administrator CreateAdministrator(Administrator administrator);
        Administrator EditAdministrator(Administrator administrator);
        void DeleteAdministrator(Administrator administrator);
    }
}

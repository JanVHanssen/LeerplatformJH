using LeerplatformJH.Models;

namespace LeerplatformJH.Services.Interfaces
{
    public interface ILesService
    {
        IEnumerable<Les> GetAllLes();
        Les GetLes(int? id);
        Les CreateLes(Les les);
        Les EditLes(Les les);
        void DeleteLes(Les les);
    }
}

using LeerplatformJH.Models;

namespace LeerplatformJH.Services.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudenten();
        Student GetStudent(int? id);
        Student CreateStudent(Student student);
        Student EditStudent(Student student);
        void DeleteStudent(Student student);
    }
}

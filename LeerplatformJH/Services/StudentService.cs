using LeerplatformJH.Data;
using LeerplatformJH.Models;
using LeerplatformJH.Services.Interfaces;

namespace LeerplatformJH.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Student CreateStudent(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
            return student;
        }

        public void DeleteStudent(Student student)
        {
            _context.Remove(student);
            _context.SaveChanges();
        }

        public Student EditStudent(Student student)
        {
            _context.Update(student);
            _context.SaveChanges();
            return student;
        }

        public IEnumerable<Student> GetAllStudenten()
        {
            var all = from a in _context.Studenten
                      select a;
            return all;
        }

        public Student GetStudent(int? id)
        {
            var student = from a in _context.Studenten
                                where a.StudentId.Equals(id)
                                select a;
            return student.FirstOrDefault();
        }
    }
}


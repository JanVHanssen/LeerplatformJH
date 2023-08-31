using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LeerplatformJH.Models.ViewModels;
using LeerplatformJH.Models;
using System.Linq;
using System.Security.Claims;
using LeerplatformJH.Data;
using Microsoft.EntityFrameworkCore;

namespace LeerplatformJH.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentLessenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentLessenController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            string userEmail = User.Identity.Name;


            Student student = _context.Studenten
                .Include(s => s.Lessen)
                .ThenInclude(les => les.Lokaal)
                .FirstOrDefault(s => s.Email == userEmail);

            if (student == null)
            {
                return NotFound();
            }
            var viewModel = new StudentLessen
            {
                Id = student.StudentId,
                Student = student,
                Lessen = student.Lessen 
            };

            return View(viewModel);
        }
    }
}
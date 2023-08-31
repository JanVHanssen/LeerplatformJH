using LeerplatformJH.Data;
using LeerplatformJH.Models.ViewModels;
using LeerplatformJH.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace LeerplatformJH.Controllers
{
    public class StudentInschrijvingenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentInschrijvingenController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Student")]
        public IActionResult Index()
        {

            string loggedInUserEmail = User.Identity.Name;

            var student = _context.Studenten.SingleOrDefault(s => s.Email == loggedInUserEmail);

            if (student == null)
            {
                return NotFound();
            }

            var vakInschrijvingen = _context.VakInschrijvingen
                .Include(vi => vi.Vak)
                .Where(vi => vi.StudentId == student.StudentId)
                .ToList();

            var viewModel = new StudentInschrijvingen
            {
                Student = student,
                VakInschrijvingen = vakInschrijvingen
            };

            return View(viewModel);

        }
    }
    }


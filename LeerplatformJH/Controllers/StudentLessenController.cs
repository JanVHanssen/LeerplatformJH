using Microsoft.AspNetCore.Mvc;
using LeerplatformJH.Models.ViewModels;
using LeerplatformJH.Models;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Drawing.Printing;
using LeerplatformJH.Data;
using System.Numerics;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System.Runtime.Intrinsics.X86;

namespace LeerplatformJH.Controllers
{
    public class StudentLessenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentLessenController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            string loggedInUserEmail = User.Identity.Name;

            var student = await _context.Studenten.SingleOrDefaultAsync(s => s.Email == loggedInUserEmail);

            if (student == null)
            {
                return NotFound(); 
            }

            var studentLessen = await _context.Lessen
                .Where(lessen => lessen.StudentId == student.StudentId)
                .ToListAsync();

            var studentLessenVM = new StudentLessen
            {
                Id = student.StudentId,
                Student = student,
                Lessen = studentLessen
            };

            return View(studentLessenVM);
        }
    }
}

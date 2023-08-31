using LeerplatformJH.Data;
using LeerplatformJH.Models;
using Microsoft.AspNetCore.Mvc;
using LeerplatformJH.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace LeerplatformJH.Controllers
{
    public class StudentNieuweInschrijvingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentNieuweInschrijvingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Student")]
        public IActionResult Create()
        {

            string loggedInUserEmail = User.Identity.Name;
            var student = _context.Studenten.SingleOrDefault(s => s.Email == loggedInUserEmail);

            if (student == null)
            {
                return NotFound(); 
            }

            var viewModel = new StudentNieuweInschrijving
            {
                Id = student.StudentId,
                Vakken = _context.Vakken.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Student")]
        public IActionResult Create(StudentNieuweInschrijving viewModel)
        {
            if (ModelState.IsValid)
            {

                var newVakInschrijving = new VakInschrijving
                {
                    StudentId = viewModel.Id,
                    VakId = viewModel.SelectedVakId,
                    Titel = viewModel.Titel,

                };

                _context.VakInschrijvingen.Add(newVakInschrijving);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home"); 
            }

            viewModel.Vakken = _context.Vakken.ToList();
            return View(viewModel);
        }
    }
}


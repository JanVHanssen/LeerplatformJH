using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeerplatformJH.Data;
using LeerplatformJH.Models;
using LeerplatformJH.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LeerplatformJH.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentService _studentService;


        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult LoadAllStudenten()
        {
            try
            {
                var studentData = (from v in _studentService.GetAllStudenten()
                                  select v).ToList<Student>();
                //Returning Json Data 
                return Json(new { data = studentData });
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: Students
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            return View(_studentService.GetAllStudenten());

        }

        // GET: Students/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _studentService.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("StudId,Achternaam,Voornaam,Email,Inschrijvingsdatum")] Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.CreateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _studentService.GetStudent(id) == null)
            {
                return NotFound();
            }

            var student = _studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,Achternaam,Voornaam,Email,Inschrijvingsdatum")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _studentService.EditStudent(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _studentService.GetStudent(id) == null)
            {
                return NotFound();
            }

            var student = _studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_studentService.GetStudent(id) == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Student'  is null.");
            }
            var student = _studentService.GetStudent(id);
            if (student != null)
            {
                _studentService.DeleteStudent(student);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            if (_studentService.GetStudent(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}

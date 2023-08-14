using LeerplatformJH.Data;
using LeerplatformJH.Models.ViewModels;
using LeerplatformJH.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeerplatformJH.Controllers
{
    public class StudentInschrijvingenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentInschrijvingenController(ApplicationDbContext context)
        {
            _context = context;
        }
      
         /*   public IActionResult Index()
            {
                IEnumerable<StudentInschrijvingen> model = from v in _context.VakInschrijvingen
                                                           join a in _context.Vakken
                                                           on v.VakId equals a.VakId
                                                           where v.Student.Email == User.Identity.Name

                                                           select new StudentInschrijvingen()
                                                           {
                                                               Vak = a.Titel,
                                                               Studiepunten = a.Studiepunten,
                                                               Goedkeuring = (Goedkeuring)v.Goedkeuring
                                                           };
                return View(model);
            }
            // GET: StudentInschrijvingen/Create
            public IActionResult Create()
            {
                ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "Achternaam");
                ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "Titel");
                return View();
            }

            // POST: StudentInschrijvingen/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("VakInschrijvingId,StudentId,VakId,Goedkeuring")] VakInschrijving vakInschrijving)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(vakInschrijving);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["StudentId"] = new SelectList(_context.Studenten, "StudentId", "Achternaam", vakInschrijving.StudentId);
                ViewData["VakId"] = new SelectList(_context.Vakken, "VakId", "Titel", vakInschrijving.VakId);
                return View(vakInschrijving);
            }*/
        }
    }


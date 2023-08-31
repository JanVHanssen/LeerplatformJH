using LeerplatformJH.Data;
using LeerplatformJH.Models;
using LeerplatformJH.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class StudentUitschrijvingController : Controller
{
    private readonly ApplicationDbContext _context;

    public StudentUitschrijvingController(ApplicationDbContext context)
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

        var viewModel = new StudentUitschrijving
        {
            Id = student.StudentId,
            Student = student,
            Vakken = _context.VakInschrijvingen
            .Where(vi => vi.StudentId == student.StudentId)
            .Select(vi => vi.Vak)
            .ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Student")]
    public IActionResult Index(StudentUitschrijving viewModel)
    {
        if (ModelState.IsValid)
        {

            var vakInschrijvingToDelete = _context.VakInschrijvingen
                .SingleOrDefault(vi => vi.StudentId == viewModel.Id && vi.VakId == viewModel.SelectedVakId);

            if (vakInschrijvingToDelete != null)
            {
                _context.VakInschrijvingen.Remove(vakInschrijvingToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        viewModel.Vakken = _context.Vakken.ToList();
        return View("Index", viewModel);
    }
}

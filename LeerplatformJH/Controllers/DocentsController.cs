using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeerplatformJH.Data;
using LeerplatformJH.Models;
using Humanizer;
using System.Linq.Expressions;
using LeerplatformJH.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace LeerplatformJH.Controllers
{
    public class DocentsController : Controller
    {
        private IDocentService _docentService;


        public DocentsController(IDocentService docentService)
        {
            _docentService = docentService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult LoadAllDocenten()
        {
            try
            {
                var docentData = _docentService.GetAllDocenten().ToList();
                return Json(new { data = docentData });
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: Docents
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            return View(_docentService.GetAllDocenten());

        }

        // GET: Docents/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docent = _docentService.GetDocent(id);

            if (docent == null)
            {
                return NotFound();
            }

            return View(docent);
        }

        // GET: Docents/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Docents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("DocentId,Achternaam,Voornaam,Email,Indiensttreding")] Docent docent)
        {
            if (ModelState.IsValid)
            {
                _docentService.CreateDocent(docent);
                return RedirectToAction(nameof(Index));
            }
            return View(docent);
        }

        // GET: Docents/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _docentService.GetDocent(id) == null)
            {
                return NotFound();
            }

            var docent = _docentService.GetDocent(id);
            if (docent == null)
            {
                return NotFound();
            }
            return View(docent);
        }

        // POST: Docents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("DocentId,Achternaam,Voornaam,Email,Indiensttreding")] Docent docent)
        {
            if (id != docent.DocentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _docentService.EditDocent(docent);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocentExists(docent.DocentId))
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
            return View(docent);
        }

        // GET: Docents/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _docentService.GetDocent(id) == null)
            {
                return NotFound();
            }

            var docent = _docentService.GetDocent(id);
            if (docent == null)
            {
                return NotFound();
            }

            return View(docent);
        }

        // POST: Docents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_docentService.GetDocent(id) == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Docent'  is null.");
            }
            var docent = _docentService.GetDocent(id);
            if (docent != null)
            {
                _docentService.DeleteDocent(docent);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool DocentExists(int id)
        {
            if (_docentService.GetDocent(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}

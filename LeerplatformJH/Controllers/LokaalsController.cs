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
    public class LokaalsController : Controller
    {
        private ILokaalService _lokaalService;


        public LokaalsController(ILokaalService lokaalService)
        {
            _lokaalService = lokaalService;
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult LoadAllLokalen()
        {
            try
            {
                var lokaalData = (from v in _lokaalService.GetAllLokalen()
                                  select v).ToList<Lokaal>();
                //Returning Json Data 
                return Json(new { data = lokaalData });
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: Lokaals
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            return View(_lokaalService.GetAllLokalen());

        }

        // GET: Lokaals/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokaal = _lokaalService.GetLokaal(id);

            if (lokaal == null)
            {
                return NotFound();
            }

            return View(lokaal);
        }

        // GET: Lokaals/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lokaals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("LokaalId,Titel,Omschrijving,Capaciteit,Middelen")] Lokaal lokaal)
        {
            if (ModelState.IsValid)
            {
                _lokaalService.CreateLokaal(lokaal);
                return RedirectToAction(nameof(Index));
            }
            return View(lokaal);
        }

        // GET: Lokaals/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _lokaalService.GetLokaal(id) == null)
            {
                return NotFound();
            }

            var lokaal = _lokaalService.GetLokaal(id);
            if (lokaal == null)
            {
                return NotFound();
            }
            return View(lokaal);
        }

        // POST: Lokaals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("LokaalId,Titel,Omschrijving,Capaciteit,Middelen")] Lokaal lokaal)
        {
            if (id != lokaal.LokaalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _lokaalService.EditLokaal(lokaal);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LokaalExists(lokaal.LokaalId))
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
            return View(lokaal);
        }

        // GET: Lokaals/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _lokaalService.GetLokaal(id) == null)
            {
                return NotFound();
            }

            var lokaal = _lokaalService.GetLokaal(id);
            if (lokaal == null)
            {
                return NotFound();
            }

            return View(lokaal);
        }

        // POST: Lokaals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_lokaalService.GetLokaal(id) == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Lokaal'  is null.");
            }
            var lokaal = _lokaalService.GetLokaal(id);
            if (lokaal != null)
            {
                _lokaalService.DeleteLokaal(lokaal);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool LokaalExists(int id)
        {
            if (_lokaalService.GetLokaal(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}

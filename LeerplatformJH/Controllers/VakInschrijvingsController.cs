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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace LeerplatformJH.Controllers
{
    public class VakInschrijvingsController : Controller
    {
        private IVakInschrijvingService _vakInschrijvingService;



        public VakInschrijvingsController(IVakInschrijvingService vakInschrijvingService)
        {
            _vakInschrijvingService = vakInschrijvingService;

        }
        [Authorize(Roles = "Administrator, Docent")]
        public IActionResult LoadAllVakInschrijvingen()
        {
            try
            {
                var vakInschrijvingData = (from v in _vakInschrijvingService.GetAllVakInschrijvingen()
                                  select v).ToList<VakInschrijving>();
                //Returning Json Data 
                return Json(new { data = vakInschrijvingData });
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: VakInschrijvings
        [Authorize(Roles = "Administrator, Docent")]
        public async Task<IActionResult> Index()
        {
            return View(_vakInschrijvingService.GetAllVakInschrijvingen());

        }

        // GET: VakInschrijvings/Details/5
        [Authorize(Roles = "Administrator, Docent")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vi = _vakInschrijvingService.GetVakInschrijving(id);

            if (vi == null)
            {
                return NotFound();
            }

            return View(vi);
        }

        // GET: VakInschrijvings/Create
        [Authorize(Roles = "Administrator, Docent")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: VakInschrijvings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Docent")]
        public async Task<IActionResult> Create([Bind("VakInschrijvingId,Titel,Goedkeuring")] VakInschrijving vakInschrijving)
        {
            if (ModelState.IsValid)
            {
                _vakInschrijvingService.CreateVakInschrijving(vakInschrijving);
                return RedirectToAction(nameof(Index));
            }
            return View(vakInschrijving);
        }

        // GET: VakInschrijvings/Edit/5
        [Authorize(Roles = "Administrator, Docent")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _vakInschrijvingService.GetVakInschrijving(id) == null)
            {
                return NotFound();
            }

            var vi = _vakInschrijvingService.GetVakInschrijving(id);
            if (vi == null)
            {
                return NotFound();
            }
            return View(vi);
        }

        // POST: VakInschrijvings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Docent")]
        public async Task<IActionResult> Edit(int id, [Bind("VakInschrijvingId,Titel,Goedkeuring")] VakInschrijving vakInschrijving)
        {
            if (id != vakInschrijving.VakInschrijvingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _vakInschrijvingService.EditVakInschrijving(vakInschrijving);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VakInschrijvingExists(vakInschrijving.VakInschrijvingId))
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
            return View(vakInschrijving);
        }

        // GET: VakInschrijvings/Delete/5
        [Authorize(Roles = "Administrator, Docent")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _vakInschrijvingService.GetVakInschrijving(id) == null)
            {
                return NotFound();
            }

            var docent = _vakInschrijvingService.GetVakInschrijving(id);
            if (docent == null)
            {
                return NotFound();
            }

            return View(docent);
        }

        // POST: Docents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator, Docent")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_vakInschrijvingService.GetVakInschrijving(id) == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Docent'  is null.");
            }
            var vi = _vakInschrijvingService.GetVakInschrijving(id);
            if (vi != null)
            {
                _vakInschrijvingService.DeleteVakInschrijving(vi);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VakInschrijvingExists(int id)
        {
            if (_vakInschrijvingService.GetVakInschrijving  (id) != null)
            {
                return true;
            }
            return false;
        }
    }
}

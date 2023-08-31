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
    public class VaksController : Controller
    {
        private IVakService _vakService;


        public VaksController(IVakService vakService)
        {
            _vakService = vakService;
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult LoadAllVakken()
        {
            try
            {
                var vakData = (from v in _vakService.GetAllVakken()
                                  select v).ToList<Vak>();
                //Returning Json Data 
                return Json(new { data = vakData });
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: Vaks
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            return View(_vakService.GetAllVakken());

        }

        // GET: Vaks/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vak = _vakService.GetVak(id);

            if (vak == null)
            {
                return NotFound();
            }

            return View(vak);
        }

        // GET: Vaks/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vaks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("VakId,Titel,Studiepunten")] Vak vak)
        {
            if (ModelState.IsValid)
            {
                _vakService.CreateVak(vak);
                return RedirectToAction(nameof(Index));
            }
            return View(vak);
        }

        // GET: Vaks/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _vakService.GetVak(id) == null)
            {
                return NotFound();
            }

            var vak = _vakService.GetVak(id);
            if (vak == null)
            {
                return NotFound();
            }
            return View(vak);
        }

        // POST: Vaks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("VakId,Titel,Studiepunten")] Vak vak)
        {
            if (id != vak.VakId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _vakService.EditVak(vak);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VakExists(vak.VakId))
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
            return View(vak);
        }

        // GET: Vaks/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _vakService.GetVak(id) == null)
            {
                return NotFound();
            }

            var vak = _vakService.GetVak(id);
            if (vak == null)
            {
                return NotFound();
            }

            return View(vak);
        }

        // POST: Vaks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_vakService.GetVak(id) == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vak'  is null.");
            }
            var vak = _vakService.GetVak(id);
            if (vak != null)
            {
                _vakService.DeleteVak(vak);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VakExists(int id)
        {
            if (_vakService.GetVak(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}

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
    public class LesController : Controller
    {
        private ILesService _lesService;


        public LesController(ILesService lesService)
        {
            _lesService = lesService;
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult LoadAllLessen()
        {
            try
            {
                var lesData = (from v in _lesService.GetAllLes()
                                  select v).ToList<Les>();
                //Returning Json Data 
                return Json(new { data = lesData });
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: Les
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            return View(_lesService.GetAllLes());

        }

        // GET: Les/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var les = _lesService.GetLes(id);

            if (les == null)
            {
                return NotFound();
            }

            return View(les);
        }

        // GET: Les/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Les/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("LesId,Titel,Omschrijving,TijdstipStart,TijdstipEinde")] Les les)
        {
            if (ModelState.IsValid)
            {
                _lesService.CreateLes(les);
                return RedirectToAction(nameof(Index));
            }
            return View(les);
        }

        // GET: Les/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _lesService.GetLes(id) == null)
            {
                return NotFound();
            }

            var les = _lesService.GetLes(id);
            if (les == null)
            {
                return NotFound();
            }
            return View(les);
        }

        // POST: Les/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("LesId,Titel,Omschrijving,TijdstipStart,TijdstipEinde")] Les les)
        {
            if (id != les.LesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _lesService.EditLes(les);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LesExists(les.LesId))
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
            return View(les);
        }

        // GET: Les/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _lesService.GetLes(id) == null)
            {
                return NotFound();
            }

            var les = _lesService.GetLes(id);
            if (les == null)
            {
                return NotFound();
            }

            return View(les);
        }

        // POST: Les/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_lesService.GetLes(id) == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Les'  is null.");
            }
            var les = _lesService.GetLes(id);
            if (les != null)
            {
                _lesService.DeleteLes(les);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool LesExists(int id)
        {
            if (_lesService.GetLes(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}

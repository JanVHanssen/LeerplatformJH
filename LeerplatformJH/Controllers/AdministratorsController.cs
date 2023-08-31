using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using LeerplatformJH.Data;
using LeerplatformJH.Models;
using LeerplatformJH.Services.Interfaces;
using LeerplatformJH.Services;
using Microsoft.AspNetCore.Authorization;

namespace LeerplatformJH.Controllers
{
    public class AdministratorsController : Controller
    {
        private IAdminsService _adminsService;


        public AdministratorsController(IAdminsService adminsService)
        {
            _adminsService = adminsService;
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult LoadAllAdmins()
        {
            try
            {
                var adminData = (from v in _adminsService.GetAllAdmins()
                                  select v).ToList<Administrator>();
                //Returning Json Data 
                return Json(new { data = adminData });
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: Administrators
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            return View(_adminsService.GetAllAdmins());

        }

        // GET: Administrators/Details/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = _adminsService.GetAdministrator(id);
           
            if (administrator == null)
            {
                return NotFound();
            }

            return View(administrator);
        }

        // GET: Administrators/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("AdministratorId,Achternaam,Voornaam,Email,Indiensttreding")] Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                _adminsService.CreateAdministrator(administrator);
                return RedirectToAction(nameof(Index));
            }
            return View(administrator);
        }

        // GET: Administrators/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _adminsService.GetAdministrator(id) == null)
            {
                return NotFound();
            }

            var administrator = _adminsService.GetAdministrator(id);
            if (administrator == null)
            {
                return NotFound();
            }
            return View(administrator);
        }

        // POST: Administrators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("AdministratorId,Achternaam,Voornaam,Email,Indiensttreding")] Administrator administrator)
        {
            if (id != administrator.AdministratorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _adminsService.EditAdministrator(administrator);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministratorExists(administrator.AdministratorId))
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
            return View(administrator);
        }

        // GET: Administrators/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _adminsService.GetAdministrator(id) == null)
            {
                return NotFound();
            }

            var administrator = _adminsService.GetAdministrator(id);
            if (administrator == null)
            {
                return NotFound();
            }

            return View(administrator);
        }

        // POST: Administrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_adminsService.GetAdministrator(id) == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Administratoren'  is null.");
            }
            var administrator = _adminsService.GetAdministrator(id);
            if (administrator != null)
            {
                _adminsService.DeleteAdministrator(administrator);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool AdministratorExists(int id)
        {
            if (_adminsService.GetAdministrator(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}

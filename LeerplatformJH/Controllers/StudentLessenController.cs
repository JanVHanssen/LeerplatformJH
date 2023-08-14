using Microsoft.AspNetCore.Mvc;
using LeerplatformJH.Models.ViewModels;
using LeerplatformJH.Models;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Drawing.Printing;
using LeerplatformJH.Data;
using System.Numerics;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LeerplatformJH.Controllers
{
    public class StudentLessenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentLessenController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> asyncIndex()
        {

            var lesStudent = (from s in _context.Studenten
                              join l in _context.Lessen
                              on s.StudentId equals l.StudentId
                              where s.Email == User.Identity.Name
                              group l by s.StudentId into sByLid
                              select new StudentLessen
                              {
                                  Id = sByLid.Key,
                                  Lessen = sByLid.ToList()
                              }).FirstOrDefault();

            IEnumerable<Les> lessen = lesStudent.Lessen;
           
            
           

            return View();



        }
    }
}

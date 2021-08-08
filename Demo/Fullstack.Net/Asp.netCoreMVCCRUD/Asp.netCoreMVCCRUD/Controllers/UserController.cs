using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.netCoreMVCCRUD.Models;

namespace Asp.netCoreMVCCRUD.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }


        // GET: User/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new User());
            else
                return View(_context.Users.Find(id));
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("UserId,FullName,PhoneNumber,Position,")] User User)
        {
            if (ModelState.IsValid)
            {
                if (User.UserId == 0)
                    _context.Add(User);
                else
                    _context.Update(User);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(User);
        }


        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var User =await _context.Users.FindAsync(id);
            _context.Users.Remove(User);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}

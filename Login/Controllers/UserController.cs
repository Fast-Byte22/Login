using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Login.Context;
using Login.Models;

namespace Login.Controllers
{
    public class UserController : Controller
    {
        private readonly usersContext _context;

        public UserController(usersContext context)
        {
            _context = context;
        }

        // GET: Usertables
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usertables.ToListAsync());
        }

        // GET: Usertables/SignUp
        public async Task<IActionResult> SignUp()
        {
            return View();
        }
        public async Task<IActionResult> List()
        {
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([Bind("Id,FirstName,LastName,Email,PhoneNumber,Password,DateOfBirth")] Usertable usertable)
        {
            
            usertable.CreateTime = GetUtcNow().ToString();


            try
            {
                var ez = _context.Usertables
                    .Single(e => e.Email == usertable.Email);
                if (ez.Email != usertable.Email)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction(nameof(LogIn));
                }
            }
            catch{

                if (ModelState.IsValid)
                {
                    _context.Add(usertable);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }


            return View(usertable);

            static DateTime GetUtcNow()
            {
                return DateTime.UtcNow;
            }
        }

      
        // GET: Usertables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usertable = await _context.Usertables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usertable == null)
            {
                return NotFound();
            }

            return View(usertable);
        }

        // GET: Usertables/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreateTime,FirstName,LastName,Email,PhoneNumber,Password,DateOfBirth")] Usertable usertable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usertable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usertable);
        }

        // GET: Usertables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usertable = await _context.Usertables.FindAsync(id);
            if (usertable == null)
            {
                return NotFound();
            }
            return View(usertable);
        }

        // POST: Usertables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreateTime,FirstName,LastName,Email,PhoneNumber,Password,DateOfBirth")] Usertable usertable)
        {
            if (id != usertable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usertable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsertableExists(usertable.Id))
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
            return View(usertable);
        }

        // GET: Usertables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usertable = await _context.Usertables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usertable == null)
            {
                return NotFound();
            }

            return View(usertable);
        }

        // POST: Usertables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usertable = await _context.Usertables.FindAsync(id);
            _context.Usertables.Remove(usertable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsertableExists(int id)
        {
            return _context.Usertables.Any(e => e.Id == id);
        }

        // GET: Usertables/Login
        [HttpGet]
        public async Task<IActionResult> LogIn(string? status)
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(string Email, string Password)
        {
            if (Email.Length < 4)
            {
                return NotFound("s");
            }
            else if (Password.Length < 4)
            {
                return NotFound();
            }


            try
            {
                var ez = _context.Usertables.Single(e => e.Email == Email && e.Password == Password);



                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return RedirectToAction(nameof(SignUp));
            }
       

        }
    }
}

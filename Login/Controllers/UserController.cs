using Login.Context;
using Login.Models;
using Login.Custom;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;



namespace Login.Controllers
{



    public class UserController : Controller
    {
        private readonly usersContext _context;

        public UserController(usersContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Usertables.ToListAsync());
        }

        public async Task<IActionResult> SignUp(string error)
        {
            try
            {
                var CookiesId = HttpContext.User.Claims.Single(c => c.Type == "id");
                var CookiesRole = HttpContext.User.Claims.Single(c => c.Type == ClaimTypes.Role);
                if (CookiesId.Value != null && CookiesRole.Value != null)
                {
                    var ez = await _context.Usertables.SingleAsync(e => e.Id == Int32.Parse(CookiesId.Value) && e.Role == CookiesRole.Value.ToString());
                    return Redirect(nameof(Index));
                }
            }
            catch { }

            if (error != null)
            {
                ViewBag.error = error;
            }
            else
            {
                ViewBag.error = "";
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([Bind("Id,FirstName,LastName,Email,PhoneNumber,Password,DateOfBirth")] Usertable usertable)
        {

            usertable.CreateTime = GetUtcNow().ToString();
            usertable.Role = "0";
            HashPasscs hashPasscs = new HashPasscs();
            hashPasscs = hashPasscs.HashPass(usertable.Password);
            usertable.PassHash = hashPasscs.hash;
            usertable.salt = hashPasscs.salt;

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
                    return MessageError("SignUp","Account already exist.");

                }
            }
            catch
            {

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

#nullable enable
        
        [RequireHttps]
        [HttpGet]
        public async Task<IActionResult> LogIn(string? error)
        {


                try
                {
                    var x = HttpContext.User.Claims.Single(c => c.Type == "id");
                    var xx = HttpContext.User.Claims.Single(c => c.Type == ClaimTypes.Role);
                if (x.Value != null && xx.Value != null)
                {
                    var ez = await _context.Usertables.SingleAsync(e => e.Id == Int32.Parse(x.Value) && e.Role == xx.Value.ToString());
                    return Redirect(nameof(Index));
                }

                }
                catch
                {


                }


            if (error == null)
            {
                //TempData["ErrorMessage"] = "";
                return View();
            }
            TempData["ErrorMessage"] = error;
            return View();
        }

        public IActionResult MessageError(string a, string s, string x = "User")
        {
            

            return RedirectToAction(a, "User", new { error = s });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(string Email, string Password)
        {

            if (Email.Length < 4)
            {
                return NotFound();
            }
            else if (Password.Length < 4)
            {
                return NotFound();
            }

;

            try
            {
                

                var ez = await _context.Usertables.SingleAsync(e => e.Email == Email );



                if (ez.PassHash != HashPasscs.CheckHashPass(Password,ez.salt))
                {
                    return MessageError("LogIn", "Invalid Email or Password");
                }


                var claims = new List<Claim> {
                    new Claim("id",ez.Id.ToString(), ClaimValueTypes.Integer),
                    new Claim(ClaimTypes.Role, ez.Role)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(15),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProperties);

                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return MessageError("LogIn", "Invalid Email or Password");
            }
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                var x = HttpContext.User.Claims.Single(c => c.Type == "id");
                var xx = HttpContext.User.Claims.Single(c => c.Type == ClaimTypes.Role);
                await HttpContext.SignOutAsync();
                return MessageError("LogIn", "Log out");

            }
            catch
            {
                return RedirectToAction(nameof(LogIn));

            }


        }

    }
}

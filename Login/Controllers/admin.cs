using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Login.Context;
using Login.Models;
using System.Linq;
using System.Security.Claims;

namespace Login.Controllers
{
    public class admin : Controller
    {
        public IActionResult Index()
        {
            try
            {
                if (int.Parse( HttpContext.User.Claims.Single(c => c.Type == ClaimTypes.Role).Value) == 1)
                {
                    return View();
                }
                return Redirect("/home/AccesDenied");
            }
            catch (Exception)
            {

                return Redirect("/home/AccesDenied");
            }
            //return View();
        }

#pragma warning disable CS1998 
        public async Task<IActionResult> context()
#pragma warning restore CS1998 
        {
            
            List<string> contextList = new List<string>();
            contextList.Add("userContext");

            return View(contextList);
        }
    }
}

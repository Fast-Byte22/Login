using Login.Context;
using Login.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Login.Controllers
{
    public class Chat : Controller
    {
        private readonly usersContext _context;

        public Chat(usersContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {


            return View();
        }
    }
}

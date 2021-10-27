using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UserMVC.Models;
using UserMVC.Models.Entities;

namespace UserMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly HandsonContext _context;

        public HomeController(HandsonContext context)
        {
            _context = context;
        }
        public ActionResult Index(int id = 0)
        {
            if (id == 0)
            {
                ViewData["error"] = null;

            }
            else if (id == 1)
            {
                ViewData["error"] = "User Not Found";

            }
            else
            {
                return NotFound();
            }
            return View();
        }

        public ActionResult Validation(Login login)
        {
            var userDetail = _context.UserDetails.FirstOrDefault(m => ((m.Name == login.username) && (m.Password == login.password)));
            if (userDetail == null)
            {
                return RedirectToAction("Index", "Home", new { @id = 1 });
            }
            else
            {
                return RedirectToAction("Index", "Users");

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserMVC.Models.Entities;
using UserMVC.ViewModel;

namespace UserMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly HandsonContext _context;

        public UsersController(HandsonContext context)
        {
            _context = context;
        }


        public ActionResult Index()
        {
            var users = _context.UserDetails.ToList();
            return View(users);
        }

        public ActionResult Create()
        {
            var dept = _context.Departments.ToList();
            ViewData["Title"] = "Create";
            var userView = new UserDepartment
            {
                Departments = dept,
                userdetail=new UserDetail()
            };
            return View(userView);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDetail = _context.UserDetails.Find(id);
            if (userDetail == null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Edit";
            var dept = _context.Departments.ToList();
            var userView = new UserDepartment
            {
                userdetail=userDetail,
                Departments=dept
            };
            return View("Create", userView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind("Name,Email,Department,Address,Admin,Password")] UserDetail userDetail)
        {
            if (userDetail.Id == 0)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(userDetail);
                    
                }

            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(userDetail);
                                            }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UserDetailExists(userDetail.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Users");
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDetail = _context.UserDetails.FirstOrDefault(m => m.Id == id);
            if (userDetail == null)
            {
                return NotFound();
            }
            _context.UserDetails.Remove(userDetail);
            _context.SaveChanges();


            return RedirectToAction("Index", "Users");
        }



        private bool UserDetailExists(int id)
        {
            return _context.UserDetails.Any(e => e.Id == id);
        }
    }
}

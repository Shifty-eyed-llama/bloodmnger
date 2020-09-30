using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using organProject.Models;

//***************************
using System.Text.RegularExpressions;
//**************************

namespace organProject.Controllers  
{
    public class HomeController : Controller   
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]     
        public IActionResult Switch()
        {
            return View("Switch"); 
        }

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        [HttpGet("/logreg")]
        public IActionResult Index()
        {
            return View("Index");
        }

//==========================================================================

        [HttpPost("/user/create")]
        public IActionResult CreateUser(LogRegWrapper Form)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                Form.NewUser.Password = Hasher.HashPassword(Form.NewUser, Form.NewUser.Password);

                _context.Add(Form.NewUser);
                _context.SaveChanges();

                User ThisUser = _context.Users.FirstOrDefault(i => i.Email == Form.NewUser.Email);
                HttpContext.Session.SetInt32("UserID", ThisUser.UserID);

                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

//=========================================================================================

        [HttpPost("/user/checklogin")]
        public IActionResult Verify(LogRegWrapper Form)
        {
            if(ModelState.IsValid)
            {
                var inDB = _context.Users.FirstOrDefault(u => u.Email == Form.LoginUser.Email);

                if(inDB == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Passoword");
                    return View("Index");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(Form.LoginUser , inDB.Password, Form.LoginUser.Password);

                if(result == 0)
                {
                    ModelState.AddModelError("Password", "Are you sure you belong here?");
                    return View("Index");
                }

                User ThisUser = _context.Users.FirstOrDefault(u => u.Email == Form.LoginUser.Email);
                
                HttpContext.Session.SetInt32("UserID", ThisUser.UserID);
                
                return RedirectToAction("Dashboard");
                
            }

            return View("Index");
        }

//======================================================================================

        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

//=============================================================================================

        [HttpGet("/dashboard")]
        public IActionResult Dashboard()
        {
            int? userid = HttpContext.Session.GetInt32("UserID");

            if(userid == null)
            {
                return RedirectToAction("Index");
            }

            DashWrapper DashWrap = new DashWrapper();
            DashWrap.ThisUser = _context.Users.FirstOrDefault(s => s.UserID == userid);

            DashWrap.AllDonors = _context.Donors
            .Include(q => q.CurrentCenter)
            .ToList();

            return View("Dashboard", DashWrap);
        }

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        [HttpGet("/add/donor")]
        public IActionResult NewDonor()
        {
            int? userid = HttpContext.Session.GetInt32("UserID");

            if(userid == null)
            {
                return RedirectToAction("Index");
            }

            NewDonorWrap NewDonorWrap = new NewDonorWrap();
            NewDonorWrap.ThisUser = _context.Users.FirstOrDefault(p => p.UserID == userid);
            NewDonorWrap.AllCenter = _context.Centers.ToList();
            
            return View("NewDonor");
        }


//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++


        [HttpPost("/add/donor")]
        public IActionResult CreateDonor(NewDonorWrap Form)
        {
            int? userid = HttpContext.Session.GetInt32("UserID");

            if(userid == null)
            {
                return RedirectToAction("Index");
            }

            if(ModelState.IsValid)
            {
                _context.Add(Form.NewDonor);
                _context.SaveChanges();

                return RedirectToAction("Dashboard");
            }

            return NewDonor();
        }


//+++++++++++++++++++++++++++++++++++++++++++++++++++++


        [HttpPost("/add/center")]
        public IActionResult CreateCenter(Center Form)
        {
            int? userid = HttpContext.Session.GetInt32("UserID");

            if(userid == null)
            {
                return RedirectToAction("Index");
            }

            if(ModelState.IsValid)
            {
                _context.Add(Form);
                _context.SaveChanges();

                return RedirectToAction("Dashboard");
            }

            return NewCenter();
        }

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        [HttpGet("/add/center")]
        public IActionResult NewCenter()
        {
            int? userid = HttpContext.Session.GetInt32("UserID");

            if(userid == null)
            {
                return RedirectToAction("Index");
            }
            
            Center NewCenter = new Center();

            return View("NewCenter");
        }

//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

        [HttpGet("/find/matches/{id}")]
        public IActionResult FindMatch(int id)
        {
            int? userid = HttpContext.Session.GetInt32("UserID");

            if(userid == null)
            {
                return RedirectToAction("Index");
            }

            MatchWrap MatchWrap = new MatchWrap();

            MatchWrap.ThisUser = _context.Users.FirstOrDefault(r => r.UserID == userid);
            Donor ThisDonor = _context.Donors.FirstOrDefault(o => o.DonorID == id);
            MatchWrap.ThisDonor = ThisDonor;
            MatchWrap.Potential = _context.Recipients
            .Include(e => e.CurrentCenter)
            .Where(b => b.BloodType == ThisDonor.BloodType && b.Rh == ThisDonor.Rh).ToList();

            return View("PotentialMatch", MatchWrap);
        }


    }
}
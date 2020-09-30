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
    public class FacilityController : Controller   
    {
        private MyContext _context;

        public FacilityController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("/facility")]     
        public IActionResult LogReg()
        {
            return View("LogReg"); 
        }

//==========================================================================

        [HttpPost("facility/user/create")]
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
            return View("LogReg");
        }

//=========================================================================================

        [HttpPost("facility/user/checklogin")]
        public IActionResult Verify(LogRegWrapper Form)
        {
            if(ModelState.IsValid)
            {
                var inDB = _context.Users.FirstOrDefault(u => u.Email == Form.LoginUser.Email);

                if(inDB == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Passoword");
                    return View("LogReg");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(Form.LoginUser , inDB.Password, Form.LoginUser.Password);

                if(result == 0)
                {
                    ModelState.AddModelError("Password", "Are you sure you belong here?");
                    return View("LogReg");
                }

                User ThisUser = _context.Users.FirstOrDefault(u => u.Email == Form.LoginUser.Email);
                
                HttpContext.Session.SetInt32("UserID", ThisUser.UserID);
                
                return RedirectToAction("Dashboard");
                
            }

            return View("LogReg");
        }

//======================================================================================

        [HttpGet("facility/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LogReg");
        }

//=============================================================================================

        [HttpGet("/facility/dashboard")]
        public IActionResult Dashboard()
        {
            int? userid = HttpContext.Session.GetInt32("UserID");

            if(userid == null)
            {
                return RedirectToAction("LogReg");
            }

            FacilityDashWrapper DashWrap = new FacilityDashWrapper();
            DashWrap.ThisUser = _context.Users.FirstOrDefault(s => s.UserID == userid);

            DashWrap.AllCenter = _context.Centers
            .Include(r => r.Recipients)
            .ToList();

            DashWrap.AllRecipient = _context.Recipients
            .Include(q => q.CurrentCenter)
            .ThenInclude(e => e.Recipients)
            .ToList();

            return View("Dashboard", DashWrap);
        }

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        [HttpGet("/facility/add/patient")]
        public IActionResult AddPatient()
        {
            int? userid = HttpContext.Session.GetInt32("UserID");

            if(userid == null)
            {
                return RedirectToAction("LogReg");
            }

            NewPatientWrap NewPtWrap = new NewPatientWrap();
            NewPtWrap.ThisUser = _context.Users.FirstOrDefault(p => p.UserID == userid);
            NewPtWrap.AllCenter = _context.Centers
            .Include(r => r.Recipients).ToList();

            return View("AddPatient", NewPtWrap);

        }


//************************************************************************

        [HttpPost("/facility/add/patient")]
        public IActionResult CreatePatient(NewPatientWrap Form)
        {
            int? userid = HttpContext.Session.GetInt32("UserID");

            if(userid == null)
            {
                return RedirectToAction("LogReg");
            }

            if(ModelState.IsValid)
            {
                _context.Add(Form.NewRecipient);
                _context.SaveChanges();

                return RedirectToAction("AddPatient");

            }

            return AddPatient();
        }

        [HttpGet("/facility/add/center")]
        public IActionResult AddCenter()
        {
            return View("AddCenter");
        }
        [HttpPost("/facility/add/center")]
        public IActionResult CreateCenter(Center Form)
        {
            _context.Add(Form);
            _context.SaveChanges();

            return View("AddCenter");
        }

        [HttpGet("/facility/listcenter")]
        public IActionResult ListCenter()
        {
            NewPatientWrap justList = new NewPatientWrap();

            justList.AllCenter = _context.Centers.ToList();

            return View("ListCenter", justList);
        }

        [HttpGet("/facility/delete/patient/{id}")]
        public IActionResult DeletePatient(int id)
        {
            Recipient ToDelete = _context.Recipients.FirstOrDefault(o => o.RecipientID == id);
            _context.Remove(ToDelete);
            _context.SaveChanges();


            return RedirectToAction("Dashboard");
        }

    }
}
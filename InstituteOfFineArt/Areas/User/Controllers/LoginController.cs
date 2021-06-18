using InstituteOfFineArt.Areas.User.Services;
using InstituteOfFineArt.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Controllers
{
    [Area("user")]
    [Route("login")]
    [Route("user/login")]
    public class LoginController : Controller
    {
        private LoginService loginService;
        private IWebHostEnvironment webHostEnvironment;
        private DatabaseContext db;

        public LoginController(LoginService _loginService, IWebHostEnvironment _webHostEnvironment, DatabaseContext db)
        {
            loginService = _loginService;
            webHostEnvironment = _webHostEnvironment;
            this.db = db;
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username, string password)
        {
            string account = loginService.Find(username);
            string pass = loginService.Pass(username);
            bool thispass = BCrypt.Net.BCrypt.Verify(password, pass);
            string idAcc = loginService.FindIdByUsername(username).ToString();
            string idRole = loginService.FindIdRole(idAcc).ToString();
            string nameRole = loginService.FindNameRole(idRole).ToString();

            if (account.Equals(username) && thispass.Equals(true))
            {
                if (nameRole == "admin")
                {

                    HttpContext.Session.SetString("username", username);
                    HttpContext.Session.SetString("idAcc", idAcc);
                    return RedirectToAction("admin");
                }
                if (nameRole == "student")
                {
                    HttpContext.Session.SetString("username", username);
                    HttpContext.Session.SetString("idAcc", idAcc);
                    return RedirectToAction("student");
                }
                if (nameRole == "school")
                {
                    HttpContext.Session.SetString("username", username);
                    HttpContext.Session.SetString("idAcc", idAcc);
                    return RedirectToAction("school");
                }

            }
            else
            {
                ViewBag.error = "Login Failed";
                return RedirectToAction("Login");
            }

            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();//remove session
            return RedirectToAction("Login");
        }



        [Route("student")]
        public IActionResult Student()
        {
            ViewBag.username = HttpContext.Session.GetString("username"); // lấy tên người đăng nhập 

            return View("student");
        }

        [Route("admin")]
        public IActionResult Admin()
        {
            ViewBag.username = HttpContext.Session.GetString("username"); // lấy tên người đăng nhập 

            return View("admin");
        }

        [Route("school")]
        public IActionResult School()
        {
             ViewBag.username = HttpContext.Session.GetString("username"); // lấy tên người đăng nhập 
           
            return View("school");
        }
    }
}

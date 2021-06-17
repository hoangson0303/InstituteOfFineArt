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
        public LoginController(LoginService _loginService, IWebHostEnvironment _webHostEnvironment)
        {
            loginService = _loginService;
            webHostEnvironment = _webHostEnvironment;
        }

        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [Route("login")]
        
        public IActionResult Login(string username, string password)
        {
            var account = loginService.Find(username);
            string idAcc = loginService.FindIdByUsername(username).ToString();
            string idRole = loginService.FindIdRole(idAcc).ToString();
            string nameRole = loginService.FindNameRole(idRole).ToString();

            if (loginService.Login(username, password) != null)
            {
                if (nameRole == "admin")
                {
                    
                    HttpContext.Session.SetString("username", username);
                    return RedirectToAction("admin");
                }if (nameRole == "student")
                {
                    HttpContext.Session.SetString("username", username);
                    return RedirectToAction("student");
                }if (nameRole == "school")
                {
                    HttpContext.Session.SetString("username", username);
                    return RedirectToAction("school");
                }
                else
                {
                    HttpContext.Session.SetString("username", username);
                    return View("login");
                }

            }
            else
            {

                ViewBag.msg = "Invalid";
                return View("login");
            }

            //if (loginService.Login(username, password) == null)
            //{
            //    ViewBag.msg = "Invalid";
            //    return View("Login");
            //}
            //else
            //{   
            //    Debug.WriteLine("username :" + username);
            //    HttpContext.Session.SetString("username", username);
            //    return RedirectToAction("school");
            //}
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

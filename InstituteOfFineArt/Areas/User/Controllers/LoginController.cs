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
            if (loginService.Login(username, password) == null)
            {
                ViewBag.msg = "Invalid";
                return View("Login");
            }
            else
            {   
                Debug.WriteLine("username :" + username);
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("school");
            }
        }
    
        [Route("school")]
        public IActionResult School()
        {
             ViewBag.username = HttpContext.Session.GetString("username"); // lấy tên người đăng nhập 
           
            return View("school");
        }
    }
}

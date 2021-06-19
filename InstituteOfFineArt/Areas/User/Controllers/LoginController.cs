using InstituteOfFineArt.Areas.User.Services;
using InstituteOfFineArt.Models;
using InstituteOfFineArt.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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
            //}
            //[HttpPost]
            //[Route("login")]
            //public IActionResult Login(SiginViewModels signin)
            //{
            //    bool isUserValid = false;
            //    bool isUserRoleValid = false;

            //    var account = loginService.GetAccount(signin.Username);
            //    var userrole = loginService.GetRole(account.IdRole);
            //    if (account != null && BCrypt.Net.BCrypt.Verify(signin.Pass, account.Pass))
            //    {

            //        isUserValid = true;
            //        isUserRoleValid = true;
            //    }


            //    if (ModelState.IsValid && isUserValid && isUserRoleValid)
            //    {
            //        //if (HttpContext.Session.GetString("idacc") == null)
            //        //{
            //        //    HttpContext.Session.SetString("idacc", JsonConvert.SerializeObject(account.IdAcc));
            //        //}
            //        //return View("~/Views/Index/Index.cshtml");

            //        string key = "Idacc";
            //        string value = account.IdAcc;
            //        CookieOptions cookieOptions = new CookieOptions();
            //        cookieOptions.Expires = DateTime.Now.AddDays(30);
            //        Response.Cookies.Append(key, value, cookieOptions);

            //        var claims = new List<Claim>
            //        {
            //            new Claim(ClaimTypes.Name, account.Email),
            //            new Claim(ClaimTypes.Role, userrole),


            //        };


            //        var identity = new ClaimsIdentity(
            //            claims, CookieAuthenticationDefaults.
            //AuthenticationScheme);

            //        var principal = new ClaimsPrincipal(identity);

            //        var props = new AuthenticationProperties();
            //        props.IsPersistent = signin.Rememberme;

            //        HttpContext.SignInAsync(
            //            CookieAuthenticationDefaults.
            //AuthenticationScheme,
            //            principal, props).Wait();

            //        return RedirectToAction("login", "school", new { area = "" });
            //    }
            //    else
            //    {
            //        ViewData["message"] = "Your email or password is wrong!";
            //        return View("login");
            //    }
            //    return View("login");

            //}
            [Route("school")]
        public IActionResult School()
        {
             ViewBag.username = HttpContext.Session.GetString("username"); // lấy tên người đăng nhập 
           
            return View("school");
        }

        [Route("add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View("Add", new Account());

        }
       
    }
}

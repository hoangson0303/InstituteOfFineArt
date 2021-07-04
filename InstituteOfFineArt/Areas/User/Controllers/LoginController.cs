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
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Controllers
{
    [Area("user")]
    [Route("login")]
  // [Route("user/login")]
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
        [Route("")]
        public IActionResult Login()
        {
            return View("login");
        }
        [HttpPost]
        [Route("login")]
       
        public IActionResult Login(SigninViewModels signin , string username , string password)
        {
            if (loginService.Login(username, password) == null)
            {

                return View("login");
            }
          
                bool isUserValid = false;
                bool isUserRoleValid = false;

                var account = loginService.Find(signin.Username);
                string pass = loginService.Pass(signin.Username);
                bool thispass = BCrypt.Net.BCrypt.Verify(signin.Password, pass);
                string idAcc = loginService.FindIdByUsername(signin.Username).ToString();
                string idRole = loginService.FindIdRole(idAcc).ToString();
                string nameRole = loginService.FindNameRole(idRole).ToString();

                if (account.Equals(signin.Username) && thispass.Equals(true))
                {
                    isUserValid = true;
                    isUserRoleValid = true;
                }
                if (ModelState.IsValid && isUserValid && isUserRoleValid)
                {

                    string key = "Idacc";
                    string value = idAcc;
                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Append(key, value, cookieOptions);

                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, signin.Username),
                    new Claim(ClaimTypes.Role, nameRole),


                };


                    var identity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.
            AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);



                    if (nameRole == "admin")
                    {

                        HttpContext.Session.SetString("idAcc", idAcc);
                        return RedirectToAction("admin");
                    }
                    if (nameRole == "student")
                    {
                        HttpContext.Session.SetString("username", signin.Username);
                        HttpContext.Session.SetString("idAcc", idAcc);
                        return RedirectToAction("student");
                    }
                    if (nameRole == "customer")
                    {
                        HttpContext.Session.SetString("username", signin.Username);
                        HttpContext.Session.SetString("idAcc", idAcc);
                        return RedirectToAction("customer");
                    }
                    if (nameRole == "school")
                        {
                            HttpContext.Session.SetString("username", signin.Username);
                            HttpContext.Session.SetString("idAcc", idAcc);
                            return RedirectToAction("school");
                        }

                    return RedirectToAction("index", "Index", new { area = "" });
                }


                else
                {
                    ViewData["message"] = "Your username or password is wrong!";
                    return View("Login");
                }

               
            
           
        }





        [Route("student")]
        public IActionResult Student()
        {
            ViewBag.school = loginService.FindAllSchool();
            ViewBag.compititions = loginService.FindAll();
            ViewBag.test = loginService.FindAllTest();
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = loginService.FindUserById(cookieIdacc);
            if (cookieIdacc == null)
            {
                ViewBag.loggedin = false;

            }
            return View("student");
        }

        [Route("customer")]
        public IActionResult Customer()
        {
            ViewBag.school = loginService.FindAllSchool();
            ViewBag.compititions = loginService.FindAll();
            ViewBag.test = loginService.FindAllTest();
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = loginService.FindUserById(cookieIdacc);
            if (cookieIdacc == null)
            {
                ViewBag.loggedin = false;

            }
            return View("customer");
        }

        [Route("admin")]
        public IActionResult Admin()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = loginService.FindUserById(cookieIdacc);

            return View("admin");
        }

        [Route("school")]
        public IActionResult School()
        {

            ViewBag.school = loginService.FindAllSchool();
            ViewBag.compititions = loginService.FindAll();
            ViewBag.test = loginService.FindAllTest();
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = loginService.FindUserById(cookieIdacc);
            if (cookieIdacc == null)
            {
                ViewBag.loggedin = false;

            }
           
            return View("school");
        }


        [HttpPost]
        [Route("add")]
        public IActionResult Add(Account account )
        {

            string nameRole = "customer";
            string idRole = loginService.GetIdRoleByNameRol(nameRole);


            var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*)(?<Numeric>[0-9]*)");
            int num = 0;
            if (loginService.GetNewestId(nameRole) != null)
            {
                var match = numAlpha.Match(loginService.GetNewestId(nameRole));
                //var alpha = match.Groups["Alpha"].Value;
                num = Int32.Parse(match.Groups["Numeric"].Value);

            }

            account.Stat = true;
            account.IdRole = idRole;
            account.Pass = BCrypt.Net.BCrypt.HashString(account.Pass);
            account.Datecreated = DateTime.Now;


            if (loginService.CountIdById(nameRole) != 0)
            {
                account.IdAcc = nameRole + (num + 1);
                string idAcc = loginService.Created(account).IdAcc;

                var userRole = new UserRole();
                userRole.IdAcc = idAcc;
                userRole.IdRole = idRole;
                userRole.Datecreated = DateTime.Now;
                userRole.Dateupdated = DateTime.Now;

                loginService.CreateUserRole(userRole);


            }
            else
            {
                account.IdAcc = nameRole + 1;

                string idAcc = loginService.Created(account).IdAcc;

                var userRole = new UserRole();
                userRole.IdAcc = idAcc;
                userRole.IdRole = idRole;
                userRole.Datecreated = DateTime.Now;
                userRole.Dateupdated = DateTime.Now;

                loginService.CreateUserRole(userRole);
            }




           // loginService.Created(account);
                    return RedirectToAction("index");
                }
           
           
    

    }
}

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
            ViewBag.compititions = loginService.FindAll();
            string cookieIdacc = Request.Cookies["Idacc"];
            Debug.WriteLine(cookieIdacc);
            if (cookieIdacc == null)
            {
                ViewBag.loggedin = false;

            }
            if (HttpContext.User.IsInRole("admin"))
            {
                ViewBag.role = "admin";
            }
            if (HttpContext.User.IsInRole("student"))
            {
                ViewBag.role = "student";
            }
            if (HttpContext.User.IsInRole("school"))
            {
                ViewBag.role = "school";
            }
            ViewBag.username = HttpContext.Session.GetString("username"); 
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
          
            ViewBag.compititions = loginService.FindAll();
            string cookieIdacc = Request.Cookies["Idacc"];

            Debug.WriteLine(cookieIdacc);
            if (cookieIdacc == null)
            {
                ViewBag.loggedin = false;

            }
            if (HttpContext.User.IsInRole("admin"))
            {
                ViewBag.role = "admin";
            }
            if (HttpContext.User.IsInRole("student"))
            {
                ViewBag.role = "student";
          
            }
            if (HttpContext.User.IsInRole("school"))
            {
                ViewBag.role = "school";
               
            }
            ViewBag.username = HttpContext.Session.GetString("username"); // lấy tên người đăng nhập 
           
            return View("school");
        }


        [Route("add")]
        [HttpPost]
        public IActionResult Add(Test tes, IFormFile file)
        {

            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = loginService.FindUserById(cookieIdacc);

            var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*)(?<Numeric>[0-9]*)");
            int num = 0;
            if (loginService.GetNewestId(tes.NameTest) != null)
            {
                var match = numAlpha.Match(loginService.GetNewestId(tes.NameTest));
                //var alpha = match.Groups["Alpha"].Value;
                num = Int32.Parse(match.Groups["Numeric"].Value);

            }
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var ext = file.ContentType.Split(new char[] { '/' })[1];
                var path = Path.Combine(webHostEnvironment.WebRootPath, "user/images", fileName + "." + ext);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                tes.ImgOfTest = fileName + "." + ext;

            }
            else
            {
                tes.ImgOfTest = "aaa.png";
            }

            tes.Datecreated = DateTime.Now;
            tes.Stat = false;
            tes.IdAcc = cookieIdacc;

            if (loginService.CountIdById(tes.NameTest) != 0)
            {
                tes.IdTest = tes.NameTest + (num + 1);

                loginService.Create(tes);
            }
            else
            {
                tes.IdTest = tes.NameTest + 1;

                loginService.Create(tes);
            }



            return RedirectToAction("student");
        }

    }
}

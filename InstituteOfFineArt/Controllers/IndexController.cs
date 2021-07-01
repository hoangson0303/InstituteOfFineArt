using InstituteOfFineArt.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
    [Route("index")]
    public class IndexController : Controller
    {
        private IndexService indexService;
        private IWebHostEnvironment webHostEnvironment;

        public IndexController(IndexService _indexService, IWebHostEnvironment _webHostEnvironment)
        {
            indexService = _indexService;
            this.webHostEnvironment = _webHostEnvironment;
        }
        [Route("index")]
        [Route("")]
        [Route("~/")]
        public IActionResult Index()
        {
            ViewBag.school = indexService.FindAllSchool();
            ViewBag.compititions = indexService.FindAll();
            ViewBag.test = indexService.FindAllTest();

            string cookieIdacc = Request.Cookies["Idacc"];
            if(cookieIdacc != null)
            {
                string idRole = indexService.FindIdRole(cookieIdacc).ToString();
                string nameRole = indexService.FindNameRole(idRole).ToString();
                if (nameRole == "admin")
                {

                    ViewBag.acc = indexService.FindUserById(cookieIdacc);
                    return RedirectToAction("admin");
                }
                if (nameRole == "student")
                {
                    ViewBag.acc = indexService.FindUserById(cookieIdacc);
                    return RedirectToAction("student");
                }
                if (nameRole == "school")
                {
                    ViewBag.acc = indexService.FindUserById(cookieIdacc);
                    return RedirectToAction("school");
                }
            }
            else
            {
                ViewBag.acc = indexService.FindUserById(cookieIdacc);
                Debug.WriteLine(cookieIdacc);
                if (cookieIdacc == null)
                {
                    ViewBag.loggedin = false;

                }
            }
            
            
            
            return View();
        }

        [Route("login")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            string key = "Idacc";
            string value = "";
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Append(key, value, cookieOptions);

            return View("login");

        }

        [Route("student")]
        public IActionResult Student()
        {
            ViewBag.school = indexService.FindAllSchool();
            ViewBag.compititions = indexService.FindAll();
            ViewBag.test = indexService.FindAllTest();
            string cookieIdacc = Request.Cookies["Idacc"];
            if (cookieIdacc == null)
            {
                ViewBag.loggedin = false;

            }
            ViewBag.acc = indexService.FindUserById(cookieIdacc);
            return View("student");
        }

        [Route("admin")]
        public IActionResult Admin()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = indexService.FindUserById(cookieIdacc);

            return View("admin");
        }

        [Route("school")]
        public IActionResult School()
        {

            ViewBag.school = indexService.FindAllSchool();
            ViewBag.compititions = indexService.FindAll();
            ViewBag.test = indexService.FindAllTest();
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = indexService.FindUserById(cookieIdacc);
            if (cookieIdacc == null)
            {
                ViewBag.loggedin = false;

            }

            return View("school");
        }
    }



}

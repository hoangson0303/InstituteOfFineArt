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
            Debug.WriteLine(cookieIdacc);
            if (cookieIdacc == null )
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
            return View();
        }

        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            string key = "Idacc";
            string value = "";
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Append(key, value, cookieOptions);

            return RedirectToAction("index");

        }
    }



}

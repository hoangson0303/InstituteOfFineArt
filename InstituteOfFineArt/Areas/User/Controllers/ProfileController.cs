
using InstituteOfFineArt.Areas.User.Services;
using InstituteOfFineArt.Models;
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
using System.Threading.Tasks;

namespace InstituteOfFineArt.Controllers
{
    [Area("user")]
    [Route("profile")]
    [Route("user/profile")]
    public class ProfileController : Controller
    {
        private ProfileService ProfileService;
        private IWebHostEnvironment webHostEnvironment;

        public ProfileController(ProfileService _profileService, IWebHostEnvironment _webHostEnvironment)
        {
            ProfileService = _profileService;
            this.webHostEnvironment = _webHostEnvironment;
        }
        [Route("index")]
        [Route("")]
        public IActionResult Index(string idtest)
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = ProfileService.FindUserById(cookieIdacc);
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.infouser = ProfileService.FindUserById(cookieIdacc);
            ViewBag.test = ProfileService.FindUserByIdtest(cookieIdacc);
            return View();  
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult Update()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            return View("profileupdate", ProfileService.FindById(cookieIdacc));
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update(Account account, IFormFile file)
        {
            bool gender = Boolean.Parse(Request.Form["selectGender"]);
            if (ModelState.IsValid)
            {
                var currentAccount = ProfileService.FindById(account.IdAcc);
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var ext = file.ContentType.Split(new char[] { '/' })[1];
                var path = Path.Combine(webHostEnvironment.WebRootPath, "user/images", fileName + "." + ext);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                currentAccount.Avatar = fileName + "." + ext;
            }
            
            currentAccount.Fullname = account.Fullname;
            currentAccount.Email = account.Email;
            currentAccount.Dob = account.Dob;
            currentAccount.Gender = gender;
            currentAccount.PhoneNumber = account.PhoneNumber;
            currentAccount.Addr = account.Addr;
            currentAccount.Dateupdated = DateTime.Now;
            currentAccount.Stat = true;
            ProfileService.Update(currentAccount);
            return RedirectToAction("index");
            }
            return RedirectToAction("update");
        }
    }
}

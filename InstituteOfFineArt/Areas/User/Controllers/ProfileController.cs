
using InstituteOfFineArt.Areas.User.Services;
using InstituteOfFineArt.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public IActionResult Index()
        {
            ViewBag.infouser = ProfileService.FindUserById("student1");
            return View();  
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult Update()
        {
            return View("profileupdate", ProfileService.FindById("student1"));
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update(Account account, IFormFile file)
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
            currentAccount.Gender = account.Gender;
            currentAccount.PhoneNumber = account.PhoneNumber;
            currentAccount.Addr = account.Addr;
            currentAccount.Dateupdated = DateTime.Now;
            currentAccount.Stat = true;
            currentAccount.IdRole = "stu";
            ProfileService.Update(currentAccount);
            return RedirectToAction("index");
        }
    }
}

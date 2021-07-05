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

namespace InstituteOfFineArt.Areas.User.Controllers
{
    [Area("user")]
    [Route("profilecustomer")]
    [Route("user/profilecustomer")]
    public class ProfileCustomerController : Controller
    {
        private ProfileCustomerService profileCustomerService;
        private IWebHostEnvironment webHostEnvironment;

        public ProfileCustomerController(ProfileCustomerService _profileCustomerService, IWebHostEnvironment _webHostEnvironment)
        {
            profileCustomerService = _profileCustomerService;
            this.webHostEnvironment = _webHostEnvironment;
        }
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = profileCustomerService.FindUserById(cookieIdacc);
            return View();
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult Update()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = profileCustomerService.FindUserById(cookieIdacc);
            return View("profilecustomerupdate", profileCustomerService.FindById(cookieIdacc));
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update(Account account, IFormFile file)
        {
            bool gender = Boolean.Parse(Request.Form["selectGender"]);
            //if (ModelState.IsValid)
            //{
            var currentAccount = profileCustomerService.FindById(account.IdAcc);
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
            else
            {
                account.Avatar = "aaa.png";
            }

            currentAccount.Fullname = account.Fullname;
            currentAccount.Email = account.Email;
            currentAccount.Dob = account.Dob;
            currentAccount.Gender = gender;
            currentAccount.PhoneNumber = account.PhoneNumber;
            currentAccount.Addr = account.Addr;
            currentAccount.Dateupdated = DateTime.Now;
            currentAccount.Stat = true;
            profileCustomerService.Update(currentAccount);
            return RedirectToAction("index");

            //}
            //return RedirectToAction("update");
        }
    }
}

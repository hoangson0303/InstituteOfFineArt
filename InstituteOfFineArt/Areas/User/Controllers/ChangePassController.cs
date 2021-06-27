using InstituteOfFineArt.Areas.User.Services;
using InstituteOfFineArt.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Controllers
{
    [Area("user")]
    [Route("changepassword")]
    [Route("user/changepassword")]
    public class ChangePassController : Controller
    {
        private ChangePassService changePassService;
        private IWebHostEnvironment webHostEnvironment;

        public ChangePassController(ChangePassService _changePassService, IWebHostEnvironment _webHostEnvironment)
        {
            changePassService = _changePassService;
            this.webHostEnvironment = _webHostEnvironment;
        }

        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("index")]
        public IActionResult CheckPass(string oldPass)
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            Debug.WriteLine(oldPass);
            var currentAccount = changePassService.FindById(cookieIdacc);
            bool thispass = BCrypt.Net.BCrypt.Verify(oldPass, currentAccount.Pass);
            Debug.WriteLine(thispass);
            if(thispass != true)
            {
                return View("index", ViewBag.Error = "Wrong Password , please try again ! ");
            }
            else
            {
                return View("changepass");
            }
        }


        [HttpPost]
        [Route("ChangePass")]
        public IActionResult ChangePass(string newPass, string comFirmPass)
        {
            if(newPass == comFirmPass)
            {
                string cookieIdacc = Request.Cookies["Idacc"];
                var currentAccount = changePassService.FindById(cookieIdacc);
                currentAccount.Pass = BCrypt.Net.BCrypt.HashString(newPass);
                changePassService.Update(currentAccount);
                return View("changepass", ViewBag.msg = "Change Password Success ! ");
            }
            else
            {
                return View("changepass", ViewBag.msg = "Your new password and confirm password aren't the same ! ");
            }
            return View();
        }
    }
}

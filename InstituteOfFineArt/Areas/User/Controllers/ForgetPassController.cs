using InstituteOfFineArt.Areas.User.Services;
using InstituteOfFineArt.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace InstituteOfFineArt.Areas.User.Controllers
{
    [Area("user")]
    [Route("forgetpassword")]
    [Route("user/forgetpassword")]
    public class ForgetPassController : Controller
    {
        private ForgetPassService forgetPassService;
        private IWebHostEnvironment webHostEnvironment;

        public ForgetPassController(ForgetPassService _forgetPassService, IWebHostEnvironment _webHostEnvironment)
        {
            forgetPassService = _forgetPassService;
            this.webHostEnvironment = _webHostEnvironment;
        }

        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(string REmail)
        {
            var currentAccount = forgetPassService.FindByEmail(REmail);
            var newPass = forgetPassService.RandomPassword(20);
            try
            {
                if (ModelState.IsValid)
                {
                   var senderEmail = new MailAddress("instituteoffineart2001@gmail.com", "Institute Of Fine Art");
                    var recEmail = new MailAddress(REmail, REmail);
                    var password = "test03032001";
                    var sub = "RESET PASSWORD";
                    var body = "This is your new password , we just reset for you , PLEASE DON'T THIS FOR ANYONE ! : " + newPass + " " + "Contact us here -> " + senderEmail.Address;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };

                    using (var mess = new MailMessage(senderEmail, recEmail)
                    {
                        Subject = sub,
                        Body = body
                        
                    })
                    {
                        smtp.Send(mess);
                        ViewBag.msg = "Email sending success";
                    }

                    currentAccount.Pass = BCrypt.Net.BCrypt.HashString(newPass);
                    Debug.WriteLine(currentAccount.Pass);
                    forgetPassService.Update(currentAccount);
                    return RedirectToAction("index");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Email sending failed";
            }
            return RedirectToAction("index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;
using InstituteOfFineArt.Models;
using InstituteOfFineArt.Services;
using Microsoft.AspNetCore.Hosting;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace InstituteOfFineArt.Controllers
{
    [Route("contant")]
    public class ContactController : Controller
    {
        private ContactService contactService;
        private IWebHostEnvironment webHostEnvironment;

        public ContactController(ContactService _contactService, IWebHostEnvironment _webHostEnvironment)
        {
            contactService = _contactService;
            this.webHostEnvironment = _webHostEnvironment;
        }
        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMail(string REmail , Feedback feedback  , string Body , string Fullname, string password)
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            string Receiver = "instituteoffineart2001@gmail.com"; // người nhận 
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress(REmail, "USER"); // người gửi
                    var recEmail = new MailAddress(Receiver, Receiver); // người nhận
                    var sub = "USER'S FEEDBACK";
                    var body = "Fullname : " + Fullname + " ," + "Id account : " + cookieIdacc + ", " + "Message : " + Body;
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
                        Body = body,
                       
                    })
                    {
                        smtp.Send(mess);
                        ViewBag.msg = "Email sending success";
                    }


                    var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*)(?<Numeric>[0-9]*)");
                    int num = 0;
                    if (contactService.GetNewestId(sub) != null)
                    {
                        var match = numAlpha.Match(contactService.GetNewestId(Fullname));
                        //var alpha = match.Groups["Alpha"].Value;
                        num = Int32.Parse(match.Groups["Numeric"].Value);

                    }

                    feedback.Mail = REmail;
                    feedback.Mess = Body;
                    feedback.Datesend = DateTime.Now;
                    feedback.Stat = false;
                    feedback.IdAcc = cookieIdacc;

                    if (contactService.CountIdById(Fullname) != 0)
                    {
                        feedback.IdFeedback = Fullname + (num + 1);

                        contactService.Create(feedback);
                    }
                    else
                    {
                        feedback.IdFeedback = Fullname + 1;

                        contactService.Create(feedback);
                    }



                    //forgetPassService.Update(currentAccount);
                    return RedirectToAction("contact");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Email sending failed";
            }
            return RedirectToAction("contact");
        }

    }
}

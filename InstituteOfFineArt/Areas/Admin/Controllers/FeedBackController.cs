using InstituteOfFineArt.Areas.Admin.Services;
using InstituteOfFineArt.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("feedback")]
    [Route("admin/feedback")]
    public class FeedBackController : Controller
    {
        private FeedBackService feedBackService;
        private IWebHostEnvironment webHostEnvironment;

        public FeedBackController(FeedBackService _feedBackService, IWebHostEnvironment _webHostEnvironment)
        {
            feedBackService = _feedBackService;
            this.webHostEnvironment = _webHostEnvironment;
        }
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.feedback = feedBackService.FindALlFeedBack();
            return View();
        }

        [Route("reply/{idfeed}")]
        public IActionResult Reply( string idfeed, string desc)
        {
            var idAcc = feedBackService.FindIdAccByIdFeed(idfeed);
            var REmail = feedBackService.FindEmailByIdAcc(idAcc);
            var curentFeed = feedBackService.FindById(idfeed);
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("instituteoffineart2001@gmail.com", "Institute Of Fine Art");
                    var recEmail = new MailAddress(REmail, REmail);
                    var password = "test03032001";
                    var sub = "REPLY EMAIL";
                    var body = "Your Message : " + curentFeed.Mess + ". " + "A reply is : " + desc + ". " + "Date send is :" + curentFeed.Datereply + " " + "Contact us here --> " + senderEmail.Address;
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

                    curentFeed.ReplyMail = desc;
                    curentFeed.Datereply = DateTime.Now;
                    feedBackService.Update(curentFeed);
                    return RedirectToAction("index");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Email sending failed";
            }
            return RedirectToAction("index");
        }

        [Route("search")]

        public IActionResult Search([FromQuery(Name = "keyword")] string keyword)
        {
            ViewBag.feedback = feedBackService.Search(keyword);
            return View("index");
        }


    }
}

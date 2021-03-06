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
    [Route("contest")]
    [Route("admin/contest")]
    public class ContestController : Controller
    {
        private ContestService contestService;
        private IWebHostEnvironment webHostEnvironment;

        public ContestController(ContestService _contestService, IWebHostEnvironment _webHostEnvironment)
        {
            contestService = _contestService;
            this.webHostEnvironment = _webHostEnvironment;
        }


        [Route("contest")]
        public IActionResult Contest()
        {
            ViewBag.test = contestService.FindAll();
            return View();
        }

        [Route("delete/{idTest}")]
        public IActionResult Delete(string idtest, string desc)
        {
            var idAcc = contestService.FindIdAccByIdTest(idtest);
            var REmail = contestService.FindEmailByIdAcc(idAcc);
            var curentTest = contestService.FindById(idtest);
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("instituteoffineart2001@gmail.com", "Institute Of Fine Art");
                    var recEmail = new MailAddress(REmail, REmail);
                    var password = "test03032001";
                    var sub = "EMAIL REJECTION";
                    var body = "Test : " + curentTest.NameTest + ". " + "Created from date : " + curentTest.Datecreated + ". " + "Was rejected . Reason is : " + desc + ". " + "Contact us here --> " + senderEmail.Address;
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

                    contestService.Delete(idtest);
                    return RedirectToAction("contest");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Email sending failed";
            }
            return RedirectToAction("contest");

        }


        [Route("search")]

        public IActionResult Search([FromQuery(Name = "keyword")] string keyword)
        {
            ViewBag.test = contestService.Search(keyword);
            return View("contest");
        }



    }
    }

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
    [Route("event")]
    [Route("admin/event")]
    public class EventController : Controller
    {
        private ApprovalService ApprovalService;
        private EventService EventService;
        private IWebHostEnvironment webHostEnvironment;

        public EventController(ApprovalService _approvalService, EventService _eventService , IWebHostEnvironment _webHostEnvironment)
        {
            EventService = _eventService;
            ApprovalService = _approvalService;
            this.webHostEnvironment = _webHostEnvironment;
        }
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.comhappening = EventService.FindAll();
            return View();
        }

        [Route("approval")]
        public IActionResult Approval()
        {
            ViewBag.competition = ApprovalService.FindAll();
            return View("approval");
        }

        [HttpGet]
        [Route("accept/{id}")]
        public IActionResult Accept(string id)
        {
            return View("accept", ApprovalService.FindById(id));
        }

        [HttpPost]
        [Route("accept/{id}")]
        public IActionResult Accept(Competition competition)
        {
            var currentAccount = ApprovalService.FindById(competition.IdCom);
            currentAccount.Stat = true;
            ApprovalService.Update(currentAccount);
            return RedirectToAction("index");
        }

        [Route("delete/{idCom}")]
        public IActionResult Delete(string idCom, string desc)
        {
            var idAcc = ApprovalService.FindIdAccByIdCom(idCom);
            var REmail = ApprovalService.FindEmailByIdAcc(idAcc);
            var curentCompetition = ApprovalService.FindById(idCom);
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("instituteoffineart2001@gmail.com", "Institute Of Fine Art");
                    var recEmail = new MailAddress(REmail, REmail);
                    var password = "test03032001";
                    var sub = "EMAIL REJECTION";
                    var body = "Competition : " + curentCompetition.NameCom + ". " + "Created from date : " + curentCompetition.DateStart + ". " + "Was rejected . Reason is : " + desc + ". " + "Contact us here --> " + senderEmail.Address;
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

                    ApprovalService.Delete(idCom);
                    return RedirectToAction("index");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Email sending failed";
            }
            return RedirectToAction("approval");


        }


    }
}

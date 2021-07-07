using InstituteOfFineArt.Areas.User.Services;
using InstituteOfFineArt.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Controllers
{
    [Area("user")]
    [Route("contestmark")]
    [Route("user/contestmark")]
    public class ContestMarkController : Controller
    {
        private MarkContestService markContestService;
        private IWebHostEnvironment webHostEnvironment;

        public ContestMarkController(MarkContestService _markContestServicee, IWebHostEnvironment _webHostEnvironment)
        {
            markContestService = _markContestServicee;
            this.webHostEnvironment = _webHostEnvironment;
        }
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = markContestService.FindUserById(cookieIdacc);
            ViewBag.testcore = markContestService.FindAllTestCore();
            return View();
        }

        [HttpGet]
        [Route("mark/{idTest}")]
        public IActionResult Mark(string idTest)
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = markContestService.FindUserById(cookieIdacc);
            return View("mark", markContestService.FindTest(idTest));
        }

        [HttpPost]
        [Route("mark/{idTest}")]
        public IActionResult Mark(string descSchool ,string idTest )
        {
            int mark = Int32.Parse(Request.Form["selectMark"]);
            string RIdAcc = markContestService.FindIdAcc(idTest);
            string REmail = markContestService.EmailByIdAcc(RIdAcc);
            string idSchool = markContestService.FindIdSchool(idTest);
            string FullnameSchool = markContestService.FindFullnameSchool(idSchool);


            var currentTestCore = markContestService.FindById(idTest);
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("instituteoffineart2001@gmail.com", "UNIVERSITY !!!!");
                    var recEmail = new MailAddress(REmail, REmail);
                    var password = "test03032001";
                    var sub = "FROM UNIVERSITY";
                    var body = "From university : " + FullnameSchool + ". " + "Test : " + currentTestCore.IdTest + ". " + "Your score is :" + mark + " ." + "School comments : " + descSchool + " . " + "For more information, please visit the details of the registered exams on the wedsite . " + "Contact us here -->"  + senderEmail.Address;
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




                    currentTestCore.Scores = mark;
                    currentTestCore.Stat = true;
                    currentTestCore.Desc = descSchool;
                    currentTestCore.GradingDate = DateTime.Now;
                    markContestService.Update(currentTestCore);
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

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
    [Route("submission")]
    [Route("user/submission")]
    public class SubmissionController : Controller
    {
        private SubmissionService submissionService;
        private IWebHostEnvironment webHostEnvironment;
        private DatabaseContext db;

        public SubmissionController(SubmissionService _submissionService, IWebHostEnvironment _webHostEnvironment, DatabaseContext db)
        {
            submissionService = _submissionService;
            webHostEnvironment = _webHostEnvironment;
            this.db = db;
        }

        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            string idaccTest = submissionService.GetIdAcc();
            string idCom = submissionService.FindIdComByIdAcc(cookieIdacc);
            ViewBag.fullname = submissionService.GetFullnameByIdAcc(idaccTest);
            ViewBag.acc = submissionService.FindUserById(cookieIdacc);
            ViewBag.test = submissionService.FindAll(idCom);
            return View();
        }

        [HttpGet]
        [Route("accept/{id}")]
        public IActionResult Accept(string id)
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = submissionService.FindUserById(cookieIdacc);
            return View("accept", submissionService.FindById(id));
        }

        [HttpPost]
        [Route("accept/{id}")]
        public IActionResult Accept(Test test)
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = submissionService.FindUserById(cookieIdacc);
            var currentAccount = submissionService.FindById(test.IdTest);
            currentAccount.Stat = true;
            submissionService.Update(currentAccount);
            return RedirectToAction("index");
        }
    }
}

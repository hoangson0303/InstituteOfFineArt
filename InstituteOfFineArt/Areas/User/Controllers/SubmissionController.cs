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
            ViewBag.acc = submissionService.FindUserById(cookieIdacc);
            string idaccTest = submissionService.GetIdAcc();
            ViewBag.fullname = submissionService.GetFullnameByIdAcc(idaccTest);

            ViewBag.test = submissionService.FindAll(cookieIdacc);
            Debug.WriteLine("cookieIdacc : " + cookieIdacc);
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

        [Route("delete/{idTest}")]
        public IActionResult Delete(string idTest)
        {
            submissionService.Delete(idTest);
            return RedirectToAction("index");
        }

        [Route("search")]

        public IActionResult Search([FromQuery(Name = "keyword")] string keyword)
        {
            ViewBag.test = submissionService.Search(keyword);

            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = submissionService.FindUserById(cookieIdacc);
            string idaccTest = submissionService.GetIdAcc();
            ViewBag.fullname = submissionService.GetFullnameByIdAcc(idaccTest);
            return View("index");
        }
    }
}

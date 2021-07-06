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
    [Route("contestgoingon")]
    [Route("user/contestgoingon")]
    public class ContestGoingOnController : Controller
    {
        private ContestGoingOnService contestGoingOnService;
        private IWebHostEnvironment webHostEnvironment;
        private DatabaseContext db;

        public ContestGoingOnController(ContestGoingOnService _contestGoingOnService, IWebHostEnvironment _webHostEnvironment, DatabaseContext db)
        {
            contestGoingOnService = _contestGoingOnService;
            webHostEnvironment = _webHostEnvironment;
            this.db = db;
        }

        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            string cookieIdacc = Request.Cookies["Idacc"];

            

            string idaccTest = contestGoingOnService.GetIdAcc();
            ViewBag.score = contestGoingOnService.GetScore(cookieIdacc);
            ViewBag.fullname = contestGoingOnService.GetFullnameByIdAcc(idaccTest);
            ViewBag.testTrue = contestGoingOnService.FindAllTestTrue();

            ViewBag.acc = contestGoingOnService.FindUserById(cookieIdacc);
            return View();
        }

        [Route("delete/{idTest}")]
        public IActionResult Delete(string idTest)
        {
            contestGoingOnService.Delete(idTest);
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("mark/{idTest}")]
        public IActionResult Mark(string idTest)
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = contestGoingOnService.FindUserById(cookieIdacc);
            return View("mark" , contestGoingOnService.FindTest(idTest));
        }

        [HttpPost]
        [Route("mark/{idTest}")]
        public IActionResult Mark(TestCore testCore, string descSchool)
        {
            int mark = Int32.Parse(Request.Form["selectMark"]);
            if (ModelState.IsValid)
            {
                var currentTestCore = contestGoingOnService.FindById(testCore.IdTest);


                currentTestCore.Scores = mark;
                currentTestCore.Stat = true;
                currentTestCore.Desc = descSchool;
                currentTestCore.GradingDate = DateTime.Now;
                contestGoingOnService.Update(currentTestCore);
                return RedirectToAction("index");
            }
            return RedirectToAction("index");
        }

        [Route("search")]

        public IActionResult Search([FromQuery(Name = "keyword")] string keyword)
        {
            ViewBag.testTrue = contestGoingOnService.Search(keyword);

            string cookieIdacc = Request.Cookies["Idacc"];
            string idaccTest = contestGoingOnService.GetIdAcc();
            ViewBag.score = contestGoingOnService.GetScore(cookieIdacc);
            ViewBag.fullname = contestGoingOnService.GetFullnameByIdAcc(idaccTest);

            ViewBag.acc = contestGoingOnService.FindUserById(cookieIdacc);
            return View("index");
        }
    }
}

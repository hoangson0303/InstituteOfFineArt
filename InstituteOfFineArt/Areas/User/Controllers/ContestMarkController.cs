using InstituteOfFineArt.Areas.User.Services;
using InstituteOfFineArt.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Mark(TestCore testCore, string descSchool)
        {
            int mark = Int32.Parse(Request.Form["selectMark"]);
            if (ModelState.IsValid)
            {
                var currentTestCore = markContestService.FindById(testCore.IdTest);


                currentTestCore.Scores = mark;
                currentTestCore.Stat = true;
                currentTestCore.Desc = descSchool;
                currentTestCore.GradingDate = DateTime.Now;
                markContestService.Update(currentTestCore);
                return RedirectToAction("index");
            }
            return RedirectToAction("index");
        }
    }
}

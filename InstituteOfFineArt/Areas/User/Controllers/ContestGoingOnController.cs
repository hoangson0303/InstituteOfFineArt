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
            

            

            string idaccTest = contestGoingOnService.GetIdAcc();
            ViewBag.fullname = contestGoingOnService.GetFullnameByIdAcc(idaccTest);
            ViewBag.testTrue = contestGoingOnService.FindAllTestTrue();
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = contestGoingOnService.FindUserById(cookieIdacc);
            return View();
        }

        [Route("delete/{idTest}")]
        public IActionResult Delete(string idTest)
        {
            contestGoingOnService.Delete(idTest);
            return RedirectToAction("index");
        }




        [Route("search")]

        public IActionResult Search([FromQuery(Name = "keyword")] string keyword)
        {
            ViewBag.testTrue = contestGoingOnService.Search(keyword);

            string cookieIdacc = Request.Cookies["Idacc"];
            string idaccTest = contestGoingOnService.GetIdAcc();
            ViewBag.fullname = contestGoingOnService.GetFullnameByIdAcc(idaccTest);

            ViewBag.acc = contestGoingOnService.FindUserById(cookieIdacc);
            return View("index");
        }
    }
}

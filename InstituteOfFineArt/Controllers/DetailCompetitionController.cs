using InstituteOfFineArt.Models;
using InstituteOfFineArt.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Controllers
{
    [Route("DetailCompetition")]
    public class DetailCompetitionController : Controller
    {
        private DetailComService DetailComService;
        private IWebHostEnvironment webHostEnvironment;

        public DetailCompetitionController(DetailComService _detailComService, IWebHostEnvironment _webHostEnvironment)
        {
            DetailComService = _detailComService;
            this.webHostEnvironment = _webHostEnvironment;
        }
        [HttpGet]
        [Route("index/{idCom}")]
        public IActionResult Index(string idCom)
        {

            string cookieIdacc = Request.Cookies["Idacc"];
            string idacc = DetailComService.GetIdAccByIdCom(idCom);
            ViewBag.account = DetailComService.FindAccById(idacc);
            ViewBag.com = DetailComService.FindComById(idCom);
            ViewBag.test = DetailComService.FindTestById(cookieIdacc);
            return View();
        }

        [HttpPost]
        [Route("index/{idCom}")]    
        public IActionResult Index(Test tes, IFormFile file, string IdCom)
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = DetailComService.FindUserById(cookieIdacc);

            string idAccSchool = DetailComService.FindIdAccByIdCom(IdCom);

            var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*)(?<Numeric>[0-9]*)");
            int num = 0;
            if (DetailComService.GetNewestId(tes.NameTest) != null)
            {
                var match = numAlpha.Match(DetailComService.GetNewestId(tes.NameTest));
                //var alpha = match.Groups["Alpha"].Value;
                num = Int32.Parse(match.Groups["Numeric"].Value);

            }
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var ext = file.ContentType.Split(new char[] { '/' })[1];
                var path = Path.Combine(webHostEnvironment.WebRootPath, "user/images", fileName + "." + ext);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                tes.ImgOfTest = fileName + "." + ext;

            }
            else
            {
                tes.ImgOfTest = "aaa.png";
            }

            tes.Datecreated = DateTime.Now;
            tes.Stat = false;
            tes.IdAcc = cookieIdacc;
            tes.IdCom = IdCom;
            tes.StatusQuo = false;
            tes.IdSchool = idAccSchool;

            if (DetailComService.CountIdById(tes.NameTest) != 0)
            {
                tes.IdTest = tes.NameTest + (num + 1);
                string idTest = DetailComService.Create(tes).IdTest;

                var testCore = new TestCore();
                testCore.IdTest = idTest;
                testCore.IdCom = IdCom;
                testCore.GradingDate = DateTime.Now;
                testCore.Stat = false;
                testCore.IdSchool = idAccSchool;
                DetailComService.CreateTestCore(testCore);
            }
            else
            {
                tes.IdTest = tes.NameTest + 1;
                string idTest = DetailComService.Create(tes).IdTest;
                var testCore = new TestCore();
                testCore.IdTest = idTest;
                testCore.IdCom = IdCom;
                testCore.GradingDate = DateTime.Now;
                testCore.Stat = false;
                testCore.IdSchool = idAccSchool;
                DetailComService.CreateTestCore(testCore);
            }



            return RedirectToAction("student");
        }

        [Route("student")]
        public IActionResult Student()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = DetailComService.FindUserById(cookieIdacc);
            ViewBag.school = DetailComService.FindAllSchool();

            ViewBag.test = DetailComService.FindAllTest();
            ViewBag.compititions = DetailComService.FindAll();
            if (cookieIdacc == null)
            {
                ViewBag.loggedin = false;

            }
            return View("student");
        }


        [HttpGet]
        [Route("edit/{idtest}")]
        public IActionResult Edit(string id)
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.test = DetailComService.FindTestById(cookieIdacc);
            return View("edit", DetailComService.Find(id));
        }
        [Route("edit/{idtest}")]
        [HttpPost]
        public IActionResult Edit(Test test, IFormFile file)
        {

            var currentTest = DetailComService.Find(test.IdTest);
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var ext = file.ContentType.Split(new char[] { '/' })[1];
                var path = Path.Combine(webHostEnvironment.WebRootPath, "user/images", fileName + "." + ext);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                currentTest.ImgOfTest = fileName + "." + ext;
            }
            else
            {
                test.ImgOfTest = "aaa.png";
            }
            currentTest.NameTest = test.NameTest;
            currentTest.Desc = test.Desc;
            currentTest.Content = test.Content;
            currentTest.Price = test.Price;
            DetailComService.Update(currentTest);

            return RedirectToAction("student");
        }

       

        [Route("schooldetail/{idCom}")]

        public IActionResult Schooldetail(string idCom)
        {

            string cookieIdacc = Request.Cookies["Idacc"];
            string idacc = DetailComService.GetIdAccByIdCom(idCom);
            ViewBag.account = DetailComService.FindAccById(idacc);
            ViewBag.com = DetailComService.FindComById(idCom);
            ViewBag.test = DetailComService.FindTestById(cookieIdacc);
            return View();
        }

       [Route("schooldetailinformation/{idCom}")]
       public IActionResult Schooldetailinformation(string idCom)
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            string idacc = DetailComService.GetIdAccByIdCom(idCom);
            ViewBag.account = DetailComService.FindAccById(idacc);
            ViewBag.com = DetailComService.FindComById(idCom);
            ViewBag.test = DetailComService.FindTest();
            return View();
        }



        [Route("customerdetail/{idCom}")]

        public IActionResult Customerdetail(string idCom)
        {

            string cookieIdacc = Request.Cookies["Idacc"];
            string idacc = DetailComService.GetIdAccByIdCom(idCom);
            ViewBag.account = DetailComService.FindAccById(idacc);
            ViewBag.com = DetailComService.FindComById(idCom);
            ViewBag.test = DetailComService.FindTestById(cookieIdacc);
            return View();
        }

        [Route("cusdetailinformation/{idCom}")]
        public IActionResult Cusdetailinformation(string idCom)
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            string idacc = DetailComService.GetIdAccByIdCom(idCom);
            ViewBag.account = DetailComService.FindAccById(idacc);
            ViewBag.com = DetailComService.FindComById(idCom);
            ViewBag.test = DetailComService.FindTest();
            return View();
        }
    }
}

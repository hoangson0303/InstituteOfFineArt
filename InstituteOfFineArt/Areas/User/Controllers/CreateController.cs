using InstituteOfFineArt.Areas.User.Services;
using InstituteOfFineArt.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Controllers
{
    [Area("user")]
    [Route("create")]
    [Route("user/create")]
    public class CreateController : Controller
    {
        private CreateService createService;
        private IWebHostEnvironment webHostEnvironment;

        public CreateController(CreateService _createService, IWebHostEnvironment _webHostEnvironment)
        {
            createService = _createService;
            this.webHostEnvironment = _webHostEnvironment;
        }

        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.acc = createService.FindUserById(cookieIdacc);
            return View();
        }
        [Route("createadd")]
        [HttpGet]
        public IActionResult CreateAdd()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
                ViewBag.acc = createService.FindUserById(cookieIdacc);
            ViewBag.username = HttpContext.Session.GetString("username");
        


            return View("createadd");

        }
        [Route("createadd")]
        [HttpPost]
        public IActionResult CreateAdd(Competition competition, IFormFile file)
        {

            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = createService.FindUserById(cookieIdacc);

            var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*)(?<Numeric>[0-9]*)");
            int num = 0;
            if (createService.GetNewestId(competition.NameCom) != null)
            {
                var match = numAlpha.Match(createService.GetNewestId(competition.NameCom));
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
                competition.ImgOfCom = fileName + "." + ext;
            }
            else
            {
                competition.ImgOfCom = "aaa.png";
            }
            competition.Stat = false;
            competition.IdAcc = cookieIdacc;
            //var account = new Account();

            //if (createService.CountIdById(competition.NameCom) != 0)
            //{
            //    account.IdAcc = competition.NameCom + (num + 1);
            //    string idAcc = createService.Create(competition).IdAcc;
            //    competition.IdAcc = idAcc;
            //}
            //else
            //{
            //    account.IdAcc = competition.NameCom + 1;
            //    string idAcc = createService.Create(competition).IdAcc;
            //    competition.IdAcc = idAcc;
            //}





            if (createService.CountIdById(competition.NameCom) != 0)
            {
                competition.IdCom = competition.NameCom + (num + 1);

                createService.Create(competition);
            }
            else
            {
                competition.IdCom = competition.NameCom + 1;

                createService.Create(competition);
            }



            return RedirectToAction("table");
        }

        [Route("table")]

        public IActionResult Table()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.acc = createService.FindUserById(cookieIdacc);
            ViewBag.compititions = createService.FindAllComById(cookieIdacc);
            return View("table");
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult Update(string id)
        {
            //string cookieIdacc = Request.Cookies["Idacc"];
            //ViewBag.username = HttpContext.Session.GetString("username");
            //return View("update", createService.FindByIdcom(cookieIdacc));
            return View("update", createService.FindCom(id));
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update(Competition competition, IFormFile file)
        {
            var compi = createService.FindCom(competition.IdCom);
           
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var ext = file.ContentType.Split(new char[] { '/' })[1];
                var path = Path.Combine(webHostEnvironment.WebRootPath, "user/images", fileName + "." + ext);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                compi.ImgOfCom = fileName + "." + ext;

            }
            compi.Stat = false;
            compi.Desc = competition.Desc;
            compi.NameCom = competition.NameCom;
            compi.DateStart = competition.DateStart;
            compi.DateEnd = competition.DateEnd;
            createService.Update(compi);
            return RedirectToAction("table");
        }

        [Route("delete/{idCom}")]
        public IActionResult Delete(string idCom)
        {
            createService.Delete(idCom);
            return RedirectToAction("table");
        }
    }
}

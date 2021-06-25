using InstituteOfFineArt.Models;
using InstituteOfFineArt.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            string idacc = DetailComService.GetIdAccByIdCom(idCom);
            ViewBag.account = DetailComService.FindAccById(idacc);
            ViewBag.com = DetailComService.FindComById(idCom);
            return View();
        }






        [Route("add")]
        [HttpPost]
        public IActionResult Add(Test tes)
        {
            string cookieIdacc = Request.Cookies["Idacc"];
                ViewBag.acc = DetailComService.FindUserById(cookieIdacc);

                var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*)(?<Numeric>[0-9]*)");
                int num = 0;
                if (DetailComService.GetNewestId(tes.NameTest) != null)
                {
                    var match = numAlpha.Match(DetailComService.GetNewestId(tes.NameTest));
                    //var alpha = match.Groups["Alpha"].Value;
                    num = Int32.Parse(match.Groups["Numeric"].Value);

                }
            tes.Datecreated = DateTime.Now;
            tes.Stat = false;
                tes.IdAcc = cookieIdacc;
              
                if (DetailComService.CountIdById(tes.NameTest) != 0)
                {
                    tes.IdTest = tes.NameTest + (num + 1);

                    DetailComService.Create(tes);
                }
                else
                {
                    tes.IdTest = tes.NameTest + 1;

                    DetailComService.Create(tes);
                }



                return RedirectToAction("index");
        }
   
    }
}

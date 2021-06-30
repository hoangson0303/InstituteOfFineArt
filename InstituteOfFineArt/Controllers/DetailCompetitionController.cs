﻿using InstituteOfFineArt.Models;
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

            string idacc = DetailComService.GetIdAccByIdCom(idCom);
            ViewBag.account = DetailComService.FindAccById(idacc);
            ViewBag.com = DetailComService.FindComById(idCom);
            return View();
        }

        [HttpPost]
        [Route("index/{idCom}")]    
        public IActionResult Index(Test tes, IFormFile file, string IdCom)
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
            tes.IdTest = IdCom;

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



            return RedirectToAction("student");
        }

        [Route("student")]
        public IActionResult Student()
        {
            ViewBag.compititions = DetailComService.FindAll();
            string cookieIdacc = Request.Cookies["Idacc"];
            if (cookieIdacc == null)
            {
                ViewBag.loggedin = false;

            }
            if (HttpContext.User.IsInRole("admin"))
            {
                ViewBag.role = "admin";
            }
            if (HttpContext.User.IsInRole("student"))
            {
                ViewBag.role = "student";
            }
            if (HttpContext.User.IsInRole("school"))
            {
                ViewBag.role = "school";
            }
            ViewBag.username = HttpContext.Session.GetString("username");
            return View("student");
        }
    }
}

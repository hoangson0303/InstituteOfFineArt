﻿using InstituteOfFineArt.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            ViewBag.com = DetailComService.FindComById(idCom);
            return View();
        }
    }
}
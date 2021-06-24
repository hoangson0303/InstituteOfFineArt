using InstituteOfFineArt.Areas.Admin.Services;
using InstituteOfFineArt.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("event")]
    [Route("admin/event")]
    public class EventController : Controller
    {
        private ApprovalService ApprovalService;
        private IWebHostEnvironment webHostEnvironment;

        public EventController(ApprovalService _approvalService, IWebHostEnvironment _webHostEnvironment)
        {
            ApprovalService = _approvalService;
            this.webHostEnvironment = _webHostEnvironment;
        }
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("approval")]
        public IActionResult Approval()
        {
            ViewBag.competition = ApprovalService.FindAll();
            return View("approval");
        }

        [HttpGet]
        [Route("accept/{idAcc}")]
        public IActionResult Accept(string idCom)
        {
            return View("accept", ApprovalService.FindById(idCom));
        }

        [HttpPost]
        [Route("accept/{idAcc}")]
        public IActionResult Accept(Competition competition)
        {
            var currentAccount = ApprovalService.FindById(competition.IdCom);
            currentAccount.Stat = true;
            ApprovalService.Update(currentAccount);
            return RedirectToAction("index");
        }
    }
}

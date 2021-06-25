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
        private EventService EventService;
        private IWebHostEnvironment webHostEnvironment;

        public EventController(ApprovalService _approvalService, EventService _eventService , IWebHostEnvironment _webHostEnvironment)
        {
            EventService = _eventService;
            ApprovalService = _approvalService;
            this.webHostEnvironment = _webHostEnvironment;
        }
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.comhappening = EventService.FindAll();
            return View();
        }

        [Route("approval")]
        public IActionResult Approval()
        {
            ViewBag.competition = ApprovalService.FindAll();
            return View("approval");
        }

        [HttpGet]
        [Route("accept/{id}")]
        public IActionResult Accept(string id)
        {
            return View("accept", ApprovalService.FindById(id));
        }

        [HttpPost]
        [Route("accept/{id}")]
        public IActionResult Accept(Competition competition)
        {
            var currentAccount = ApprovalService.FindById(competition.IdCom);
            currentAccount.Stat = true;
            ApprovalService.Update(currentAccount);
            return RedirectToAction("index");
        }
    }
}

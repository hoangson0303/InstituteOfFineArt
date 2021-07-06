using InstituteOfFineArt.Areas.User.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Controllers
{
    [Area("user")]
    [Route("showtest")]
    [Route("user/showtest")]
    public class ShowtestController : Controller
    {
        private ShowtestService showtestService;
        private IWebHostEnvironment webHostEnvironment;

        public ShowtestController(ShowtestService _showtestService, IWebHostEnvironment _webHostEnvironment)
        {
            showtestService = _showtestService;
            this.webHostEnvironment = _webHostEnvironment;
        }

        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = showtestService.FindUserById(cookieIdacc);
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.infouser = showtestService.FindUserById(cookieIdacc);
            ViewBag.testcore = showtestService.FindAll();
            return View();
        }

        [Route("search")]

        public IActionResult Search([FromQuery(Name = "keyword")] string keyword)
        {
            ViewBag.test = showtestService.Search(keyword);
            return View("index");
        }
    }
}

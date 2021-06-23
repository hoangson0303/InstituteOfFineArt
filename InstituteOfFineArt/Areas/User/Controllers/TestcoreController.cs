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
    [Route("test")]
    [Route("user/test")]
    public class TestcoreController : Controller
    {
        private TestcoreService tescoretService;
        private IWebHostEnvironment webHostEnvironment;

        public TestcoreController(TestcoreService _testcoreService, IWebHostEnvironment _webHostEnvironment)
        {
            tescoretService = _testcoreService;
            this.webHostEnvironment = _webHostEnvironment;
        }

        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.acc = tescoretService.FindUserById(cookieIdacc);

            //ViewBag.testcore = tescoretService.FindUserByIdCom( );

            return View();
        }
    }
}

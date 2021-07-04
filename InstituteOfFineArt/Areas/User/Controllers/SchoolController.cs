using InstituteOfFineArt.Areas.User.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Controllers
{
    [Area("user")]
    [Route("school")]
    [Route("user/school")]
    public class SchoolController : Controller
    {
        private SchoolService schoolService;
        private IWebHostEnvironment webHostEnvironment;

        public SchoolController(SchoolService _schoolService, IWebHostEnvironment _webHostEnvironment)
        {
            schoolService = _schoolService;
            this.webHostEnvironment = _webHostEnvironment;
        }

        [Route("school")]
        [Route("")]
        public IActionResult School()
        {
            ViewBag.compititions = schoolService.FindAll();
            ViewBag.username = HttpContext.Session.GetString("username"); // lấy tên người đăng nhập 
            return View("school");
        }

        [Route("index/{idCom}")]
        public IActionResult Index(string idCom)
        {

            string cookieIdacc = Request.Cookies["Idacc"];
            string idacc = schoolService.GetIdAccByIdCom(idCom);
            ViewBag.account = schoolService.FindAccById(idacc);
            ViewBag.com = schoolService.FindComById(idCom);
            ViewBag.test = schoolService.FindTestById(cookieIdacc);
            return View();
        }
    }
}

using InstituteOfFineArt.Areas.User.Services;
using InstituteOfFineArt.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
          
            ViewBag.username = HttpContext.Session.GetString("username");
            return View();
        }

  

        [Route("createadd")]
        [HttpGet]
        public IActionResult CreateAdd()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.idacc = HttpContext.Session.GetString("idacc");
            return View("createadd");

        }
        [Route("createadd")]
        [HttpPost]
        public IActionResult CreateAdd(Competition competition, IFormFile file)
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            ViewBag.idacc = HttpContext.Session.GetString("idacc");
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var ext = file.ContentType.Split(new char[] { '/' })[1];
                var path = Path.Combine(webHostEnvironment.WebRootPath, "user/imgaes", fileName + "." + ext);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                competition.ImgOfCom = fileName + "." + ext;
            }
           



            competition.Stat = true;
            //competition.IdAcc = competition.IdCom;
            //string idAcc = createService.Create(competition).IdAcc;
            //var userRole = new UserRole();
            //    userRole.IdAcc = idAcc;

            createService.Create(competition);
            return RedirectToAction("index");
        }
    }
}

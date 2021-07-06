using InstituteOfFineArt.Areas.User.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Controllers
{
    [Area("user")]
    [Route("loginhistory")]
    [Route("user/loginhistory")]
    public class LoginHistoryController : Controller
    {
        private LoginHistoryService loginHistoryService;
        private IWebHostEnvironment webHostEnvironment;

        public LoginHistoryController(LoginHistoryService _loginHistoryService, IWebHostEnvironment _webHostEnvironment)
        {
            loginHistoryService = _loginHistoryService;
            webHostEnvironment = _webHostEnvironment;
        }
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = loginHistoryService.FindUserById(cookieIdacc);
            ViewBag.loginhistory = loginHistoryService.FindLoginHistory(cookieIdacc);
            return View();
        }
    }
}

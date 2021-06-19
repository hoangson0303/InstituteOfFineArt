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
        [Route("school")]
        public IActionResult School()
        {
            //string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.username = HttpContext.Session.GetString("username"); // lấy tên người đăng nhập 
            return View("school");
        }
    }
}

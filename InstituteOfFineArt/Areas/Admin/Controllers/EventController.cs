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
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("approval")]
        public IActionResult Approval()
        {
            return View("approval");
        }
    }
}

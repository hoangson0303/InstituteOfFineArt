using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Admin.Controllers
{
    [Area("admin")]
    [Route("dashboard")]
    [Route("admin/dashboard")]
    public class DashboardController : Controller
    {
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

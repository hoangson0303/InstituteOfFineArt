using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("submission")]
    [Route("admin/submission")]
    public class SubmissionController : Controller
    {
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

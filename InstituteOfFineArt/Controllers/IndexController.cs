using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Controllers
{
    [Route("index")]
    public class IndexController : Controller
    {
        [Route("index")]
        [Route("~/")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

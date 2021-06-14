using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Controllers
{
    [Route("about")]
    public class AboutController : Controller
    {
        [Route("about")]

        public IActionResult About()
        {
            return View();
        }
    }
}

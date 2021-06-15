using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Controllers
{
    [Route("school")]
    public class SchoolController : Controller
    {
        [Route("school")]
        public IActionResult School()
        {
            return View();
        }
    }
}

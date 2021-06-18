using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Controllers
{
    [Route("userprofile")]
    public class ProfileController : Controller
    {
        [Route("index")]
        public IActionResult UserProfile()
        {
            return View("index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("comment")]
    [Route("admin/comment")]
    public class CommentController : Controller
    {
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

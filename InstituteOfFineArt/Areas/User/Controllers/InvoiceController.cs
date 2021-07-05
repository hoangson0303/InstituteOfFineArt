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
    [Route("invoice")]
    [Route("user/invoice")]
    public class InvoiceController : Controller
    {
        private InvoiceService InvoiceService;
        private IWebHostEnvironment webHostEnvironment;

        public InvoiceController(InvoiceService _invoiceService, IWebHostEnvironment _webHostEnvironment)
        {
            InvoiceService = _invoiceService;
            this.webHostEnvironment = _webHostEnvironment;
        }
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = InvoiceService.FindUserById(cookieIdacc);
            ViewBag.detailBill = InvoiceService.AllBillByIdAcc(cookieIdacc);
            return View();
        }
    }
}

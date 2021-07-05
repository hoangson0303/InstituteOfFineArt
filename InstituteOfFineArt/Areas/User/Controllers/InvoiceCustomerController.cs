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
    [Route("invoicecustomer")]
    [Route("user/invoicecustomer")]
    public class InvoiceCustomerController : Controller
    {
        private InvoiceCustomerService InvoiceSchoolService;
        private IWebHostEnvironment webHostEnvironment;

        public InvoiceCustomerController(InvoiceCustomerService _invoiceSchoolService, IWebHostEnvironment _webHostEnvironment)
        {
            InvoiceSchoolService = _invoiceSchoolService;
            this.webHostEnvironment = _webHostEnvironment;
        }
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = InvoiceSchoolService.FindUserById(cookieIdacc);

            string idAccSeller = InvoiceSchoolService.FindIdAccSellerByIdAcc(cookieIdacc);
            ViewBag.from = InvoiceSchoolService.FindFromByIdAccSeller(idAccSeller);
            ViewBag.detailBill = InvoiceSchoolService.FindBillByIdAccPayer(cookieIdacc);
            return View();
        }
    }
}

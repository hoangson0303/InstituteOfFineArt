
using InstituteOfFineArt.Models;
using InstituteOfFineArt.Paypal;
using InstituteOfFineArt.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Controllers
{
    [Route("index")]
    public class IndexController : Controller
    {

        const string IdTest = "";

        private IndexService indexService;
        private ReviewService reviewService;
        private IConfiguration configuration;
        private IWebHostEnvironment webHostEnvironment;
        

        public IndexController(IndexService _indexService, ReviewService _reviewService ,IWebHostEnvironment _webHostEnvironment, IConfiguration _configuration)
        {
            indexService = _indexService;
            reviewService = _reviewService;
            configuration = _configuration;
            this.webHostEnvironment = _webHostEnvironment;
        }
        [Route("index")]
        [Route("")]
        [Route("~/")]
        public IActionResult Index()
        {
            ViewBag.school = indexService.FindAllSchool();
            ViewBag.compititions = indexService.FindAll();
            ViewBag.test = indexService.FindAllTest();

            string cookieIdacc = Request.Cookies["Idacc"];
            if (cookieIdacc != null)
            {
                string idRole = indexService.FindIdRole(cookieIdacc).ToString();
                string nameRole = indexService.FindNameRole(idRole).ToString();
                if (nameRole == "admin")
                {

                    ViewBag.acc = indexService.FindUserById(cookieIdacc);
                    return RedirectToAction("admin");
                }
                if (nameRole == "student")
                {
                    ViewBag.acc = indexService.FindUserById(cookieIdacc);
                    return RedirectToAction("student");
                }
                if (nameRole == "school")
                {
                    ViewBag.acc = indexService.FindUserById(cookieIdacc);
                    return RedirectToAction("school");
                }
            }
            else
            {
                ViewBag.acc = indexService.FindUserById(cookieIdacc);
                Debug.WriteLine(cookieIdacc);
                if (cookieIdacc == null)
                {
                    ViewBag.loggedin = false;

                }
            }



            return View();
        }

        [Route("login")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            string key = "Idacc";
            string value = "";
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Append(key, value, cookieOptions);

            return View("login");

        }

        [Route("student")]
        public IActionResult Student()
        {
            ViewBag.school = indexService.FindAllSchool();
            ViewBag.compititions = indexService.FindAll();
            ViewBag.test = indexService.FindAllTest();
            string cookieIdacc = Request.Cookies["Idacc"];
            if (cookieIdacc == null)
            {
                ViewBag.loggedin = false;

            }
            ViewBag.acc = indexService.FindUserById(cookieIdacc);
            return View("student");
        }

        [Route("admin")]
        public IActionResult Admin()
        {
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = indexService.FindUserById(cookieIdacc);

            return View("admin");
        }

        [Route("school")]
        public IActionResult School()
        {

            ViewBag.school = indexService.FindAllSchool();
            ViewBag.compititions = indexService.FindAll();
            ViewBag.test = indexService.FindAllTest();
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = indexService.FindUserById(cookieIdacc);
            if (cookieIdacc == null)
            {
                ViewBag.loggedin = false;

            }

            return View("school");
        }


        [Route("review/{idTest}")]
        public IActionResult Review(string idTest)
        {
            ViewBag.test = reviewService.FindTestById(idTest);
            ViewBag.postUrl = configuration["Paypal:PostUrl"];
            ViewBag.business = configuration["Paypal:Business"];
            ViewBag.returnUrl = configuration["Paypal:ReturnUrl"];
            HttpContext.Session.SetString(IdTest, idTest);
            return View("review");
        }

        [Route("success")]
        public IActionResult Success(Bill bill, [FromQuery(Name = "tx")] string tx)
        {
            string idTest = HttpContext.Session.GetString(IdTest);
            string cookieIdacc = Request.Cookies["Idacc"];
            ViewBag.acc = indexService.FindUserById(cookieIdacc);
            var result = PDTHolder.Success(tx, configuration, Request);

            bill.IdBill = result.TransactionId;
            bill.Created = DateTime.Now;
            bill.IdAcc = cookieIdacc;
            bill.Total = (decimal?)result.GrossTotal;
            indexService.CreateBill(bill);

            var detailBill = new DetailBill();
            detailBill.IdBill = result.TransactionId;
            detailBill.IdTest = idTest;
            detailBill.ProductName = result.ItemName;
            detailBill.PayerName = result.PayerFirstName + " " + result.PayerLastName;
            detailBill.PayerEmail = result.PayerEmail;
            detailBill.PayerShippingAddr = "";
            detailBill.Type = "Payment form";
            detailBill.Payment = result.PaymentStatus;
            detailBill.Total = (decimal?)result.GrossTotal;
            detailBill.Fee = (decimal?)result.PaymentFee;
            detailBill.Net = (decimal?)result.GrossTotal - (decimal?)result.PaymentFee;
            detailBill.Created = DateTime.Now;
            indexService.CreateDetailBill(detailBill);


            
            return  View("success");
        }
    }



}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;
using InstituteOfFineArt.Models;

namespace InstituteOfFineArt.Controllers
{
    [Route("contant")]
    public class ContactController : Controller
    {
        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Contact(Email em)
        //{
        //    string to = em.To;
        //    string subject = em.Subject;
        //    string body = em.Body;
        //    MailMessage mm = new MailMessage();
        //    mm.To.Add(to);
        //    mm.Subject = subject;
        //    mm.Body = body;
        //    mm.From = new MailAddress("trannhatcuong1318@gmail.com");
        //    mm.IsBodyHtml = false;
        //    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
        //    smtp.Port = 570;
        //    smtp.UseDefaultCredentials = true;
        //    smtp.EnableSsl = true;
        //    smtp.Credentials = new System.Net.NetworkCredential("trannhatcuong1318@gmail.com", "password");
        //    smtp.Send(mm);
        //    ViewBag.message = "The Mail Has Been Sent To " + em.To + "Succeccfully..!";

        //    return View();
        //}
    }
}

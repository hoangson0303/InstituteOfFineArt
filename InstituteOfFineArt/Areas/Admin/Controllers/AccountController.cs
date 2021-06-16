using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstituteOfFineArt.Areas.Admin.Services;
using InstituteOfFineArt.Models;
using System.Text.RegularExpressions;

namespace InstituteOfFineArt.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("account")]
    [Route("admin/account")]
    public class AccountController : Controller
    {
        private AccountService AccountService;
        private IWebHostEnvironment webHostEnvironment;

        public AccountController(AccountService _accountService, IWebHostEnvironment _webHostEnvironment)
        {
            AccountService = _accountService;
            this.webHostEnvironment = _webHostEnvironment;
        }
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.accounts = AccountService.FindAll();
            ViewBag.listRoles = AccountService.GetAllRole();
            return View();

        }

        [HttpPost]
        [Route("add")]  
        public IActionResult Add(Account account)
        {
            string nameRole = Request.Form["selectRole"];
            string idRole = AccountService.GetIdRoleByNameRol(nameRole);
            var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*)(?<Numeric>[0-9]*)");
            int num = 0;
            if (AccountService.GetNewestId(nameRole) != null)
            {
                var match = numAlpha.Match(AccountService.GetNewestId(nameRole));
                //var alpha = match.Groups["Alpha"].Value;
                num = Int32.Parse(match.Groups["Numeric"].Value);

            }

            account.Datecreated = DateTime.Now;
            account.Dateupdated = DateTime.Now;
            account.Pass = BCrypt.Net.BCrypt.HashString(account.Pass);
            account.Stat = true;


            if (AccountService.CountIdById(nameRole) != 0)
            {
                account.IdAcc = nameRole + (num + 1);
                string idAcc = AccountService.CreateAccount(account).IdAcc;

                var userRole = new UserRole();
                userRole.IdAcc = idAcc;
                userRole.IdRole = idRole;
                userRole.Datecreated = DateTime.Now;
                userRole.Dateupdated = DateTime.Now;

                AccountService.CreateUserRole(userRole);
            }
            else
            {
                account.IdAcc = nameRole + 1;
                string idAcc = AccountService.CreateAccount(account).IdAcc;
                var userRole = new UserRole();
                userRole.IdAcc = idAcc;
                userRole.IdRole = idRole;
                userRole.Datecreated = DateTime.Now;
                userRole.Dateupdated = DateTime.Now;
                AccountService.CreateUserRole(userRole);
            }


            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("delete/{idAcc}")]
        public IActionResult Delete(string idAcc)
        {
            return View("delete", AccountService.FindById(idAcc));
        }

        [HttpPost]
        [Route("delete/{idAcc}")]
        public IActionResult Delete(Account account)
        {
            var currentAccount = AccountService.FindById(account.IdAcc);
            currentAccount.Stat = false;
            AccountService.Update(currentAccount);
            return RedirectToAction("index");
        }


        [HttpGet]
        [Route("update/{id}")]
        public IActionResult Update(string id)
        {

            return View("update", AccountService.FindById(id));
        }

        [HttpPost]
        [Route("update/{id}")]
        public IActionResult Update(Account account)
        {
            var currentAccount = AccountService.FindById(account.IdAcc);
            currentAccount.Email = account.Email;
            currentAccount.Fullname = account.Fullname;
            currentAccount.Dob = account.Dob;
            currentAccount.Gender = account.Gender;
            currentAccount.Avatar = account.Avatar;
            currentAccount.PhoneNumber = account.PhoneNumber;
            currentAccount.Addr = account.Addr;
            currentAccount.ContestsParticipated = null;
            currentAccount.Dateupdated = DateTime.Now;
            currentAccount.Stat = true;
            currentAccount.IdRole = "stu";
            AccountService.Update(currentAccount);
            return RedirectToAction("index");
        }
    }
}

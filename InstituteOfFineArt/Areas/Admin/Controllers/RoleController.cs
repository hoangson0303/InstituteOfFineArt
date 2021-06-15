using InstituteOfFineArt.Areas.Admin.Services;
using InstituteOfFineArt.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("role")]
    [Route("admin/role")]
    public class RoleController : Controller
    {
        private RoleService Roleservice;
        private IWebHostEnvironment webHostEnvironment;

        public RoleController(RoleService _roleservice, IWebHostEnvironment _webHostEnvironment)
        {
            Roleservice = _roleservice;
            this.webHostEnvironment = _webHostEnvironment;
        }
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            List<Role> role = Roleservice.FindAll();
            ViewBag.roles = role;
            List<UserRole> userRole = Roleservice.FindAllRoleUser();
            ViewBag.userRoles = userRole;
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Role role)
        {
            var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*)(?<Numeric>[0-9]*)");
            int num = 0;
            if (Roleservice.GetNewestId(role.NameRole) != null)
            {
                var match = numAlpha.Match(Roleservice.GetNewestId(role.NameRole));
                //var alpha = match.Groups["Alpha"].Value;
                num = Int32.Parse(match.Groups["Numeric"].Value);

            }

            role.Datecreated = DateTime.Now;
            role.Dateupdated = DateTime.Now;
            role.Stat = true;

            if (Roleservice.CountIdById(role.NameRole) != 0)
            {
                role.IdRole = role.NameRole + (num + 1);
                Roleservice.Create(role);
            }
            else
            {
                role.IdRole = role.NameRole + 1;
                Roleservice.Create(role);
            }


            return RedirectToAction("index");

        }

        [Route("delete/{idRole}")]
        public IActionResult Delete(string idRole)
        {
            Roleservice.Delete(idRole);
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult Update(string id)
        {

            return View("update", Roleservice.FindById(id));
        }
    }
}

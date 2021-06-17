
using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public interface LoginService
    {
        Account Login(string username, string password);

        Account Find(string username);

        Role FindRole(string idAcc);

        Account FindIdByUsername(string username);



    }
}

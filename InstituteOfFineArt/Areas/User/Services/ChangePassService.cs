using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public interface ChangePassService
    {
        Account FindById(string idAcc);

        Account Update(Account account);
    }
}

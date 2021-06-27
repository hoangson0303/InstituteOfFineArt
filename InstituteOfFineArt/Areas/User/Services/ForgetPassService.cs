using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public interface ForgetPassService
    {
        string RandomPassword(int number);

        Account FindByEmail(string email);
        Account Update(Account account);
    }
}

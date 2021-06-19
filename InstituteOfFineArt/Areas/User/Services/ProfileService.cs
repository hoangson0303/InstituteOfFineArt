using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public interface ProfileService
    {
        public List<Account> FindUserById(string idAcc);

        Account FindById(string idAcc);
        Account Update(Account account);
    }
}

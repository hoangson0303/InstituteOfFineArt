using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public interface ProfileService
    {

        string GetIdRoleByNameRol(string nameRole);
        Account FindById(string idAcc);
        public List<Account> FindUserById(string idAcc);

        public List<Test> FindUserByIdtest(string idtest);
        Account Update(Account account);
    }
}

using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Services
{
    public interface AccountService
    {
        public List<Account> FindAll();
        List<Role> GetAllRole();
        string GetIdRoleByNameRol(string nameRole);

        string GetNewestId(string keyword);

        int CountIdById(string id);
        Account CreateAccount(Account account);

        void CreateUserRole(UserRole userRole);

        Account FindById(string idAcc);
        Account Update(Account account);
        Account Delete(Account account);

        string FindByEmail(string email);

        List<Account> Search(string keyword);
    }
}

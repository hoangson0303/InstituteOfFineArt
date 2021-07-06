
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
        string Find(string username);

        string Pass(string username);

        string FindIdRole(string idAcc);

        string FindNameRole(string idRole);

        string FindIdByUsername(string username);


        List<Competition> FindAll();

        List<Competition> FindAllNextCom();


        Test Create(Test tes);
        public List<Account> FindUserById(string idAcc);
        string GetNewestId(string keyword);
        int CountIdById(string id);


        List<Test> FindAllTest();

        List<Account> FindAllSchool();

        Account Created(Account account);

        Account FindByEmail(string email);

        Role CreateRole(Role role);

        string GetIdRoleByNameRol(string nameRole);

        void CreateUserRole(UserRole userRole);
    }
}

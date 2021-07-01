using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Services
{
    public interface IndexService
    {
        List<Competition> FindAll();

        List<Test> FindAllTest();

        List<Account> FindAllSchool();
        public List<Account> FindUserById(string idAcc);

        string FindIdRole(string idAcc);

        string FindNameRole(string idRole);
    }
}

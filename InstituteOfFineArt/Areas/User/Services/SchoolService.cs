using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public interface SchoolService
    {
        List<Competition> FindAll();
        string GetIdAccByIdCom(string idCom);

        public List<Account> FindAccById(string idAcc);

        public List<Competition> FindComById(string idCom);
        public List<Test> FindTestById(string idTest);
    }
}

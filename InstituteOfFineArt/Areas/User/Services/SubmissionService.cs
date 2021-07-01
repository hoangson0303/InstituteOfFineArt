using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public interface SubmissionService
    {
        List<Test> FindAll(string idCom);
        public List<Account> FindUserById(string idAcc);

        string  GetIdAcc();
        string GetFullnameByIdAcc(string idAcc);

        string FindIdComByIdAcc(string idAcc);

        Test FindById(string idTest);

        Test Update(Test test);
    }
}

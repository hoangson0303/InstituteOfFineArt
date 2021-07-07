using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public interface MarkContestService
    {
        public List<Account> FindUserById(string idAcc);
        Test FindTest(string id);

        TestCore FindById(string idAcc);

        TestCore Update(TestCore testCore);

        List<TestCore> FindAllTestCore();

        string FindIdAcc(string idTest);

        string EmailByIdAcc(string idAcc);

        string FindIdSchool(string idTest);
        string FindFullnameSchool(string idSchool);
    }
}

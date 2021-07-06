using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public interface ContestGoingOnService
    {
        List<Test> FindAllTestTrue();
        string GetIdAcc();
        string GetFullnameByIdAcc(string idAcc);

        public List<Account> FindUserById(string idAcc);

        public void Delete(string idTest);

        TestCore FindById(string idAcc);

        TestCore Update(TestCore testCore);

        Test FindTest(string id);

        string GetIdTest(string idAcc);

        string FindIdAccByIdCom(string idCom);

        List<Test> Search(string keyword);
    }
}

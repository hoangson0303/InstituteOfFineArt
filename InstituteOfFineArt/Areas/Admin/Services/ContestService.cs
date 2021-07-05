using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Services
{
    public interface ContestService
    {
        List<Test> FindAll();

        public string FindIdAccByIdTest(string idTest);

        public string FindEmailByIdAcc(string idAcc);
        Account FindByEmail(string email);

        Test FindById(string idtest);

        Test Update(Test test);


        public List<Competition> FindCom();

        public void Delete(string idtest);
        
    }
}

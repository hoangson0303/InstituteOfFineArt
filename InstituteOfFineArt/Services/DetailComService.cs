using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Services
{
    public interface DetailComService
    {
        Competition FindById(string idCom);
        public List<Competition> FindComById(string idCom);
        public List<Account> FindAccById(string idAcc);

        string GetIdAccByIdCom(string idCom);

        Test Create(Test tes);
        public List<Account> FindUserById(string idAcc);
        string GetNewestId(string keyword);
        int CountIdById(string id);
        List<Competition> FindAll();

        List<Test> FindAllTest();

        List<Account> FindAllSchool();

        void CreateTestCore(TestCore testCore);

        public List<Test> FindTestById(string idTest);

        //public Test FindTestById(string idacc);

        Test Find(string id);

        Test Update(Test test);

        string FindIdAccByIdCom(string idCom);


        List<Test> FindTest();
    }
}

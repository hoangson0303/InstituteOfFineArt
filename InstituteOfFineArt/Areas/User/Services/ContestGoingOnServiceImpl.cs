using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public class ContestGoingOnServiceImpl : ContestGoingOnService
    {
        private DatabaseContext db;

        public ContestGoingOnServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }
        public List<Test> FindAllTestTrue()
        {
            return db.Tests.Where(x => x.Stat == true).ToList();
        }

        public string GetFullnameByIdAcc(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).Select(x => x.Fullname).FirstOrDefault();
        }

        public string GetIdAcc()
        {
            return db.Tests.Where(x => x.IdAcc != null).Select(x => x.IdAcc).FirstOrDefault();
        }
        public List<Account> FindUserById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }

        public void Delete(string idTest)
        {
            db.Tests.Remove(db.Tests.Find(idTest));
            db.SaveChanges();
        }

        public TestCore FindById(string idTest)
        {
            return db.TestCores.FirstOrDefault(x => x.IdTest == idTest);
        }

        public TestCore Update(TestCore testCore)
        {
            db.Entry(testCore).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return testCore;
        }
        public Test FindTest(string id)
        {
            return db.Tests.Find(id);
        }

        public string GetIdTest(string idAcc)
        {
            return db.Tests.Where(x => x.IdAcc == idAcc).Select(x => x.IdTest).FirstOrDefault();
        }

        public List<TestCore> GetScore(string idSchool)
        {
            return db.TestCores.Where(x => x.IdSchool == idSchool).ToList();
        }

        public string FindIdAccByIdCom(string idCom)
        {
            return db.Competitions.Where(x => x.IdCom == idCom).Select(x => x.IdAcc).FirstOrDefault();
        }

        public List<Test> Search(string keyword)
        {
            return db.Tests.Where(a => a.IdTest.Contains(keyword) && a.Stat == true).ToList();
        }
    }
}

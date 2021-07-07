using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public class MarkContestServiceImpl : MarkContestService
    {
        private DatabaseContext db;

        public MarkContestServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }
        public List<Account> FindUserById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }

        public Test FindTest(string id)
        {
            return db.Tests.Find(id);
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

        public List<TestCore> FindAllTestCore()
        {
            return db.TestCores.ToList();
        }

        public string FindIdAcc(string idTest)
        {
            return db.Tests.Where(x => x.IdTest == idTest).Select(x => x.IdAcc).FirstOrDefault();
        }

        public string EmailByIdAcc(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).Select(x => x.Email).FirstOrDefault();
        }

        public string FindIdSchool(string idTest)
        {
            return db.TestCores.Where(x => x.IdTest == idTest).Select(x => x.IdSchool).FirstOrDefault();
        }

        public string FindFullnameSchool(string idSchool)
        {
            return db.Accounts.Where(x => x.IdAcc == idSchool).Select(x => x.Fullname).FirstOrDefault();
        }
    }
}

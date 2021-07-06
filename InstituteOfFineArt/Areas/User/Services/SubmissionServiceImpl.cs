using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public class SubmissionServiceImpl : SubmissionService
    {
        private DatabaseContext db;

        public SubmissionServiceImpl(DatabaseContext db)
        {
            this.db = db;
        }
        public List<Test> FindAll(string idAcc)
        {
            return db.Tests.Where(x => x.IdSchool == idAcc && x.Stat == false).ToList();
        }

        public List<Account> FindUserById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }

        public string GetFullnameByIdAcc(string idAcc)
        {
            return db.Accounts.Where(x =>x.IdAcc == idAcc).Select(x => x.Fullname).FirstOrDefault();
        }

        public string GetIdAcc()
        {
            return db.Tests.Where(x => x.IdAcc != null).Select(x => x.IdAcc).FirstOrDefault();
        }

        public Test Update(Test test)
        {
            db.Entry(test).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return test;
        }

        public Test FindById(string idTest)
        {
            return db.Tests.SingleOrDefault(p => p.IdTest == idTest);
        }

        public string FindIdComByIdAcc(string idAcc)
        {
            return db.Competitions.Where(x => x.IdAcc == idAcc).Select(x => x.IdCom).FirstOrDefault();
        }

        public List<Test> Search(string keyword)
        {
            return db.Tests.Where(a => a.IdTest.Contains(keyword) && a.Stat == false).ToList();
        }

    }
}

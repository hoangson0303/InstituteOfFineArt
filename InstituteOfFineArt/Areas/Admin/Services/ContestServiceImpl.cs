using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Services
{
    public class ContestServiceImpl : ContestService
    {
        private DatabaseContext db;

        public ContestServiceImpl(DatabaseContext db)
        {
            this.db = db;
        }
        public List<Test> FindAll()
        {
            return db.Tests.Where(p => p.Stat == true).ToList();
           // return db.Tests.ToList();
        }
        public string FindIdAccByIdTest(string idTest)
        {
            return db.Tests.Where(x => x.IdTest == idTest).Select(x => x.IdAcc).FirstOrDefault();
        }
        public string FindEmailByIdAcc(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).Select(x => x.Email).FirstOrDefault();
        }
        public Account FindByEmail(string email)
        {
            return db.Accounts.FirstOrDefault(x => x.Email == email);
        }

        public Test FindById(string idtest)
        {
            return db.Tests.SingleOrDefault(p => p.IdTest == idtest);
        }

        public Test Update(Test test)
        {
            db.Entry(test).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return test;
        }

        public List<Competition> FindCom()
        {
            return db.Competitions.Where(p => p.Stat == true && p.DateEnd >= DateTime.Now).ToList();
        }

        public void Delete(string idtest)
        {
            db.Tests.Remove(db.Tests.Find(idtest));
            db.SaveChanges();
        }


        public List<Test> Search(string keyword)
        {
            return db.Tests.Where(a => a.IdTest.Contains(keyword) && a.Stat == true).ToList();
        }


    }
}

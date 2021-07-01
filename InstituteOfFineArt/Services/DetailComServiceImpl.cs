using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Services
{
    public class DetailComServiceImpl : DetailComService
    {
        private DatabaseContext db;

        public DetailComServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }

        public Test Create(Test tes)
        {
            db.Tests.Add(tes);
            db.SaveChanges();
            return tes;
        }
        public List<Account> FindUserById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }
        public string GetNewestId(string keyword)
        {
            return (from accounts in db.Accounts
                    where
                      accounts.IdAcc.Contains(keyword)
                    orderby
                      accounts.IdAcc descending
                    select accounts.IdAcc).Take(1).SingleOrDefault();
        }
        public int CountIdById(string id)
        {
            return db.Accounts.Where(p => p.IdAcc.Contains(id)).Count();
        }
        public List<Account> FindAccById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }

        public Competition FindById(string idCom)
        {
            return db.Competitions.SingleOrDefault(p => p.IdCom == idCom);
        }

        public List<Competition> FindComById(string idCom)
        {
            return db.Competitions.Where(x => x.IdCom == idCom).ToList();
        }



        public string GetIdAccByIdCom(string idCom)
        {
            return db.Competitions.Where(x => x.IdCom == idCom).Select(x => x.IdAcc).FirstOrDefault();
        }

     
        public List<Competition> FindAll()
        {
            return db.Competitions.ToList();
        }
        public List<Test> FindAllTest()
        {
            return db.Tests.Where(p => p.Stat == true).ToList();
        }

        public List<Account> FindAllSchool()
        {
            return db.Accounts.Where(p => p.IdRole == "school1").ToList();
        }

        public void CreateTestCore(TestCore testCore)
        {
            db.TestCores.Add(testCore);
            db.SaveChanges();
        }

        public List<Test> FindTestById(string idTest)
        {
            return db.Tests.Where(x => x.IdAcc == idTest).ToList();
        }

        //public Test FindTestById(string idacc)
        //{
        //    return db.Tests.Where(x => x.IdAcc == idacc).SingleOrDefault(x => x.Stat == true);
        //}

        public Account FindByIdAcc(string idAcc)
        {
            return db.Accounts.FirstOrDefault(x => x.IdAcc == idAcc);
        }
        public Test Find(string id)
        {
            return db.Tests.Find(id);
        }

        public Test Update(Test test)
        {
            db.Entry(test).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return test;
        }
    }
}

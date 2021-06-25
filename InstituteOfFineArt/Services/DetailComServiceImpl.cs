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
    }
}

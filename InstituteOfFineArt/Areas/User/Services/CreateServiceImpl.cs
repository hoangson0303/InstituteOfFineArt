using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public class CreateServiceImpl : CreateService
    {
        private DatabaseContext db;

        public CreateServiceImpl(DatabaseContext db)
        {
            this.db = db;
        }

        public int CountIdById(string id)
        {
            return db.Accounts.Where(p => p.IdAcc.Contains(id)).Count();
        }

        public Competition Create(Competition competition)
        {
            db.Competitions.Add(competition);
            db.SaveChanges();
            return competition;
        }

        public Account Createe(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public string Find(string username)
        {
            return db.Accounts.Where(u => u.Username == username).Select(x => x.Username).FirstOrDefault();
        }



        public string FindByIdacc(string idacc)
        {
            return db.Accounts.Where(u => u.Username == idacc).Select(x => x.IdAcc).FirstOrDefault();
        }

        public List<Competition> FindAll()
        {
            return db.Competitions.ToList();
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
        public List<Account> FindUserById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }
    }
}

using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public class ShowtestServiceImpl : ShowtestService
    {
        private DatabaseContext db;

        public ShowtestServiceImpl(DatabaseContext db)
        {
            this.db = db;
        }

        public List<TestCore> FindAll()
        {
            return db.TestCores.ToList();
        }
        public List<Account> FindUserById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }

        public List<TestCore> Search(string keyword)
        {
            return db.TestCores.Where(a => a.IdTest.Contains(keyword)).ToList();
        }
    }
}

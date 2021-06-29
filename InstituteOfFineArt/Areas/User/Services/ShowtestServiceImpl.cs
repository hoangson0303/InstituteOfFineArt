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

        public List<Test> FindAll()
        {
            return db.Tests.ToList();
        }
        public List<Account> FindUserById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }
    }
}

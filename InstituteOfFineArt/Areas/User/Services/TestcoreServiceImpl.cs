using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public class TestcoreServiceImpl : TestcoreService
    {
        private DatabaseContext db;

        public TestcoreServiceImpl(DatabaseContext db)
        {
            this.db = db;
        }

        public List<TestCore> FindUserByIdCom(string idCom)
        {
            return db.TestCores.Where(x => x.IdCom == idCom).ToList();
        }

        public List<Account> FindUserById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }
    }
}

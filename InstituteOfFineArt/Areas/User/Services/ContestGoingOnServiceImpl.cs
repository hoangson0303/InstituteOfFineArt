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
    }
}

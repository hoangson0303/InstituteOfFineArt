using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public class ProfileServiceImpl : ProfileService
    {

        private DatabaseContext db;

        public ProfileServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }

        public List<Account> FindUserById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }

        public Account FindById(string idAcc)
        {
            return db.Accounts.FirstOrDefault(x => x.IdAcc == idAcc);
        }

        public Account Update(Account account)
        {
            db.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return account;
        }
    }
}

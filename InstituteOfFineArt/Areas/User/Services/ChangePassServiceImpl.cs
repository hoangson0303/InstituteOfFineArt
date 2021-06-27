using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public class ChangePassServiceImpl : ChangePassService
    {
        private DatabaseContext db;

        public ChangePassServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
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

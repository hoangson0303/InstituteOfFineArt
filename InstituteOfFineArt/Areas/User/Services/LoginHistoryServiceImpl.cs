using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public class LoginHistoryServiceImpl : LoginHistoryService
    {
        private DatabaseContext db;

        public LoginHistoryServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }
        public List<LoginHistory> FindLoginHistory(string idAcc)
        {
            return db.LoginHistories.Where(x => x.IdAcc == idAcc).ToList();
        }
        public List<Account> FindUserById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }
    }
}

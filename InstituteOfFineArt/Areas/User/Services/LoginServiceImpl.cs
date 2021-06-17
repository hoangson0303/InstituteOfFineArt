using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{

    public class LoginServiceImpl : LoginService
    {
        private DatabaseContext db;

        public LoginServiceImpl(DatabaseContext db)
        {
            this.db = db;
        }

  

        public Account Find(string username)
        {
            return db.Accounts.SingleOrDefault(a => a.Username == username);
        }

        public string FindIdByUsername(string username)
        {
            return db.Accounts.Where(a => a.Username == username).Select(x => x.IdAcc).FirstOrDefault();
        }

        public string FindIdRole(string idAcc)
        {
            return db.UserRoles.Where(r => r.IdAcc == idAcc).Select(x => x.IdRole).FirstOrDefault();
        }

        public string FindNameRole(string idRole)
        {
            return db.Roles.Where(n => n.IdRole == idRole).Select(x => x.NameRole).FirstOrDefault();
        }

        public Account Login(string username, string password )
        {
            var account = Find(username);
            if (account != null )
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.Pass))
                {
                    return account;
                }
                return account;
            }
            return null;
        }

    }
}

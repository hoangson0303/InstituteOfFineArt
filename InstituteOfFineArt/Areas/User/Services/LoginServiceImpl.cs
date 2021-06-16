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

      

        public Account Login(string username, string password )
        {
            var account = db.Accounts.SingleOrDefault(a => a.Username == username);
            if (account != null)
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

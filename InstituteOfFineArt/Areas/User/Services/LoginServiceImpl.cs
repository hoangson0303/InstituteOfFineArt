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

        public Account FindIdByUsername(string username)
        {
            return db.Accounts.SingleOrDefault(a => a.IdAcc == username);
        }

        public Role FindRole(string idAcc)
        {
            return db.Roles.SingleOrDefault(r => r.IdRole == idAcc);
        }

        public Account Login(string username, string password )
        {
            var account = Find(username);
           // string idAcc = FindIdByUsername(username).ToString();
           // var idRole = FindRole(idAcc);
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

        public Account Create(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }
        //public Account GetAccount(string email)
        //{
        //    return db.Accounts.SingleOrDefault(p => p.Email == email);
        //}

        //public string GetRole(string idRole)
        //{
        //    return (from roles in db.Roles
        //            where
        //              roles.IdRole == idRole
        //            select
        //                roles.NameRole
        //           ).Take(1).SingleOrDefault();
        //}


    }
}

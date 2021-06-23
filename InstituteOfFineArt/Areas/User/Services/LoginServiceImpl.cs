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


        public List<Competition> FindAll()
        {
            return db.Competitions.ToList();
        }
        public string Find(string username)
        {
            return db.Accounts.Where(u => u.Username == username).Select(x => x.Username).FirstOrDefault();
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

        public string Pass(string username)
        {
            return db.Accounts.Where(u => u.Username == username).Select(x => x.Pass).FirstOrDefault();
        }
    }
}

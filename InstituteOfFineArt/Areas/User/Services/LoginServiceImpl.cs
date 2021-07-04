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
        public Account Login(string username, string password)
        {
            var account = db.Accounts.SingleOrDefault(a => a.Username == username);
            // var account = Find(username);

            if (account != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.Pass))
                {
                    return account;
                }
            }
            return null;
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
        public Test Create(Test tes)
        {
            db.Tests.Add(tes);
            db.SaveChanges();
            return tes;
        }
        public List<Account> FindUserById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }
        public string GetNewestId(string keyword)
        {
            return (from accounts in db.Accounts
                    where
                      accounts.IdAcc.Contains(keyword)
                    orderby
                      accounts.IdAcc descending
                    select accounts.IdAcc).Take(1).SingleOrDefault();
        }
        public int CountIdById(string id)
        {
            return db.Accounts.Where(p => p.IdAcc.Contains(id)).Count();
        }

        public List<Test> FindAllTest()
        {
            return db.Tests.Where(p => p.Stat == true).ToList();
        }

        public List<Account> FindAllSchool()
        {
            return db.Accounts.Where(p => p.IdRole == "school1").ToList();
        }

        public Account Created(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public Account FindByEmail(string email)
        {
            return db.Accounts.FirstOrDefault(x => x.Email == email);
        }

        public Role CreateRole(Role role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
            return role;
        }

        public string GetIdRoleByNameRol(string nameRole)
        {
            return db.Roles.Where(p => p.NameRole == nameRole).Select(x => x.IdRole).FirstOrDefault();
        }

        public void CreateUserRole(UserRole userRole)
        {
            db.UserRoles.Add(userRole);
            db.SaveChanges();
        }
    }
}

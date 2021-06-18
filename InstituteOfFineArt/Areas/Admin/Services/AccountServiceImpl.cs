﻿using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Services
{
    public class AccountServiceImpl : AccountService
    {
        private DatabaseContext db;

        public AccountServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }

        public int CountIdById(string id)
        {
            return db.Accounts.Where(p => p.IdAcc.Contains(id)).Count();
        }

        public Account CreateAccount(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public void CreateUserRole(UserRole userRole)
        {
            db.UserRoles.Add(userRole);
            db.SaveChanges();
        }

        public Account Delete(Account account)
        {
            db.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return account;
        }

        public List<Account> FindAll()
        {
            return db.Accounts.Where(p => p.Stat == true).ToList();
        }

        public Account FindById(string idAcc)
        {
            return db.Accounts.SingleOrDefault(p => p.IdAcc == idAcc);
        }

        public List<Role> GetAllRole()
        {
                return db.Roles.ToList();
        }

        public string GetIdRoleByNameRol(string nameRole)
        {
            return db.Roles.Where(p => p.NameRole == nameRole).Select(x => x.IdRole).FirstOrDefault();
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

        public Account Update(Account account)
        {
            db.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return account;
        }

        //public Account Create(Account account)
        //{
        //    db.Accounts.Add(account);
        //    db.SaveChanges();
        //    return account;
        //}
        //public Account Signup(string username, string password)
        //{
        //    var account = db.Accounts.SingleOrDefault(a => a.Username == username);
        //    if (account != null)
        //    {
        //        if (BCrypt.Net.BCrypt.Verify(password, account.Pass))
        //        {
        //            return account;
        //        }
        //    }
        //    return null;
        //}
    }
}

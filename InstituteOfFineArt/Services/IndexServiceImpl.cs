﻿using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Services
{
    public class IndexServiceImpl : IndexService
    {
        private DatabaseContext db;

        public IndexServiceImpl(DatabaseContext db)
        {
            this.db = db;
        }
        public List<Competition> FindAll()
        {
            return db.Competitions.Where(x => x.DateEnd >= DateTime.Now).ToList();
        }
        public List<Test> FindAllTest()
        {
            return db.Tests.Where(p => p.Stat == true).ToList();
        }

        public List<Account> FindAllSchool()
        {
            return db.Accounts.Where(p => p.IdRole == "school1").ToList();
        }
        public List<Account> FindUserById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }

        public string FindIdRole(string idAcc)
        {
            return db.UserRoles.Where(r => r.IdAcc == idAcc).Select(x => x.IdRole).FirstOrDefault();
        }

        public string FindNameRole(string idRole)
        {
            return db.Roles.Where(n => n.IdRole == idRole).Select(x => x.NameRole).FirstOrDefault();
        }

        public Bill CreateBill(Bill bill)
        {
            db.Bills.Add(bill);
            db.SaveChanges();
            return bill;
        }

        public DetailBill CreateDetailBill(DetailBill detailBill)
        {
            db.DetailBills.Add(detailBill);
            db.SaveChanges();
            return detailBill;
        }
    }
}

using InstituteOfFineArt.Models;
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
    }
}

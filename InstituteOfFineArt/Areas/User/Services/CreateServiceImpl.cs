using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public class CreateServiceImpl : CreateService
    {
        private DatabaseContext db;

        public CreateServiceImpl(DatabaseContext db)
        {
            this.db = db;
        }

        public Competition Create(Competition competition)
        {
            db.Competitions.Add(competition);
            db.SaveChanges();
            return competition;
        }

        public string Find(string username)
        {
            return db.Accounts.Where(u => u.Username == username).Select(x => x.Username).FirstOrDefault();
        }

        public string FindByIdacc(string idacc)
        {
            return db.Accounts.Where(u => u.Username == idacc).Select(x => x.IdAcc).FirstOrDefault();
        }

       
    }
}

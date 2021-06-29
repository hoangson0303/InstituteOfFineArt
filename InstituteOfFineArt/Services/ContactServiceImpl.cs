using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Services
{
    public class ContactServiceImpl : ContactService
    {
        private DatabaseContext db;

        public ContactServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }

        public Feedback Create(Feedback feedback)
        {
            db.Feedbacks.Add(feedback);
            db.SaveChanges();
            return feedback;
        }


        public int CountIdById(string id)
        {
            return db.Accounts.Where(p => p.IdAcc.Contains(id)).Count();
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

    }
}

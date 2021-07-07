using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Services
{
    public class FeedBackServiceImpl : FeedBackService
    {
        private DatabaseContext db;

        public FeedBackServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }
        public List<Feedback> FindALlFeedBack()
        {
            return db.Feedbacks.ToList();
        }

        public string FindIdAccByIdFeed(string idFeed)
        {
            return db.Feedbacks.Where(x => x.IdFeedback == idFeed).Select(x => x.IdAcc).FirstOrDefault();
        }
        public string FindEmailByIdAcc(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).Select(x => x.Email).FirstOrDefault();
        }
        public Feedback FindById(string idFeed)
        {
            return db.Feedbacks.SingleOrDefault(p => p.IdFeedback == idFeed);
        }

        public Feedback Update(Feedback feedback)
        {
            db.Entry(feedback).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return feedback;
        }

        public List<Feedback> Search(string keyword)
        {
            return db.Feedbacks.Where(a => a.IdFeedback.Contains(keyword)).ToList();
        }
    }
}

using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Services
{
    public class ApprovalServiceImpl : ApprovalService
    {
        private DatabaseContext db;

        public ApprovalServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }

        public void Delete(string idCom)
        {
            db.Competitions.Remove(db.Competitions.Find(idCom));
            db.SaveChanges();
        }

        public List<Competition> FindAll()
        {
            return db.Competitions.Where(p => p.Stat == false).ToList();
        }

        public Account FindByEmail(string email)
        {
            return db.Accounts.FirstOrDefault(x => x.Email == email);
        }

        public Competition FindById(string idCom)
        {
            return db.Competitions.SingleOrDefault(p => p.IdCom == idCom);
        }

        public string FindEmailByIdAcc(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).Select(x => x.Email).FirstOrDefault();
        }

        public string FindIdAccByIdCom(string idCom)
        {
            return db.Competitions.Where(x => x.IdCom == idCom).Select(x => x.IdAcc).FirstOrDefault();
        }

        public Competition Update(Competition competition)
        {
            db.Entry(competition).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return competition;
        }
    }
}

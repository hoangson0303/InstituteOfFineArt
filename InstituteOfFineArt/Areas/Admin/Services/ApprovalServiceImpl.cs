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

      

        public List<Competition> FindAll()
        {
            return db.Competitions.Where(p => p.Stat == false).ToList();
        }

        public Competition FindById(string idCom)
        {
            return db.Competitions.SingleOrDefault(p => p.IdCom == idCom);
        }

        public Competition Update(Competition competition)
        {
            db.Entry(competition).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return competition;
        }
    }
}

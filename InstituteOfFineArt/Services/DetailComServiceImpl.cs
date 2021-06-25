using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Services
{
    public class DetailComServiceImpl : DetailComService
    {
        private DatabaseContext db;

        public DetailComServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }

        public List<Account> FindAccById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }

        public Competition FindById(string idCom)
        {
            return db.Competitions.SingleOrDefault(p => p.IdCom == idCom);
        }

        public List<Competition> FindComById(string idCom)
        {
            return db.Competitions.Where(x => x.IdCom == idCom).ToList();
        }



        public string GetIdAccByIdCom(string idCom)
        {
            return db.Competitions.Where(x => x.IdCom == idCom).Select(x => x.IdAcc).FirstOrDefault();
        }
    }
}

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
        public Competition FindById(string idCom)
        {
            return db.Competitions.SingleOrDefault(p => p.IdCom == idCom);
        }

        public List<Competition> FindComById(string idCom)
        {
            return db.Competitions.Where(x => x.IdCom == idCom).ToList();
        }
    }
}

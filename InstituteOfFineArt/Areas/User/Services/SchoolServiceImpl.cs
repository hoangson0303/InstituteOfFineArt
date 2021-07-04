using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public class SchoolServiceImpl : SchoolService
    {
        private DatabaseContext db;

        public SchoolServiceImpl(DatabaseContext db)
        {
            this.db = db;
        }
        public List<Competition> FindAll()
        {
            return db.Competitions.ToList();
        }
        public string GetIdAccByIdCom(string idCom)
        {
            return db.Competitions.Where(x => x.IdCom == idCom).Select(x => x.IdAcc).FirstOrDefault();
        }

        public List<Account> FindAccById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }
        public List<Competition> FindComById(string idCom)
        {
            return db.Competitions.Where(x => x.IdCom == idCom).ToList();
        }
        public List<Test> FindTestById(string idTest)
        {
            return db.Tests.Where(x => x.IdAcc == idTest).ToList();
        }
    }
}

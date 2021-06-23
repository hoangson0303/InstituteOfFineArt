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
    }
}

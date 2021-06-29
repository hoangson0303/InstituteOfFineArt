using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public class ShowtestServiceImpl : ShowtestService
    {
        private DatabaseContext db;

        public ShowtestServiceImpl(DatabaseContext db)
        {
            this.db = db;
        }

        public List<Test> FindAll()
        {
            return db.Tests.ToList();
        }
    }
}

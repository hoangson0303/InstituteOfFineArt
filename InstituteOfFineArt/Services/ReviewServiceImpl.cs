using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Services
{
    public class ReviewServiceImpl : ReviewService
    {
        private DatabaseContext db;

        public ReviewServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }

        public List<Test> FindTestById(string idTest)
        {
            return db.Tests.Where(x => x.IdTest == idTest).ToList();
        }
    }
}

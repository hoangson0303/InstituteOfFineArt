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

        public string FindIdAccByIdTest(string idTest)
        {
            return db.Tests.Where(x => x.IdTest == idTest).Select(x => x.IdAcc).FirstOrDefault();
        }

        public string FindNameTestByIdTest(string idTest)
        {
            return db.Tests.Where(x => x.IdTest == idTest).Select(x => x.NameTest).FirstOrDefault();
        }

        public List<Test> FindTestById(string idTest)
        {
            return db.Tests.Where(x => x.IdTest == idTest).ToList();
        }
    }
}

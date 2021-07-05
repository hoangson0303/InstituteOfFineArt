using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Services
{
    public interface ReviewService
    {
        public List<Test> FindTestById(string idTest);

        string FindNameTestByIdTest(string idTest);

        string FindIdAccByIdTest(string idTest);
    }
}

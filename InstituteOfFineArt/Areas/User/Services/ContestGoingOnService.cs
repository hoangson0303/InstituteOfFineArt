using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public interface ContestGoingOnService
    {
        List<Test> FindAllTestTrue();
        string GetIdAcc();
        string GetFullnameByIdAcc(string idAcc);
        public List<Account> FindUserById(string idAcc);

        public void Delete(string idTest);
    }
}

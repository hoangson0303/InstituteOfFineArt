using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public interface ShowtestService
    {
        List<TestCore> FindAll();
        public List<Account> FindUserById(string idAcc);

        List<TestCore> Search(string keyword);
    }
}

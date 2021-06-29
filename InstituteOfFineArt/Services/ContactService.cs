using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Services
{
    public interface ContactService
    {
        Account FindByEmail(string email);
        Account FindByPass(string password);
        Feedback Create(Feedback feedback);


        public List<Account> FindUserById(string idAcc);

        int CountIdById(string id);

        string GetNewestId(string keyword);


  

    }
}

using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public interface CreateService
    {
        string Find(string username);


        Competition Create(Competition competition);
        Account Createe(Account account);

        string FindByIdacc(string idacc);


        List<Competition> FindAll();


        string GetNewestId(string keyword);
        int CountIdById(string id);
    }
}

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

        public List<Account> FindUserById(string idAcc);

        Competition Create(Competition competition);
        Account Createe(Account account);

        public void Delete(string idCom);


        string FindByIdacc(string idacc);


        public List<Competition> FindAllComById(string id);

        Account FindById(string idAcc);
        string GetNewestId(string keyword);
        int CountIdById(string id);

        Competition Update(Competition competition);

        Competition FindByIdcom(string idAcc);
        Competition FindCom(string id);



        List<Competition> Search(string keyword);

    }
}

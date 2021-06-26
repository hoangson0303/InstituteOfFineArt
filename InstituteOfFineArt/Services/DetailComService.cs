using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Services
{
    public interface DetailComService
    {
        Competition FindById(string idCom);
        public List<Competition> FindComById(string idCom);
        public List<Account> FindAccById(string idAcc);

        string GetIdAccByIdCom(string idCom);

        Test Create(Test tes);
        public List<Account> FindUserById(string idAcc);
        string GetNewestId(string keyword);
        int CountIdById(string id);
        List<Competition> FindAll();
    }
}

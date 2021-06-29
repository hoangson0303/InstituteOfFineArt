using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Services
{
    public interface ApprovalService
    {
        Account FindByEmail(string email);
        public List<Competition> FindAll();

        Competition FindById(string idCom);

        Competition Update(Competition competition);

        public void Delete(string idCom);

        public string FindIdAccByIdCom(string idCom);

        public string FindEmailByIdAcc(string idAcc);

    }
}

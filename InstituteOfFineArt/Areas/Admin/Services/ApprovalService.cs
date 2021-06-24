using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Services
{
    public interface ApprovalService
    {
        public List<Competition> FindAll();

        Competition FindById(string idCom);

        Competition Update(Competition competition);
    }
}

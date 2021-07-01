using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Services
{
    public interface EventService
    {
        public List<Competition> FindAll();
        Competition Update(Competition competition);

        Competition FindById(string idCom);

    }
}

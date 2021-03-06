using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public interface InvoiceService
    {
        List<DetailBill> AllBillByIdAcc(string idAcc);
        public List<Account> FindUserById(string idAcc);
    }
}

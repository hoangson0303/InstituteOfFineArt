using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public interface InvoiceCustomerService
    {
        
        string FindIdAccSellerByIdAcc(string idAccPayer);

        List<Account> FindFromByIdAccSeller(string idAccSeller);
        public List<Account> FindUserById(string idAcc);

        List<DetailBill> FindBillByIdAccPayer(string idAccPayer);
    }
}

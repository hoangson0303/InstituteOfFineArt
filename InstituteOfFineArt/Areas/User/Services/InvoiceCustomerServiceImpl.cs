using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public class InvoiceCustomerServiceImpl : InvoiceCustomerService
    {
        private DatabaseContext db;

        public InvoiceCustomerServiceImpl(DatabaseContext db)
        {
            this.db = db;
        }

        public List<DetailBill> FindBillByIdAccPayer(string idAccPayer)
        {
            return db.DetailBills.Where(x => x.IdAccPayer == idAccPayer).ToList();
        }

        public List<Account> FindFromByIdAccSeller(string idAccSeller)
        {
            return db.Accounts.Where(x => x.IdAcc == idAccSeller).ToList();
        }

        public string FindIdAccSellerByIdAcc(string idAccPayer)
        {
            return db.DetailBills.Where(x => x.IdAccPayer == idAccPayer).Select(x => x.IdAccSeller).FirstOrDefault();
        }

        public List<Account> FindUserById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }
    }
}

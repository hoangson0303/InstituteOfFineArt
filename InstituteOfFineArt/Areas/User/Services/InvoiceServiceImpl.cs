using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public class InvoiceServiceImpl : InvoiceService
    {
        private DatabaseContext db;

        public InvoiceServiceImpl(DatabaseContext db)
        {
            this.db = db;
        }
        public List<DetailBill> AllBillByIdAcc(string idAcc)
        {
            return db.DetailBills.Where(x => x.IdAccSeller == idAcc).ToList();
        }
        public List<Account> FindUserById(string idAcc)
        {
            return db.Accounts.Where(x => x.IdAcc == idAcc).ToList();
        }
    }
}

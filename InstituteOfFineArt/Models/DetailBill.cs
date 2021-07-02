using System;
using System.Collections.Generic;

#nullable disable

namespace InstituteOfFineArt.Models
{
    public partial class DetailBill
    {
        public string IdBill { get; set; }
        public string IdTest { get; set; }
        public string PayerFirstName { get; set; }
        public string PayerLastName { get; set; }
        public string PayerEmail { get; set; }
        public string PayerShippingAddr { get; set; }
        public string Payment { get; set; }
        public decimal? Total { get; set; }
        public DateTime? Created { get; set; }

        public virtual Bill IdBillNavigation { get; set; }
        public virtual Test IdTestNavigation { get; set; }
    }
}

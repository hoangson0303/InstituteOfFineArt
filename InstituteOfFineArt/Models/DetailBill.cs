using System;
using System.Collections.Generic;

#nullable disable

namespace InstituteOfFineArt.Models
{
    public partial class DetailBill
    {
        public string IdBill { get; set; }
        public string IdTest { get; set; }
        public string ProductName { get; set; }
        public string PayerName { get; set; }
        public string PayerEmail { get; set; }
        public string PayerShippingAddr { get; set; }
        public string Type { get; set; }
        public string Payment { get; set; }
        public decimal? Total { get; set; }
        public decimal? Fee { get; set; }
        public decimal? Net { get; set; }
        public DateTime? Created { get; set; }

        public virtual Bill IdBillNavigation { get; set; }
        public virtual Test IdTestNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace InstituteOfFineArt.Models
{
    public partial class OrderDetail
    {
        public string IdOrder { get; set; }
        public string IdTest { get; set; }
        public string NamePay { get; set; }
        public string Payment { get; set; }
        public decimal? Total { get; set; }
        public DateTime? Created { get; set; }

        public virtual Bill IdOrderNavigation { get; set; }
        public virtual Test IdTestNavigation { get; set; }
    }
}

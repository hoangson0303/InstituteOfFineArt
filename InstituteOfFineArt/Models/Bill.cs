using System;
using System.Collections.Generic;

#nullable disable

namespace InstituteOfFineArt.Models
{
    public partial class Bill
    {
        public Bill()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string IdOrder { get; set; }
        public string IdAcc { get; set; }
        public DateTime? Created { get; set; }
        public decimal? Total { get; set; }

        public virtual Account IdAccNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

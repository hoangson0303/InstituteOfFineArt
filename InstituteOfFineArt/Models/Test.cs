using System;
using System.Collections.Generic;

#nullable disable

namespace InstituteOfFineArt.Models
{
    public partial class Test
    {
        public Test()
        {
            Comments = new HashSet<Comment>();
            DetailBills = new HashSet<DetailBill>();
        }

        public string IdTest { get; set; }
        public string IdComment { get; set; }
        public string Content { get; set; }
        public string ImgOfTest { get; set; }
        public string NameTest { get; set; }
        public decimal? Price { get; set; }
        public string Desc { get; set; }
        public DateTime? Datecreated { get; set; }
        public DateTime? Dateupdated { get; set; }
        public bool? Stat { get; set; }
        public string IdCom { get; set; }
        public string IdAcc { get; set; }
        public string IdSchool { get; set; }
        public bool? StatusQuo { get; set; }

        public virtual Account IdAccNavigation { get; set; }
        public virtual TestCore TestCore { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<DetailBill> DetailBills { get; set; }
    }
}

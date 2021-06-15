using System;
using System.Collections.Generic;

#nullable disable

namespace InstituteOfFineArt.Models
{
    public partial class Competition
    {
        public Competition()
        {
            TestCores = new HashSet<TestCore>();
        }

        public string IdCom { get; set; }
        public string IdAcc { get; set; }
        public string NameCom { get; set; }
        public string Desc { get; set; }
        public string ImgOfCom { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? Stat { get; set; }

        public virtual Account IdAccNavigation { get; set; }
        public virtual ICollection<TestCore> TestCores { get; set; }
    }
}

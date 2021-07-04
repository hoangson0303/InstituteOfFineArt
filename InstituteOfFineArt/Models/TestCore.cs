using System;
using System.Collections.Generic;

#nullable disable

namespace InstituteOfFineArt.Models
{
    public partial class TestCore
    {
        public string IdCom { get; set; }
        public int? Scores { get; set; }
        public string Desc { get; set; }
        public bool? Stat { get; set; }
        public DateTime? GradingDate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string IdTest { get; set; }
        public string IdSchool { get; set; }

        public virtual Competition IdComNavigation { get; set; }
        public virtual Test IdTestNavigation { get; set; }
    }
}

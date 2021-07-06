using System;
using System.Collections.Generic;

#nullable disable

namespace InstituteOfFineArt.Models
{
    public partial class LoginHistory
    {
        public int IdLogin { get; set; }
        public string IdAcc { get; set; }
        public DateTime? DateLogin { get; set; }
        public string IpAddr { get; set; }

        public virtual Account IdAccNavigation { get; set; }
    }
}

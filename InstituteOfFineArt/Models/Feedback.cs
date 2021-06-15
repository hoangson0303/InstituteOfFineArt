using System;
using System.Collections.Generic;

#nullable disable

namespace InstituteOfFineArt.Models
{
    public partial class Feedback
    {
        public string IdFeedback { get; set; }
        public string Fullname { get; set; }
        public string Mail { get; set; }
        public string Mess { get; set; }
        public string ReplyMail { get; set; }
        public DateTime? Datesend { get; set; }
        public DateTime? Datereply { get; set; }
        public string IdAcc { get; set; }
        public bool? Stat { get; set; }

        public virtual Account IdAccNavigation { get; set; }
    }
}

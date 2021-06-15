using System;
using System.Collections.Generic;

#nullable disable

namespace InstituteOfFineArt.Models
{
    public partial class Comment
    {
        public string IdComment { get; set; }
        public string Mess { get; set; }
        public DateTime? Datecomment { get; set; }
        public bool? Stat { get; set; }
        public string IdAcc { get; set; }
        public string IdTest { get; set; }

        public virtual Account IdAccNavigation { get; set; }
        public virtual Test IdTestNavigation { get; set; }
    }
}

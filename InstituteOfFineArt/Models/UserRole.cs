using System;
using System.Collections.Generic;

#nullable disable

namespace InstituteOfFineArt.Models
{
    public partial class UserRole
    {
        public string IdRole { get; set; }
        public string IdAcc { get; set; }
        public DateTime? Datecreated { get; set; }
        public DateTime? Dateupdated { get; set; }

        public virtual Account IdAccNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
    }
}

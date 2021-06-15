using System;
using System.Collections.Generic;

#nullable disable

namespace InstituteOfFineArt.Models
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public string IdRole { get; set; }
        public string NameRole { get; set; }
        public bool? Stat { get; set; }
        public DateTime? Datecreated { get; set; }
        public DateTime? Dateupdated { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}

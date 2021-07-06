using System;
using System.Collections.Generic;

#nullable disable

namespace InstituteOfFineArt.Models
{
    public partial class Account
    {
        public Account()
        {
            Bills = new HashSet<Bill>();
            Comments = new HashSet<Comment>();
            Competitions = new HashSet<Competition>();
            Feedbacks = new HashSet<Feedback>();
            LoginHistories = new HashSet<LoginHistory>();
            Tests = new HashSet<Test>();
        }

        public string IdAcc { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public DateTime? Dob { get; set; }
        public bool? Gender { get; set; }
        public string Avatar { get; set; }
        public string PhoneNumber { get; set; }
        public string Addr { get; set; }
        public string ContestsParticipated { get; set; }
        public DateTime? Datecreated { get; set; }
        public DateTime? Dateupdated { get; set; }
        public bool? Stat { get; set; }
        public string IdRole { get; set; }

        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Competition> Competitions { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<LoginHistory> LoginHistories { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}

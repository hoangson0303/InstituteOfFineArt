using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Services
{
    public class EventServiceImpl : EventService
    {
        private DatabaseContext db;

        public EventServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }
        public List<Competition> FindAll()
        {
            return db.Competitions.Where(p => p.Stat == true && p.DateEnd >= DateTime.Now).ToList();
        }
    }
}

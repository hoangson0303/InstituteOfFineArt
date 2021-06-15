using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Services
{
    public class RoleServiceImpl : RoleService
    {
        private DatabaseContext db;

        public RoleServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }

        public int CountIdById(string id)
        {
            return db.Roles.Where(p => p.IdRole.Contains(id)).Count();
        }

        public Role Create(Role role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
            return role;
        }

        public void Delete(string idRole)
        {
            db.Roles.Remove(db.Roles.Find(idRole));
            db.SaveChanges();
        }

        public List<Role> FindAll()
        {
            return db.Roles.ToList();
        }

        public List<UserRole> FindAllRoleUser()
        {
            return db.UserRoles.ToList();
        }

        public Role FindById(string idRole)
        {
            return db.Roles.SingleOrDefault(p => p.IdRole == idRole);
        }

        public string GetNewestId(string keyword)
        {
            return (from roles in db.Roles
                    where
                      roles.IdRole.Contains(keyword)
                    orderby
                      roles.IdRole descending
                    select roles.IdRole).Take(1).SingleOrDefault();
        }

        public Role Update(Role role)
        {
            db.Entry(role).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return role;
        }
    }
}

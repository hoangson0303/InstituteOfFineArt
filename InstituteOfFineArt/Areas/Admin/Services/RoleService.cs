using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Services
{
    public interface RoleService
    {
        List<Role> FindAll();
        List<UserRole> FindAllRoleUser();
        Role FindById(string idRole);
        Role Update(Role role);
        void Delete(string idRole);
        string GetNewestId(string keyword);

        int CountIdById(string id);
        Role Create(Role role);
    }
}

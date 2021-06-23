﻿using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public interface TestcoreService
    {
        public List<Account> FindUserById(string idAcc);
        List<TestCore> FindUserByIdCom(string idCom);
    }
}

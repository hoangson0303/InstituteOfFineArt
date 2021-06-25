﻿using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Services
{
    public interface DetailComService
    {
        Competition FindById(string idCom);
        public List<Competition> FindComById(string idCom);
    }
}
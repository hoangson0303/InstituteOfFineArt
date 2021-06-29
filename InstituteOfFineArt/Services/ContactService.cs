using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Services
{
    public interface ContactService
    {
        Feedback Create(Feedback feedback);




        int CountIdById(string id);

        string GetNewestId(string keyword);


  

    }
}

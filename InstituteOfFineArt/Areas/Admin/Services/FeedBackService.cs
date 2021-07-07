using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.Admin.Services
{
    public interface FeedBackService
    {
        List<Feedback> FindALlFeedBack();

        string FindIdAccByIdFeed(string idFeed);
        public string FindEmailByIdAcc(string idAcc);
        Feedback FindById(string idFeed);

        Feedback Update(Feedback feedback);

        List<Feedback> Search(string keyword);
    }
}

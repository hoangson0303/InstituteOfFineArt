using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Services
{
    public interface IndexService
    {
        List<Competition> FindAll();

        List<Competition> FindAllNextCom();

        List<Test> FindAllTest();

        List<Account> FindAllSchool();
        public List<Account> FindUserById(string idAcc);

        string FindIdRole(string idAcc);

        string FindNameRole(string idRole);

        Bill CreateBill(Bill bill);
        DetailBill CreateDetailBill(DetailBill detailBill);

        Test Update(Test test);

        Test FindById(string idTest);

        string FindIdComByIdTest(string idTest);

        string FindIdAccByIdCom(string idCom);

        string FindPhoneShippingTo(string idAccShippingTo);

        List<Account> InfoFormTo(string idAcc);

        List<DetailBill> InfoDetailBill(string idTest);

        string FindPhoneByIdAcc(string idAcc);
    }
}

using InstituteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteOfFineArt.Areas.User.Services
{
    public class ForgetPassServiceImpl : ForgetPassService
    {
        private DatabaseContext db;

        public ForgetPassServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }
        public Account FindByEmail(string email)
        {
            return db.Accounts.FirstOrDefault(x => x.Email == email);
        }

        public string RandomPassword(int number)
        {
            var chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            var password = string.Empty;
            var random = new Random();
            for (var i = 0; i < number; i++)
            {
                var x = random.Next(1, chars.Length);
                if (!password.Contains(chars.GetValue(x).ToString()))
                {
                    password += chars.GetValue(x);
                }
                else
                {
                    i--;
                }
            }

            return password;

        }

        public Account Update(Account account)
        {
            db.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return account;
        }
    }
}

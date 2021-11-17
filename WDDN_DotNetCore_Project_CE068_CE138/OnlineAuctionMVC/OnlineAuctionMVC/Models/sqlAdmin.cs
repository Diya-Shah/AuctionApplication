using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuctionMVC.Models
{
    public class sqlAdmin
    {
        private readonly AppDbContext context;
        public sqlAdmin(AppDbContext context)
        {
            this.context = context;
            /*Admin admin1 = new Admin();
            Admin admin2= new Admin();
            admin1.Email = "palna@gmail.com";
            admin1.Password = "palna";
            admin2.Email = "diya@gmail.com";
            admin2.Password = "diya";
            context.Admins.Add(admin1);
            context.Admins.Add(admin2);
            context.SaveChanges();*/
        }
        public IEnumerable<Admin> GetAllAdmins()
        {
            return context.Admins;
        }
        public Admin GetUser(string Email, string Password)
        {
            return context.Admins.FirstOrDefault(x => x.Email == Email && x.Password == Password);
        }
    }
}

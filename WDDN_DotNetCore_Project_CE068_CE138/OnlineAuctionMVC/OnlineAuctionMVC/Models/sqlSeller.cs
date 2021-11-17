using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuctionMVC.Models
{
    public class sqlSeller
    {
        private readonly AppDbContext context;
        public sqlSeller(AppDbContext context)
        {
            this.context = context;
        }
        
        public void Add(Seller seller)
        {
            context.Sellers.Add(seller);
            context.SaveChanges();
        }
        public Seller GetUser(string Email, string Password)
        {
            return context.Sellers.FirstOrDefault(x => x.Email == Email && x.Password == Password);
        }
        public IEnumerable<Seller> GetAllSellers()
        {
            return context.Sellers;
        }
       
    }
}

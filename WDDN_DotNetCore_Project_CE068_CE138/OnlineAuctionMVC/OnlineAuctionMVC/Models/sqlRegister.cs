using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuctionMVC.Models
{
    public class sqlRegister
    {
        private readonly AppDbContext context;
        public sqlRegister(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Register register)
        {
            context.Registers.Add(register);
            context.SaveChanges();
        }
        public Register GetUser(string Email,string Password)
        {
            return context.Registers.FirstOrDefault(x=> x.Email==Email && x.Password==Password);
        }
        public IEnumerable<Register> GetAllBidders()
        {
            return context.Registers;
        }
    }
}

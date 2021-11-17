using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuctionMVC.Models
{
    public class sqlResult
    {
        private readonly AppDbContext context;
        public sqlResult(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(int Pid, string name, int amount)
        {
            Result result = new Result();
            result.Pid = Pid;
            result.bidderName = name;
            result.bidAmount = amount;
            context.Results.Add(result);
            context.SaveChanges();
        }
        public IEnumerable<Result> GetAllResults(string biddername)
        {
            return context.Results.Where(x => x.bidderName == biddername);
        }
        public IEnumerable<Result> GetAllAdminResults()
        {
            return context.Results;
        }
        public List<Product> GetProduct(List<Result> results)
        {
            List<Product> productList = new List<Product>();
            foreach (Result result in results)
            {
                Product product = context.Products.Find(result.Pid);
                productList.Add(product);
            }
            return productList;            
        }
    }
}

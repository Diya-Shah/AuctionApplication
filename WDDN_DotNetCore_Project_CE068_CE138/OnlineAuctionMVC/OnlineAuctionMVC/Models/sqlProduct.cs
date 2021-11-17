using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuctionMVC.Models
{
    public class sqlProduct
    {
        private readonly AppDbContext context;
        public sqlProduct(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void AddSId(int SId, int PId)
        {
            Product p = context.Products.FirstOrDefault(x => x.PId == PId);
            p.SId = SId;
            context.SaveChanges();
        }
        public void UpdateAccepted(int PId)
        {
            Product p = context.Products.FirstOrDefault(x => x.PId == PId);
            p.Accepted = 1;
            context.SaveChanges();
        }
        public void UpdateDeleted(int PId)
        {
            Product p = context.Products.FirstOrDefault(x => x.PId == PId);
            context.Products.Remove( p);   
            context.SaveChanges();
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products.Where(x => x.Accepted == 0);
        }
        public IEnumerable<Product> GetAllAdminProducts()
        {
            return context.Products.Where(x => x.Accepted == 1);
        }
        public IEnumerable<Product> GetAllAcceptedProducts(int CId)
        {
            return context.Products.Where(x => x.Accepted == 1 && x.Sold==0 && x.CId==CId);
        }
        public IEnumerable<Product> GetSellerProducts(int sid)
        {
            return context.Products.Where(x => x.Accepted == 1 && x.SId==sid);
        }
        public IEnumerable<Product> GetSellerSoldProducts(int sid)
        {
            return context.Products.Where(x => x.Accepted == 1 && x.SId == sid && x.Sold==1);
        }
        public IEnumerable<Product> GetAllResultProducts()
        {
            return context.Products.Where(x => x.Accepted == 1 && x.Sold == 1);
        }
        public Product GetBidProduct(int PId)
        {
            return context.Products.FirstOrDefault(x => x.PId == PId);
        }
        public void setSold(int PId)
        {
            Product p = context.Products.FirstOrDefault(x => x.PId == PId);
            p.Sold = 1;
            context.SaveChanges();
        }

    }
}

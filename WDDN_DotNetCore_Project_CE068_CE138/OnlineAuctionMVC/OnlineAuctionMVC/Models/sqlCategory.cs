using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuctionMVC.Models
{
    public class sqlCategory
    {
        private readonly AppDbContext context;
        public sqlCategory(AppDbContext context)
        {
            this.context = context;
         /*   Category cat1 = new Category();
            Category cat2 = new Category();
            Category cat3 = new Category();
            cat1.Name = "Electronics";
            cat2.Name = "Fashion";
            cat3.Name = "Health";
            context.Categories.Add(cat1);
            context.Categories.Add(cat2);
            context.Categories.Add(cat3);
            context.SaveChanges();*/
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return context.Categories;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuctionMVC.Models
{
    public class ViewModel
    {
        public List<Category> Categories { get; set; }
        public IEnumerable<Participant> Participants { get; set; }
        public Product Product { get; set; }
        public IEnumerable<Result> Results { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> AdminCategory { get; set; }
        public IEnumerable<Product> AdminProduct { get; set; }
        public IEnumerable<Seller> AdminSeller { get; set; }
        public IEnumerable<Register> AdminBidder { get; set; }

    }
}

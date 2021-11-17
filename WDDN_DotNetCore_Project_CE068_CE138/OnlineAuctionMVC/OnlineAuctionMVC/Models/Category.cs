using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineAuctionMVC.Models
{
    public class Category
    {
        [Key]
        public int CId { get; set; }

        public String Name { get; set; }
    }
}

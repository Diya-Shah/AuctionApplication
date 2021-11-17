using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineAuctionMVC.Models
{
    public class Product
    {
        [Key]
        public int PId { get; set; }
        [Required(ErrorMessage = "Please Enter Product Name")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Please Enter Product Details")]
        public String Details { get; set; }
        [Required(ErrorMessage = "Please Insert Product Image")]
        public String Image { get; set; }
        [Required(ErrorMessage = "Please Enter Product bid price")]
        public int Bid_price { get; set; }
        public int CId { get; set; }
        public int SId { get; set; }
        public int Accepted { get; set; }
        [Required(ErrorMessage = "Please Enter bid date")]
        public String date { get; set; }
        [Required(ErrorMessage = "Please Enter bid time")]
        public String time { get; set; }
        public int Sold { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public Product()
        {
            Accepted = 0;
            Sold = 0;
        }
    }
}

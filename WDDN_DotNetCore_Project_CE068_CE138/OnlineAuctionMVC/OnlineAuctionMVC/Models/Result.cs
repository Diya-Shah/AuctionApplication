using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuctionMVC.Models
{
    public class Result
    {
        [Key]
        public int Rid { get; set; }
        public int Pid { get; set; }
        public string bidderName { get; set; }
        public int bidAmount { get; set; }
    }
}

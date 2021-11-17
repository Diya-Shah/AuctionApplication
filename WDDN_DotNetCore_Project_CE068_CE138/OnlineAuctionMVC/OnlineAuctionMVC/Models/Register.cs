using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace OnlineAuctionMVC.Models
{
    public class Register
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Confirm Your Password")]
        [Compare("Password", ErrorMessage = "Password and ConfirmPassword must match")]
        public string CPassword { get; set; }
        [Required(ErrorMessage = "Please Select Your Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Enter Your Contact-No")]
        public string Contact { get; set; }
    }
}

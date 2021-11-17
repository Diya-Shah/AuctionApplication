using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuctionMVC.Controllers
{
    public class ExtraController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Cookie()
        {
            return View();
        }
        public IActionResult Terms()
        {
            return View();
        }
    }
}

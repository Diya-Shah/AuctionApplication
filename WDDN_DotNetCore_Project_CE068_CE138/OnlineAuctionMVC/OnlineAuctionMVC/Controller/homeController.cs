using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnlineAuctionMVC.Controllers
{
    public class homeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult set(string button)
        {
            
            if (button == "admin")
            {
                HttpContext.Session.SetString("login", "1");
            }
            else if (button == "seller")
            {
                HttpContext.Session.SetString("login", "2");
            }
            else
            {
                HttpContext.Session.SetString("login", "3");
            }
            return RedirectToAction("login","register");
        }
    }
}

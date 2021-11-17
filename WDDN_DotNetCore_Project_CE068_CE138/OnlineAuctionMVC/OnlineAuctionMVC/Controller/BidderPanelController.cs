using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using OnlineAuctionMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace OnlineAuctionMVC.Controllers
{
    public class BidderPanelController : Controller
    {

        private readonly sqlCategory _category;
        private readonly sqlProduct _product;
        private readonly sqlParticipant _participant;
        private readonly sqlResult _result;
        public AppDbContext db;
        public BidderPanelController(sqlCategory category, sqlProduct product, sqlParticipant participant, sqlResult result, AppDbContext context)
        {
            _category = category;
            _product = product;
            _participant = participant;
            _result = result;
            this.db = context;

        }
        [HttpGet]
        public ViewResult bidderPanel()
        {
            var model = _category.GetAllCategories();
            ViewBag.login = "/register/Login";
            return View(model);

        }
        [HttpPost]

        public IActionResult viewProducts([Optional] int Cid)
        {
            ViewBag.param = Cid;
            HttpContext.Session.SetInt32("CId", Cid);
            var model = _product.GetAllAcceptedProducts(Cid);
            return View(model);
        }
        [HttpGet]
        public IActionResult viewProducts()
        {

            int Cid = (int)HttpContext.Session.GetInt32("CId");
            var model = _product.GetAllAcceptedProducts(Cid);
            return View(model);

        }


        public IActionResult register(string button, int Pid, int amount)
        {
            HttpContext.Session.SetInt32("PId", Pid);
            HttpContext.Session.SetInt32("Amount", amount);
            return View();
        }

        [HttpPost]
        public IActionResult set(string button, string Name, int Cid)
        {
            if (button == "bidRegister")
            {
                HttpContext.Session.SetString("bidRegister", "yes");
            }
            int BId = (int)HttpContext.Session.GetInt32("BId");
            int PId = (int)HttpContext.Session.GetInt32("PId");
            int amount = (int)HttpContext.Session.GetInt32("Amount");
            _participant.Add(BId, PId, Name, amount);
            HttpContext.Session.SetInt32("CId", Cid);
            return RedirectToAction("ViewProducts");
        }
       
        public IActionResult joinsession(int? Pid,int? amount, [Optional]string name)
        {
            if (amount.HasValue && name!=null)
            {
                string str = "Congratulations " + name.ToString() + " !! You won this bid by an amount of " + amount.ToString() +" !!";            
                ViewBag.resultmsg = str;
                ViewBag.disable = "yes";
                ViewBag.viewresult = "/BidderPanel/Result";
                HttpContext.Session.SetString("bidderName", name);
                int pid = Convert.ToInt32(HttpContext.Session.GetInt32("Pid"));
                var participants = _participant.GetAllParticipants(pid);
                var product = _product.GetBidProduct(pid);
                var ViewModel = new ViewModel
                {
                    Participants = participants,
                    Product = product
                };
                return View(ViewModel);
            }
           
            if (Pid.HasValue)
            {
                
                var participants = _participant.GetAllParticipants(Convert.ToInt32(Pid));
                var product = _product.GetBidProduct(Convert.ToInt32(Pid));
                var ViewModel = new ViewModel
                {
                    Participants = participants,
                    Product = product
                };
                return View(ViewModel);
            }
            else
            {
               
                int pid = Convert.ToInt32(HttpContext.Session.GetInt32("Pid"));
                var participants = _participant.GetAllParticipants(pid);
                var product = _product.GetBidProduct(pid);
                var ViewModel = new ViewModel
                {
                    Participants = participants,
                    Product = product
                };
                return View(ViewModel);
            }
            
        }
        
        public IActionResult ResultToWinner()
        {
            int Pid = (int)HttpContext.Session.GetInt32("Pid");
            Participant p = _participant.getWinner(Pid);
            _result.Add(p.Pid, p.bidderName, p.bidAmount);
            _product.setSold(p.Pid);
            
            return RedirectToAction("joinsession",new { amount = p.bidAmount , name=p.bidderName });

        }
       
        [HttpPost]
        public IActionResult update(int Pid, int Bid, int bidamount)
        {
            if (bidamount > _participant.getBidAmount(Pid))
            {
                _participant.Update(Pid, Bid, bidamount);
                HttpContext.Session.SetInt32("Pid", Pid);
            }
            else
            {
                ViewBag.message = "Invalid Bid-amount";
            }
            return RedirectToAction("joinsession");
        }
        public IActionResult Result()
        {
            ViewBag.index = "/Home/Index";
            string name = HttpContext.Session.GetString("bidderName");
            var model=_result.GetAllResults(name);
            var x = _result.GetProduct(model.ToList());
            var ViewModel = new ViewModel
            {
                Results = model,
                Products = x,
            };
            return View(ViewModel);
        }
    }
}

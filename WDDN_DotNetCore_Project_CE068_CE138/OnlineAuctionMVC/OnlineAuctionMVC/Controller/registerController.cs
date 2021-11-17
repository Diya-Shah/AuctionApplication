using Microsoft.AspNetCore.Mvc;
using OnlineAuctionMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Http;
using System.Dynamic;
using System.Runtime.InteropServices;

namespace OnlineAuctionMVC.Controllers
{
    
    public class registerController : Controller
    {
        private readonly sqlRegister _register;
        private readonly sqlSeller _seller;
        private readonly sqlAdmin _admin;
        public registerController(sqlRegister register,sqlAdmin admin,sqlSeller seller)
            {
                _register = register;
                _admin = admin;
                _seller = seller;
            }
        [HttpGet]
        public ViewResult Login()
        {
            ViewBag.val = HttpContext.Session.GetString("login");
            ViewBag.index = "/Home/Index";
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email,string Password)
        {
            ViewBag.index = "/Home/Index";
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetString("login") == "3")
                {
                    Register register = _register.GetUser(Email, Password);
                    if (register == null)
                    {
                        Response.StatusCode = 404;
                        ViewBag.Message = "Invalid Username/Password";
                        ViewBag.val = HttpContext.Session.GetString("login");
                    }
                    else
                    {
                        ViewBag.Message = "Bidder Login Successfull";
                        var id = register.Id;
                        HttpContext.Session.SetInt32("BId", id);
                        return RedirectToAction("BidderPanel", "BidderPanel");
                    }
                }
                if (HttpContext.Session.GetString("login") == "2")
                {
                    Seller seller = _seller.GetUser(Email, Password);
                    
                    if (seller == null)
                    {
                        Response.StatusCode = 404;
                        ViewBag.Message = "Invalid Username/Password";
                        ViewBag.val = HttpContext.Session.GetString("login");
                    }
                    else
                    {
                        ViewBag.Message = "Seller Login Successfull";
                        var id = seller.Id;
                        HttpContext.Session.SetInt32("SId", id);
                        return RedirectToAction("SellerPanel","SellerPanel");
                    }
                }
                if (HttpContext.Session.GetString("login") == "1")
                {
                    Admin admin = _admin.GetUser(Email, Password);
                    if (admin == null)
                    {
                        Response.StatusCode = 404;
                        ViewBag.Message = "Invalid Username/Password";
                        ViewBag.val = HttpContext.Session.GetString("login");
                    }
                    else
                    {
                        ViewBag.Message = "Admin Login Successfull";
                        return RedirectToAction("AdminPanel","AdminPanel");
                    }
                }
            }
            return View();
        }

        [HttpGet]
            public ViewResult Create()
            {
                return View();
            }

        [HttpPost]
        public IActionResult Create([Optional] Register register, [Optional] Seller seller)
        {
                if (ModelState.IsValid)
                {
                    if (HttpContext.Session.GetString("login") == "3")
                    {
                        _register.Add(register);
                        ViewBag.Message = "Bidder Registration Successfull";
                        return RedirectToAction("login");

                    }
                    if (HttpContext.Session.GetString("login") == "2")
                    {
                        _seller.Add(seller);
                        ViewBag.Message = "Seller Registration Successfull";
                        return RedirectToAction("login");

                    }
                }
            
            return View();
        }


    }
}

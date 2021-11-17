using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineAuctionMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuctionMVC.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly sqlProduct _product;
        private readonly sqlCategory _category;
        private readonly sqlSeller _seller;
        private readonly sqlRegister _register;
        private readonly sqlResult _result;
        private readonly sqlAdmin _admin;
        public AppDbContext db;
        public AdminPanelController(sqlAdmin admin,sqlProduct product,sqlCategory category,sqlSeller seller,sqlRegister register,sqlResult result,AppDbContext context)
        {
            _product = product;
            _category = category;
            _result = result;
            _seller = seller;
            _register = register;
            _admin = admin;
            this.db = context;
        }
        [HttpGet]
        public ViewResult adminPanel()
        {
            ViewBag.login = "/register/Login";
            var model = _admin.GetAllAdmins();
            return View(model);
        }
        [HttpGet]
        public ViewResult requestedProducts()
        {
            var model = _product.GetAllProducts();
            return View(model);
        }
        [HttpGet]
        public ViewResult viewCategories()
        {
            var aCategory = _category.GetAllCategories();
            var aProduct = _product.GetAllAdminProducts();
            var ViewModel = new ViewModel
            {
                AdminCategory = aCategory,
                AdminProduct = aProduct
            };
            return View(ViewModel);
        }
        [HttpGet]
        public ViewResult viewSellers()
        {
            var aSeller = _seller.GetAllSellers();
            var aBidder = _register.GetAllBidders();
            var ViewModel = new ViewModel
            {
                AdminSeller = aSeller,
                AdminBidder = aBidder
            };
            return View(ViewModel);
        }
        [HttpGet]
        public ViewResult viewResults()
        {
            var model = _result.GetAllAdminResults();
            var x = _result.GetProduct(model.ToList());
            var ViewModel = new ViewModel
            {
                Results = model,
                Products = x,
            };
            return View(ViewModel);
        }
        public IActionResult set(string button,int Pid)
        {
            ViewBag.val = button;
            //HttpContext.Session.SetString("pid",Pid);
            if (button == "Accept")
            {
                _product.UpdateAccepted(Pid);
                ViewBag.Message = "Product Request Accepted   ";
            }
            else if(button == "Decline")
            {
                _product.UpdateDeleted(Pid);
                ViewBag.Message = "Product Request Declined   ";
            }
            return RedirectToAction("requestedProducts");

        }
        }
}
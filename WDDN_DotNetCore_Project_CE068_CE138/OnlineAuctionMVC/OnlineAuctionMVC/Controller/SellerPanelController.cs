using Microsoft.AspNetCore.Mvc;
using OnlineAuctionMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Dynamic;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace OnlineAuctionMVC.Controllers
{
    public class SellerPanelController : Controller
    {
        private readonly sqlProduct _product;
        private readonly IWebHostEnvironment _env;
        public AppDbContext db;
        public SellerPanelController(sqlProduct product,AppDbContext context, IWebHostEnvironment env)
        {
            _product = product;
            this.db = context;
            _env = env;
        }
        [HttpGet]
        public IActionResult sellerPanel()
        {
            int Sid = (int)HttpContext.Session.GetInt32("SId");
            var model = _product.GetSellerProducts(Sid);
            ViewBag.login = "/register/Login/";
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            var cat = db.Categories.ToList();
            var ViewModel = new ViewModel
            {
                Categories = cat
            };
            return View(ViewModel);
        }
        [HttpGet]
        public ViewResult Sold()
        {
            int Sid = (int)HttpContext.Session.GetInt32("SId");
            var model = _product.GetSellerSoldProducts(Sid);
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Optional] Product product)
        {
           
                int SId = (int)HttpContext.Session.GetInt32("SId");
                string wwwrootpath = _env.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                product.Image = filename + extension;
                string Image = filename + extension;
                
                string path = Path.Combine(wwwrootpath + "/Images/", Image);
                using(var filestream = new FileStream(path, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(filestream);
                }
            
                _product.Add(product);
                _product.AddSId(SId, product.PId);
               return RedirectToAction("sellerPanel");    
           
        }

    }
}

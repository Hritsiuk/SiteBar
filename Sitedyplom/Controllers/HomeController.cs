using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sitedyplom.Data.Repositories.EntityFrameworks;
using Sitedyplom.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Sitedyplom.Data;
using RestSharp;
using Newtonsoft.Json;

namespace Sitedyplom.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        private DataManager dataManager;
        public HomeController(ApplicationDbContext context, DataManager datamanager)
        {
            db = context;
            dataManager = datamanager;


        }

        public IActionResult Index()
        {
            

            IQueryable<Clothes> cl = db.Clothes;
            foreach (Clothes model in cl)
            {
                model.category = db.Categories.Where(p => p.Id == model.categoryId).First();
            }

            return View(cl);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Shop(string id)
        {
            IQueryable<Clothes> cl = db.Clothes;

            if (id != null)
                cl = db.Clothes.Where(p => p.category.name == id);


            foreach (Clothes model in cl)
            {
                model.category = db.Categories.Where(p => p.Id == model.categoryId).First();
            }
           
            return View(cl);
        }

        [HttpGet]
        public IActionResult Cart(string json)
        {
            List<ClothesOnView> list = new List<ClothesOnView>();
            float total = 0;
            Root myclass = JsonConvert.DeserializeObject<Root>(json);
            foreach (Arr id in myclass.arr)
            {
                ClothesOnView cl = new ClothesOnView();
                cl.clothes = db.Clothes.Where(p => p.Id == new Guid(id.name)).First();
                cl.count = id.count;
                cl.price = cl.clothes.price * id.count;
                total += cl.price;
                list.Add(cl);
            }
            ViewBag.total = total;
                return View(list);
        }

        [HttpGet]
        public IActionResult Checkout(string json)
        {
            List<ClothesOnView> list = new List<ClothesOnView>();
            float total = 0;
            Root myclass = JsonConvert.DeserializeObject<Root>(json);
            foreach (Arr id in myclass.arr)
            {
                ClothesOnView cl = new ClothesOnView();
                cl.clothes = db.Clothes.Where(p => p.Id == new Guid(id.name)).First();
                cl.count = id.count;
                cl.price = cl.clothes.price * id.count;
                total += cl.price;
                list.Add(cl);
            }
            ViewBag.total = total;
            return View(list);
            
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Shop(SortViewModel model,string id)
        {
            IQueryable<Clothes> cl;
            if (model.name != null)
            {
                 cl = db.Clothes.Where(p => p.name.Contains(model.name));
            }
            else
            { 
                cl = db.Clothes;
            }
            foreach (Clothes model2 in cl)
            {
                model2.category = db.Categories.Where(p => p.Id == model2.categoryId).First();
            }

            return View(id!=null? cl.Where(p => p.category.name == id):cl);
        }

        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View(new Feedback());
        }
        [HttpPost]
        public IActionResult Contact(Feedback model)
        {
            db.Feedbacks.Add(model);
            db.SaveChanges();
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Sitedyplom.Data;
using Sitedyplom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sitedyplom.Controllers
{
    public class ItemController : Controller
    {
        private ApplicationDbContext db;
        private DataManager dataManager;
        public ItemController(ApplicationDbContext context, DataManager datamanager)
        {
            db = context;
            dataManager = datamanager;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new CreateItemViewModel());
        }

        [HttpPost]
        public IActionResult Add(CreateItemViewModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detail(string id)
        {
            Clothes cl = db.Clothes.Where(p => p.Id ==new Guid(id)).First();
            cl.category = db.Categories.Where(p => p.Id == cl.categoryId).First();

            return View(cl);
        }
    }
}

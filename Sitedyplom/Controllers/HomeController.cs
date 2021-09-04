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
        
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View(db.Clothes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sitedyplom.Controllers
{
    public class ItemController : Controller
    {

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
    }
}

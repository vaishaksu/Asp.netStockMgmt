using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockManagement.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StockManagement.Controllers
{
    public class HomeController : Controller
    {
        public List<Item> inputItem = new List<Item>();

        public List<Item> ItemList { get; set; }

        private MyDBContext _context;

        public HomeController(MyDBContext _ctx)
        {
            _context = _ctx;
        }

        public IActionResult Index()
        {
            TempData["Username"] = null;
            HttpContext.Session.SetObject<List<Item>>("MyCart", inputItem);

            List<Item> items = _context.Items.ToList();
            ViewBag.Items = items;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

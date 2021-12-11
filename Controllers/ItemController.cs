using Microsoft.AspNetCore.Mvc;
using StockManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Controllers
{
    public class ItemController : Controller
    {
        static int quantity = 0;

        static int idDetails = 0;

        private MyDBContext _context;

        public ItemController(MyDBContext _ctx)
        {
            _context = _ctx;
            ViewBag.quantity = 0;
        }

        [HttpGet]
        public IActionResult Index()
        {
            

            List<Item> items = _context.Items.ToList();

            //List<Item> items = new List<Item>() {
            //    new Item { item_id = 1, item_name = "Mobiles", seller_name = "Vaishak", price = 12234.65, quantity = 45, in_stock = true, item_image = "/img/mobile.jpeg" },
            //    new Item { item_id = 2, item_name = "Bags", seller_name = "Somu", price = 3456.7, quantity = 4, in_stock = true, item_image = "/img/bag.jpeg" },
            //    new Item { item_id = 3, item_name = "StudyLamp", seller_name = "Ramesh", price = 124.65, quantity = 5, in_stock = false, item_image = "/img/lamp.jpeg" },
            //    new Item { item_id = 4, item_name = "Night Lamps", seller_name = "sdf", price = 15.00, quantity = 45, in_stock = true, item_image = "/img/moon.jpeg" },
            //    new Item { item_id = 5, item_name = "Mobiles", seller_name = "Boss", price = 55.00, quantity = 215, in_stock = false, item_image = "/img/mobile.jpeg" },
            //    new Item { item_id = 6, item_name = "Watch", seller_name = "Nice", price = 165.00, quantity = 95, in_stock = true, item_image = "/img/watch.jpeg" },
            //    new Item { item_id = 7, item_name = "Tomatoes", seller_name = "Miche", price = 15.00, quantity = 45, in_stock = true, item_image = "/img/tomatoes.jpg" },
            //    new Item { item_id = 8, item_name = "Clothes", seller_name = "sdf", price = 215.00, quantity = 35, in_stock = true, item_image = "/img/cloth.jpeg" },
            //    new Item { item_id = 9, item_name = "Table", seller_name = "sdf", price = 159.00, quantity = 15, in_stock = true, item_image = "/img/table.jpeg" },
            //    new Item { item_id = 10, item_name = "Guitar", seller_name = "sdf", price = 25.00, quantity = 65, in_stock = true, item_image = "/img/guitar.jpeg" },
            //};

            ViewBag.Item = items;
            return View(items);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.quantity = quantity;
            TempData["quantity"] = quantity;
            TempData["item_id"] = id;
            Item item = _context.Items.Where(i => i.item_id == id).FirstOrDefault();
            
            //Item items = new Item { item_id = 1, item_name = "GIONEE Max Pro (Black, 32 GB)  (3 GB RAM)", seller_name = "Vaishak", price = 12234.65, quantity = 45, in_stock = true, item_image = "/img/mobile.jpeg"  };
            ViewBag.Item = item;
            idDetails = id;
            return View(item);
        }

        // Increment baseed on the click
        public IActionResult IncrementClick(string mine)
        {
            quantity++;
            ViewBag.quantity = quantity;
            TempData["quantity"] = quantity;
            return RedirectToAction("Details", new { id = idDetails });
        }

        // Decrement baseed on the click
        public IActionResult DecrementClick(string mine)
        {
            if (quantity > 0)
            {
                quantity--;
            }
            ViewBag.quantity = quantity;
            TempData["quantity"] = quantity;
            return RedirectToAction("Details", new { id = idDetails });
        }

        public IActionResult MyCart()
        {
            return View();
        }
    }
}

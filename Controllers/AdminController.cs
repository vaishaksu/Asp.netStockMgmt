using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockManagement.Models;
using System.Dynamic;
using System.Web;

namespace StockManagement.Controllers
{
    public class AdminController : Controller
    {

        private MyDBContext _context;

        public AdminController(MyDBContext _ctx)
        {
            _context = _ctx;
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
            ViewBag.Items = items;
            return View();
        }

        [HttpGet]
        public IActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ModifyItem(int id)
        {
            Item item = _context.Items.Where(m => m.item_id == id).FirstOrDefault();
            return View(item);
        }

        [HttpPost]
        public IActionResult ModifyItem(Item item)
        {
            string in_stockBool = Request.Form["in_stock"].ToString();

            bool in_stock = false;
            if (in_stockBool != "")
            {
                in_stock = true;  
            }

            Item item_value = new Item { in_stock = in_stock, item_id = item.item_id, item_description = item.item_description, item_image = item.item_image, item_name = item.item_name, price = item.price, quantity = item.quantity, seller_name = item.seller_name };
            _context.Items.Update(item_value);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteItem(int id)
        {
            //Item items = new Item { item_id = 1, item_name = "GIONEE Max Pro (Black, 32 GB)  (3 GB RAM)", seller_name = "Vaishak", price = 12234.65, quantity = 45, in_stock = true, item_image = "/img/mobile.jpeg" };
            Item item = _context.Items.Where(item => item.item_id == id).FirstOrDefault();
            //_context.Items.Remove(item);

            ViewBag.Item = item;
            return View(item);
        }

        [HttpPost]
        public IActionResult DeleteItem(Item item)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeliveredItem()
        {

            Item items = new Item { item_id = 1, item_name = "GIONEE Max Pro (Black, 32 GB)  (3 GB RAM)", seller_name = "Vaishak", price = 12234.65, quantity = 45, in_stock = true, item_image = "/img/mobile.jpeg" };
            ViewBag.Item = items;
            return View(items);
        }

        [HttpPost]
        public IActionResult DeliveredItem(int id)
        {
            return RedirectToAction("ModifyUnProcessedOrder");
        }

        [HttpGet]
        public IActionResult CancelOrder()
        {
            Item items = new Item { item_id = 1, item_name = "GIONEE Max Pro (Black, 32 GB)  (3 GB RAM)", seller_name = "Vaishak", price = 12234.65, quantity = 45, in_stock = true, item_image = "/img/mobile.jpeg" };
            ViewBag.Item = items;
            return View(items);
        }

        [HttpPost]
        public IActionResult CancelOrder(int id)
        {
            return RedirectToAction("ModifyUnProcessedOrder");
        }

        [HttpGet]
        public IActionResult ModifyUnProcessedOrder()
        {
            dynamic customer_item = new ExpandoObject();

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

            //List<Customer> customer = new List<Customer> {
            //    new Customer { customer_id = 1, customer_name = "Vaishak Surendran", email = "vaishak@gmail.com", phone_number = "123-456-7895", address = "xyz1 Campaign Street, North York, Canada, Ontario, M3P1W2" },
            //    new Customer { customer_id = 1, customer_name = "Vaishak Ashik", email = "vaishak2@gmail.com", phone_number = "123-446-7834", address = "xyz2 Campaign Street, North York, Canada, Ontario, M3P1W2" },
            //    new Customer { customer_id = 1, customer_name = "Vaishak Surendran", email = "vaishak3@gmail.com", phone_number = "123-456-7345", address = "xyz3 Campaign Street, North York, Canada, Ontario, M3P1W2" }
            //};
            List<Customer> customer = _context.Customers.ToList();
            List<Order> orders = _context.Orders.ToList();

            ViewBag.Items = items;
            ViewBag.Customer = customer;
            ViewBag.Orders = orders;

            customer_item.Item = items;
            customer_item.Customer = customer;
            customer_item.Orders = orders;

            return View(customer_item);
        }
    }
}

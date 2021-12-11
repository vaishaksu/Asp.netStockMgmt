using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockManagement.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace StockManagement.Controllers
{
    public class CustomerController : Controller
    {
        static int quantity = 0;
        public List<Item> items = new List<Item>();
        static bool fromRemoveCart = false;

        private MyDBContext _context;

     
        public CustomerController(MyDBContext _ctx)
        {
            _context = _ctx;
            ViewBag.quantity = 0;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.quantity = 0;
            ViewBag.quantity= quantity;



            List<Item> items = _context.Items.ToList();
            ViewBag.Items = items;

            // TODO: need to remove this


            return View();
        }

        [HttpGet]
        public IActionResult MyCart()
        {
            if (!fromRemoveCart) { // Coming from Removecart button click
                fromRemoveCart = false;
                ViewBag.itemId = TempData["item_id"];
                int id = ViewBag.itemId;
                Item item = _context.Items.Where(i => i.item_id == id).FirstOrDefault();
                Item inputItem = new Item();
                int q = 0;

                if (item != null) { 
                    if (TempData.ContainsKey("quantity"))
                    {
                        ViewBag.quantity = TempData["quantity"];
                        q = ViewBag.quantity;
                        inputItem = new Item { item_id = item.item_id, item_name = item.item_name, seller_name = item.seller_name, price = item.price, quantity = q, in_stock = item.in_stock, item_image = item.item_image, item_description = item.item_description };
                    }

                    List<Item> itemValue = HttpContext.Session.GetObject<List<Item>>("MyCart");
                    itemValue.Add(inputItem);
                    HttpContext.Session.SetObject("MyCart", itemValue);

                    

                    ViewBag.Items = itemValue;
                    return View(ViewBag.Items);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Address()
        {
            AccessingSessionObj sessionObj = HttpContext.Session.GetObject<AccessingSessionObj>("userInfo");
            string username = sessionObj.username;
            Customer customer = _context.Customers.Where(c => c.username == username).FirstOrDefault();
            //Customer customer = new Customer { customer_id = 1, customer_name = "Vaishak Surendran", email = "vaishak@gmail.com", phone_number="123-456-7895", address="xyz Campaign Street, North York, Canada, Ontario, M3P1W2"};
            ViewBag.customerAddress = customer;
            return View(customer);
        }


        [HttpPost]
        public IActionResult Address( Customer customer )
        {
            // TODO: After address is successfully input then navigate to order summary screen
            return RedirectToAction("OrderSummary");
            //return View();
        }

        [HttpPost]
        public IActionResult RemoveCartItem(int id)
        {
            Item inputItem = new Item();
            List<Item> itemsDatabase = HttpContext.Session.GetObject<List<Item>>("MyCart");

            Item item = itemsDatabase.Find(item => item.item_id == id);
            itemsDatabase.Remove(item);

            HttpContext.Session.SetObject("MyCart", itemsDatabase);
            fromRemoveCart = true;
            return RedirectToAction("MyCart", true);
        }

        [HttpGet]
        public IActionResult OrderSummary()
        {
            List<Item> items = HttpContext.Session.GetObject<List<Item>>("MyCart");

            ViewBag.Item = items;
            return View(items);
        }

        [HttpGet]
        public IActionResult Confirmation()
        {
            List<Item> items = HttpContext.Session.GetObject<List<Item>>("MyCart");
            AccessingSessionObj sessionObj = HttpContext.Session.GetObject<AccessingSessionObj>("userInfo");
            string username = sessionObj.username;
            Customer customer = _context.Customers.Where(c => c.username == username).FirstOrDefault();

            Random rnd = new Random();
            int tracking = rnd.Next(199999, 958412597);

            Order order = new Order { order_date = DateTime.Now.ToString("d"), items = JsonConvert.SerializeObject(items), tracking_number = tracking, order_status = "In Progress" };
            _context.Orders.Add(order);
            _context.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult MyOrders ()
        {
            List<Order> orders = _context.Orders.ToList();
            ViewBag.orders = orders;
            return View(orders);
        }
    }
}

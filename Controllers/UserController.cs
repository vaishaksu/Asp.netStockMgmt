using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockManagement.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace StockManagement.Controllers
{
    public class UserController : Controller
    {
        private MyDBContext _context;

        public UserController(MyDBContext _ctx)
        {
            _context = _ctx;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            TempData["Username"] = "Vaishak Suredran";
            ViewBag.error = "";
            User u = _context.Users.Where(c => c.username == user.username).FirstOrDefault();
            if (u != null)
            {
                if (u.password == user.password)
                {
                    Customer cust = _context.Customers.Where(c => c.username == user.username).FirstOrDefault();

                    AccessingSessionObj sessionVar = new AccessingSessionObj { customer_name = cust.customer_name, username = user.username };
                    HttpContext.Session.SetObject<AccessingSessionObj>("userInfo", sessionVar);

                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ViewBag.error = "Password and confirm password doesn't match";
                }
            }
            else
            {
                ViewBag.error = "Username doesn't exists in the database. Please try to Signup";
            }

            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            AccessingSessionObj access = new AccessingSessionObj { username = "", customer_name = "" };
            HttpContext.Session.SetObject<AccessingSessionObj>("userInfo", access);
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userInfo");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Signup(Customer customer)
        {
            ViewBag.error = "";
            Customer cust = _context.Customers.Where(c => c.username == customer.username).FirstOrDefault();
            if (cust == null)
            {
                if (customer.password == customer.confirm_password)
                {
                    User user = new User { user_id = customer.customer_id, password = customer.password, is_admin = false, username = customer.username };
                    _context.Customers.Add(customer); // Insert
                    _context.Users.Add(user); // user Add
                    _context.SaveChanges(); // Customer save

                    AccessingSessionObj sessionVar = new AccessingSessionObj { customer_name = customer.customer_name, username = customer.username  };
                    HttpContext.Session.SetObject<AccessingSessionObj>("userInfo", sessionVar);

                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ViewBag.error = "Password and confirm password doesn't match";
                }
            }
            else
            {
                ViewBag.error = "Username already exists. Please try to login";
            }
            return View();
        }
    }
}

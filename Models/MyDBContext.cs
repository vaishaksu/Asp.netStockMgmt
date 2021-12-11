using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StockManagement.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasOne(t => t.Participant)
            //         .WithOne(t => t.User)
            //          .HasForeignKey<Participant>(t => t.UserId);

            modelBuilder.Entity<Customer>().HasOne(t => t.order)
                     .WithOne(t => t.customer)
                      .HasForeignKey<Order>(t => t.customer_id);

            modelBuilder.Entity<Order>().HasOne(t => t.customer)
                     .WithOne(t => t.order)
                      .HasForeignKey<Order>(t => t.customer_id);

            //modelBuilder.Entity<Customer>().HasData(
            //    new Customer
            //    {
            //        customer_id = 1,
            //        customer_name = "Vaishak",
            //        address = "xyz North York",
            //        email = "xyz@gmail.com",
            //        phone_number = "1234567890",
            //        order_id = 3000,
            //        item_id = 101,
            //        user_id = 1001,
            //    }
            //);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    user_id = 1000, password = "password", is_admin = true, username = "root"
                },
                 new User
                 {
                     user_id = 1001, password = "password1", is_admin = false, username = "abc"
                 }
            );

            //modelBuilder.Entity<Order>().HasData(
            //    new Order
            //    {
            //        order_id = 3000,
            //        order_date = "2020-11-19",
            //        customer_id = 1,
            //        item_id = 101,
            //    }
            //);


            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    item_id = 101, item_name = "Mobile", in_stock = true, price = 5000,quantity = 40, seller_name = "Sadguru", item_image = "Image7.jpg"
                },
                new Item
                {
                    item_id = 102, item_name = "bag", in_stock = true, price = 5000,quantity = 40, seller_name = "Sadguru", item_image = "Image1.jpg"
                },
                new Item
                {
                    item_id = 103, item_name = "Study Lamp", in_stock = true, price = 5000,quantity = 40, seller_name = "Sadguru", item_image = "Image5.jpg"
                },
                new Item
                {
                    item_id = 104, item_name = "Night Lamp", in_stock = true, price = 5000,quantity = 40, seller_name = "Sadguru", item_image = "Image13.jpg"
                },
                new Item
                {
                    item_id = 105, item_name = "Mobile", in_stock = true, price = 5000,quantity = 40, seller_name = "Sadguru", item_image = "Image7.jpg"
                },
                new Item
                {
                    item_id = 106, item_name = "Watch", in_stock = true, price = 5000,quantity = 40, seller_name = "Sadguru", item_image = "Image12.jpg"
                },
                new Item
                {
                    item_id = 107, item_name = "Tomato", in_stock = true, price = 5000,quantity = 40, seller_name = "Sadguru", item_image = "Image10.jpg"
                },
                new Item
                {
                    item_id = 108, item_name = "Clothes", in_stock = true, price = 5000,quantity = 40, seller_name = "Sadguru", item_image = "Image2.jpg"
                },
                new Item
                {
                    item_id = 109, item_name = "Table", in_stock = true, price = 5000,quantity = 40, seller_name = "Sadguru", item_image = "Image9.jpg"
                },
                new Item
                {
                    item_id = 100, item_name = "Guitar", in_stock = true, price = 5000,quantity = 40, seller_name = "Sadguru", item_image = "Image4.jpg"
                }
            );

        }
}
}

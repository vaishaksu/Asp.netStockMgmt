using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class Customer
    {

        
        [Key]
        public int customer_id { get; set; }

        public string? customer_name { get; set; }

        public string? email { get; set; }

        public string? phone_number { get; set; }

        public string? address { get; set; }


        public string? username { get; set; }

        public string? password { get; set; }

        public string? confirm_password { get; set; }


        [ForeignKey("user_id")]
        public int? user_id { get; set; }
        public User user { get; set; }

        //public string order_status { get; set; }

        [ForeignKey("order_id")]
        public int? order_id { get; set; }
        public Order order { get; set; }


        [ForeignKey("item_id")]
        public int? item_id { get; set; }
        public Item item { get; set; }
    }
}

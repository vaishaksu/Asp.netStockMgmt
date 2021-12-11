using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }

        //public string order_item { get; set; }

        public string? order_date { get; set; }

        public string? order_status { get; set; }

        public string? items { get; set; }

        public int? tracking_number { get; set; }

        [ForeignKey("customer_id")]
        public int? customer_id { get; set; }
        public Customer? customer { get; set; }
    }
}

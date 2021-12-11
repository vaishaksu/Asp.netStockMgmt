using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class Item
    {

        [Key]
        public int item_id { get; set; }

        public string? item_name { get; set; }

        public string? item_description { get; set; }

        public string? seller_name { get; set; }

        public double price { get; set; }

        public int? quantity { get; set; }

        public bool? in_stock { get; set; }

        public string? item_image { get; set; }
    }
}

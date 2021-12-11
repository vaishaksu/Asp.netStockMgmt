using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }

        public string? username { get; set; }

        public bool? is_admin { get; set; }

        public string? password { get; set; }

        public string? confirm_password { get; set; }
    }
}

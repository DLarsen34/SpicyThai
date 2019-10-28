using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpicyThai.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Count = 1;
        }
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int MenuItemId { get; set; }
        [ForeignKey("MenuItemId")]
        [NotMapped]
        public virtual MenuItem MenuItem { get; set; }
        [Range(1, 100, ErrorMessage="Please Order 1 or more items")]
        public int Count { get; set; }
    }
}

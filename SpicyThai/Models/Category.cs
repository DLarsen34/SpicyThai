using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpicyThai.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name="Category Name")]
        public string Name { get; set; }
    }
}

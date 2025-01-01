using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductCategoryMVC.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; } 

        public Category Category { get; set; } 
    }
}

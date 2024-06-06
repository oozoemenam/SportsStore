using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
	public class Product
	{
		public long? Id { get; set; }

		[Required(ErrorMessage = "Product name is required")]
		public string? Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number")]	
		[Column(TypeName = "decimal(8, 2)")]
		public decimal Price { get; set; }

        [Required(ErrorMessage = "Product category is required")]
        public string? Category { get; set; }
	}
}
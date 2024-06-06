using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [BindNever]
        public ICollection<CartLine> CartLines { get; set; } = new List<CartLine>();

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "First address line is required")]
        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }

        [Required(ErrorMessage = "City name is required")]
        public string? City { get; set; }

        [Required(ErrorMessage = "State name is required")]
        public string? State { get; set; }

        public string? Zip { get; set; }

        [Required(ErrorMessage = "Country name is required")]
        public string? Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}

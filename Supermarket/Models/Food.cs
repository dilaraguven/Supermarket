using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace Supermarket.Models
{
    public class Food
    {
        [Key] public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public int Weight { get; set; }

        public int Price { get; set; }

        
    }
}

using Entities ;

namespace WebMVC.Models
{
    public class HomeVM
    {
        public List<MainConfiguration>? MainConfigurations { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Product>? Products { get; set; }
        public string? Slug { get; set; } 
    }
}
 